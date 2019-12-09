using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyDrink.Views;
using Xamarin.Forms.Xaml;
using MyDrink.Helpers;
using MyDrink.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Plugin.FacebookClient;
using Newtonsoft.Json;
using SocialMediaAuthentication.Models;
using System.Diagnostics;

namespace MyDrink.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        IFacebookClient _facebookService = CrossFacebookClient.Current;
        public event PropertyChangedEventHandler PropertyChanged;
        Database db = new Database();

        public ICommand OnLoginCommand { get; set; }


        public ObservableCollection<AuthNetwork> AuthenticationNetworks { get; set; } = new ObservableCollection<AuthNetwork>()
        {
            new AuthNetwork()
            {
                Name = "Facebook",
                Icon = "ic_fb",
                Foreground = "#FFFFFF",
                Background = "#4768AD"
            },
             new AuthNetwork()
            {
                Name = "Instagram",
                Icon = "ic_ig",
                Foreground = "#FFFFFF",
                Background = "#DD2A7B"
            },
              new AuthNetwork()
            {
                Name = "Google",
                Icon = "ic_google",
                Foreground = "#000000",
                Background ="#F8F8F8"
            }
        };


        public LoginViewModel()
        {
            //LoginCommand = new Command(async () => await Login());

            //OnLoginCommand = new Command<AuthNetwork>(async (data) => await LoginAsync(data));

            OnLoginCommand = new Command(async () => await LoginFace());

        }
        async Task LoginAsync(AuthNetwork authNetwork)
        {
            switch (authNetwork.Name)
            {
                case "Facebook":
                    await LoginFacebookAsync(authNetwork);
                    break;
                case "Instagram":
                    LoginInstagram(authNetwork);
                    break;
                case "Google":
                    LoginGoogle(authNetwork);
                    break;
            }
        }
        void LoginGoogle(AuthNetwork authNetwork) { }
        void LoginInstagram(AuthNetwork authNetwork) { }

        async Task LoginFace()
        {
            try
            {

                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;

                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            var socialLoginData = new NetworkAuthData
                            {
                                //Email = facebookProfile.Email,
                                Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}"
                                //Id = facebookProfile.UserId
                            };
                            await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                            break;
                        case FacebookActionStatus.Canceled:
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;

                //string[] fbRequestFields = { "email", "first_name", "gender", "last_name" };
                //string[] fbPermisions = { "email" };
                //await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        async Task LoginFacebookAsync(AuthNetwork authNetwork)
        {
            Debug.WriteLine("LoginFace1");
            try
            {

                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            Debug.WriteLine("LoginFace 2");
                            var socialLoginData = new NetworkAuthData
                            {
                                Id = facebookProfile.Id,
                                Logo = authNetwork.Icon,
                                Foreground = authNetwork.Foreground,
                                Background = authNetwork.Background,
                                Picture = facebookProfile.Picture.Data.Url,
                                Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}",
                            };
                            //await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                            await Application.Current.MainPage.Navigation.PushModalAsync(new HomePageLogin(socialLoginData));
                            break;
                        case FacebookActionStatus.Canceled:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Canceled", "Ok");
                            break;
                        case FacebookActionStatus.Error:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Error", "Ok");
                            break;
                        case FacebookActionStatus.Unauthorized:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Unauthorized", "Ok");
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "picture", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }


        }

        async Task Login ()
        {
            try
            {
                if(string.Compare(userName, "ngominhnhi") == 0 && string.Compare(password, "ngominhnhi")== 0)
                {
                    //await Application.Current.MainPage.Navigation.PushModalAsync(new MainShell());
                    db.createDatabase();
                    
                    if (db.InsertStateLogin(SaveLogin()))
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Login Success", "ok");
                    } else
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Login Fail", "ok");
                    }
                    Application.Current.MainPage = new MainShell();
                    

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", userName + "+" + password + "@" + string.Compare(userName, "ngominhnhi")+ "@"+ string.Compare(password, "ngominhnhi"), "ok");
                }
            }
            catch
            {

            }
        }
        public StateLogin SaveLogin()
        {
            StateLogin store = new StateLogin
            {
                userName = userName,
                password = password
            };
            return store;
        }
        string userName;
        string password;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }
        public string DisplayMessageValue
        {
            get
            {
                return userName + " ---- "+password;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand { get; }
    }
}
