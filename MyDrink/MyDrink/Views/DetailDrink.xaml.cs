using MyDrink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailDrink : ContentPage
    {
        public DetailDrink()
        {
            InitializeComponent();
            BindingContext = new DetailDrinkViewModel();
        }
    }
}