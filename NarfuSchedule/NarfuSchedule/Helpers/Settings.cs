using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NarfuSchedule.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static int Group
        {
            get => AppSettings.GetValueOrDefault(nameof(Group), 0);
            set => AppSettings.AddOrUpdateValue(nameof(Group), value);
        }
    }
}
