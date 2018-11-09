using System.Collections.Generic;
using System.Linq;
using NarfuSchedule.Helpers;
using NarfuSchedule.Models;
using Xamarin.Forms;

namespace NarfuSchedule.ViewModels
{
    public class LessonsViewModel : BaseViewModel
    {
        public IEnumerable<IGrouping<string, Lesson>> Lessons { get; set; } = new List<IGrouping<string, Lesson>>();

        public readonly MainContext Db = MainContext.GetInstance();
        public bool IsBusy { get; set; }

        public LessonsViewModel()
        {
            if (Db.Lessons.Any())
                Lessons = Db.GetGrouperLessons();
        }

        public Command RefreshCommand => new Command(async () =>
        {
            IsBusy = true;
            var i = await ScheduleHelper.LoadLessons();

            if (i != 0)
                DependencyService.Get<IMessage>().LongTime($"Добавлено {i} пар.");

            Lessons = Db.GetGrouperLessons();
            IsBusy = false;
        }, () => !IsBusy);

        public Command DeleteCommand => new Command(async () =>
        {
            Db.Lessons.Clear(); 
            await Db.SaveChangesAsync();

            Lessons = Db.GetGrouperLessons();
        }, () => Lessons.Any());
    }
}