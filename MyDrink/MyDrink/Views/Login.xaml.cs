using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyDrink.ViewModels;
using MyDrink.Views;
namespace MyDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private void Nav_To_Login(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new MainShell());
        }
    }
}