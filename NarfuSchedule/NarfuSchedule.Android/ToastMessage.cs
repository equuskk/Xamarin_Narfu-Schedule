using Android.Widget;
using NarfuSchedule.Droid;
using NarfuSchedule.Models;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ToastMessage))]
namespace NarfuSchedule.Droid
{
    public class ToastMessage : IMessage
    {
        public void LongTime(string msg)
        {
            var toast = Toast.MakeText(Application.Context, msg, ToastLength.Long);
            toast.Show();
        }

        public void ShortTime(string msg)
        {
            var toast = Toast.MakeText(Application.Context, msg, ToastLength.Short);
            toast.Show();
        }
    }
}