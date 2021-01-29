using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PuppyGo.Services;
using PuppyGo.Views;

namespace PuppyGo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            var unused = "this is unused so it should cause the build to fail";

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
