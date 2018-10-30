using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarfuSchedule.Models;
using Xamarin.Forms;

namespace NarfuSchedule.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IMessage>().LongTime("hello");
        }
    }
}
