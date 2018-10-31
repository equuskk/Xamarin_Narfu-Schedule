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

        public readonly MainContext _db = MainContext.GetInstance();
        public bool IsBusy { get; set; }

        public LessonsViewModel()
        {
            if (_db.Lessons.Any())
                Lessons = _db.GetGrouperLessons();
        }

        public Command RefreshCommand => new Command(async () =>
        {
            IsBusy = true;
            var i = await ScheduleHelper.LoadLessons();

            if (i != 0)
                DependencyService.Get<IMessage>().LongTime($"Добавлено {i} пар.");

            Lessons = _db.GetGrouperLessons();
            IsBusy = false;
        }, () => !IsBusy);

        public Command DeleteCommand => new Command(async () =>
        {
            //TODO: ?
            //var result = await DisplayAlert("Очистить", "Вы действительно хотите очистить список пар?", "Да", "Нет");
            //if (!result) return;

            _db.Lessons.Clear(); //TODO: зачем так много строк?
            await _db.SaveChangesAsync();
            Lessons = _db.GetGrouperLessons();
        }, () => Lessons.Any());
    }
}