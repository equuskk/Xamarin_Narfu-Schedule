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
    }
}
