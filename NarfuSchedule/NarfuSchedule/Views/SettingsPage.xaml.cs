using NarfuSchedule.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NarfuSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}