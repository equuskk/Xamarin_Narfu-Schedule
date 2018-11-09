using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ical.Net;
using NarfuSchedule.Models;
using Xamarin.Forms;

namespace NarfuSchedule.Helpers
{
    public static class ScheduleHelper
    {
        private const string EndPoint = "https://ruz.narfu.ru";
        private static readonly MainContext Db = MainContext.GetInstance();

        public static async Task<int> LoadLessons()
        {
            var i = 0;
            var calen = "";
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    calen = await client.DownloadStringTaskAsync($"{EndPoint}/?icalendar&oid={Settings.Group}&from={DateTime.Now:dd.MM.yyyy}");
                }
                catch (WebException)
                {
                    DependencyService.Get<IMessage>().LongTime("Невозможно получить расписание.\n" +
                                                               "Либо сайт недоступен, либо подключитесь к интернету");
                    return 0;
                }
            }

            var cale = Calendar.LoadFromStream(GenerateStreamFromString(calen))[0];
            foreach (var ev in cale.Events.Where(x => x.Start.AsSystemLocal.DayOfYear >= DateTime.Now.DayOfYear)
                .OrderBy(x => x.Start).Distinct())
            {
                if (Db.Lessons.Any(x => x.Id == ev.Uid)) continue;

                var data = ev.Description.Split('\n');
                var les = new Lesson
                {
                    Address = ev.Location,
                    Groups = data[1].Substring(3),
                    Name = data[2],
                    Teacher = data[4],
                    Time = ev.Start.AsSystemLocal,
                    Type = data[3],
                    Id = ev.Uid
                };
                await Db.Lessons.AddAsync(les);
                i++;
            }

            if (Db.ChangeTracker.HasChanges())
                await Db.SaveChangesAsync();

            return i;
        }


        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}