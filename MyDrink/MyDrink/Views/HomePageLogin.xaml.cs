using System;
using System.Collections.Generic;
using Plugin.FacebookClient;
using SocialMediaAuthentication.Models;
using Xamarin.Forms;

namespace MyDrink.Views
{
    public partial class HomePageLogin : ContentPage
    {
        public HomePageLogin(NetworkAuthData networkAuthData)
        {
            BindingContext = networkAuthData;
            InitializeComponent();
        }

        async void OnLogout(object sender, System.EventArgs e)
        {
            //if(BindingContext is NetworkAuthData data)
            //{
            //     switch(data.Name)
            //     {
            //         case "Facebook":
            //             CrossFacebookClient.Current.Logout();
            //             break;
            //         case "Google":
            //             CrossGoogleClient.Current.Logout();
            //             break;
            //     }

            //    await Navigation.PopModalAsync();
            // }
        }
    }
}
