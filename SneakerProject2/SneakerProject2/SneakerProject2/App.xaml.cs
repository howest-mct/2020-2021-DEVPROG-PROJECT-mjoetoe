using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SneakerProject2.Models;
using SneakerProject2.Repositories;

namespace SneakerProject2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage("empty");
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
