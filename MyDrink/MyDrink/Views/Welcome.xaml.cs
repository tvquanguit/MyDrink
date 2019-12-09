using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyDrink.Views;
namespace MyDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private void Nav_To_Login(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Login());
        }
        private void Nav_To_Register(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Register());
        }
    }
}