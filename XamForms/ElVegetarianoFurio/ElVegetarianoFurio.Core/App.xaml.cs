using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElVegetarianoFurio.Models;
using Xamarin.Forms;

namespace ElVegetarianoFurio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ElVegetarianoFurio.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DbInitializer.Initialize(new VegiContext());
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
