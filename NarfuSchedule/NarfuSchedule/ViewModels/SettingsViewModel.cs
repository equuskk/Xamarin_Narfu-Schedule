using NarfuSchedule.Helpers;
using NarfuSchedule.Models;
using Xamarin.Forms;

namespace NarfuSchedule.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public int Group { get; set; } = Settings.Group;

        public Command SaveCommand => new Command(() =>
        {
            Settings.Group = Group;
            DependencyService.Get<IMessage>().ShortTime("Сохранено!");
        }, () => Group > 0);
    }
}