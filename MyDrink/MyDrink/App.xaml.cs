using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyDrink.Views;

namespace MyDrink
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //MainPage =  new MainShell();
            MainPage = new NavigationPage(new Login());
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
