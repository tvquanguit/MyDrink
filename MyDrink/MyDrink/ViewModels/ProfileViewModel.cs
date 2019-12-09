using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MyDrink.Views;
using System.Threading.Tasks;

namespace MyDrink.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public Command OpenOtherPageCommand { get; }
        public ProfileViewModel()
        {
            OpenOtherPageCommand = new Command(async () => await OpenOtherPage());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public async Task OpenOtherPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditProfile());
        }
    }
}
