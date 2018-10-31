using NarfuSchedule.Helpers;
using NarfuSchedule.ViewModels;
using System;
using NarfuSchedule.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NarfuSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel _vm;
        public SettingsPage()
        {
            InitializeComponent();
            _vm = new SettingsViewModel();
            BindingContext = _vm;
        }
    }
}