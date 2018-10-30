using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Ical.Net;
using NarfuSchedule.Models;

namespace NarfuSchedule
{
    public static class ScheduleHelper
    {
        private const string _endPoint = "https://ruz.narfu.ru";

        public static List<Lesson> LoadCalendar(short group = 9092)
        {
            var calen = "";
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    calen = client.DownloadString(
                        $"{_endPoint}/?icalendar&oid={group}&from={DateTime.Now:dd.MM.yyyy}");
                }
                catch (WebException e)
                {
                    return new List<Lesson>();
                }
            }

            var cale = Calendar.LoadFromStream(GenerateStreamFromString(calen))[0];
            var lessons = new List<Lesson>();
            foreach (var ev in cale.Events.OrderBy(x => x.Start).Distinct())
            {
                var data = ev.Description.Split('\n');

                var les = new Lesson
                {
                    Address = ev.Location,
                    Groups = data[1].Substring(3),
                    Name = data[2],
                    Teacher = data[4],
                    Time = ev.Start.AsSystemLocal,
                    Type = data[3],
                    Uid = ev.Uid
                };
                lessons.Add(les);
            }
            return lessons;
        }

        //public static List<Lesson> GetExams()
        //{

        //}

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