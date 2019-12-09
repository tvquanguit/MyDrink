using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using MyDrink.Models;
using Xamarin.Forms;
using MyDrink.Views;
namespace MyDrink.ViewModels
{
    class HomePageViewModel: INotifyPropertyChanged
    {
        public Command OpenOtherPageCommand { get; }
        //INavigation Navigation;

        public HomePageViewModel()
        {
            OpenOtherPageCommand = new Command(async () => await OpenOtherPage());
        }
        public async Task OpenOtherPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetailDrink());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        

    }
}
