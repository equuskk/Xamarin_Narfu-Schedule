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

        //void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    DependencyService.Get<IMessage>().ShortTime(e.Item.ToString());
        //}
    }
}
