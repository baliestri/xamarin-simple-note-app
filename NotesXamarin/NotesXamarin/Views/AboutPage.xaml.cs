using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotesXamarin.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://aka.ms/xamarin-quickstart");
        }
    }
}