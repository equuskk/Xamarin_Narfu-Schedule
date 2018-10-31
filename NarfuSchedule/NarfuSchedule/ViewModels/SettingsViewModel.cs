using NarfuSchedule.Helpers;

namespace NarfuSchedule.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public int Group { get; set; } = Settings.Group;
    }
}