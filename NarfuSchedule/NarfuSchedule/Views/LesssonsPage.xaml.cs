using NarfuSchedule.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NarfuSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LesssonsPage : ContentPage
    {
        public LesssonsPage()
        {
            InitializeComponent();
            BindingContext = new LessonsViewModel();
        }
    }
}