using NarfuSchedule.Models;
using NarfuSchedule.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NarfuSchedule
{
    public partial class App : Application
    {
        public const string DbFilename = "narfuScheduleApp.db";

        public App()
        {
            InitializeComponent();

            var path = DependencyService.Get<IPath>().GetDatabasePath(DbFilename);
            MainContext.SetPath(path);
            MainContext.GetInstance().Database.EnsureCreated();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}