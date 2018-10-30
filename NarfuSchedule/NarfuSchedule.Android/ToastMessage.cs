using Android.Widget;
using NarfuSchedule.Models;
using NarfuSchedule.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(ToastMessage))]
namespace NarfuSchedule.Droid
{
    public class ToastMessage : IMessage
    {
        public void LongTime(string msg)
        {
            var toast = Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Long);
            toast.Show();
        }

        public void ShortTime(string msg)
        {
            var toast = Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short);
            toast.Show();
        }
    }
}
