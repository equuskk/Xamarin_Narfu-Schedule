using System;
using NarfuSchedule.Helpers;
using NarfuSchedule.Models;
using NarfuSchedule.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NarfuSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LesssonsPage : ContentPage
    {
        private LessonsViewModel _vm;
        public LesssonsPage()
        {
            InitializeComponent();
            _vm = new LessonsViewModel();
            BindingContext = _vm;
        }

        private async void Refresh_OnClicked(object sender, EventArgs e)
        {
            var i = await ScheduleHelper.LoadLessons();

            if (i != 0)
                DependencyService.Get<IMessage>().LongTime($"Добавлено {i} пар.");

            _vm.Lessons = _vm._db.GetGrouperLessons();
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Очистить", "Вы действительно хотите очистить список пар?", "Да", "Нет");
            if (!result) return;

            _vm._db.Lessons.Clear(); //TODO: зачем так много строк?
            await _vm._db.SaveChangesAsync();
            _vm.Lessons = _vm._db.GetGrouperLessons();
        }
    }
}
