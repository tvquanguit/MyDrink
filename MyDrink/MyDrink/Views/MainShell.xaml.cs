using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyDrink.ViewModels;
using MyDrink.Helpers;
using MyDrink.Models;

namespace MyDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            CheckDataLogin();
            BindingContext = new MainShellViewModel();
        }
        void CheckDataLogin()
        {
            Database db = new Database();
            StateLogin store = db.GetStateLogin();
            if (store == null)
            {
                this.Navigation.PushModalAsync(new Welcome());
            }
        }
    }
}