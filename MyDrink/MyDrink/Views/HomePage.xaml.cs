using MyDrink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var width = mainDisplayInfo.Width;
            //var itemList = new Style(typeof(StackLayout))
            //{
            //       Setters =
            //    {
            //        new Setter {Property = StackLayout.WidthRequestProperty , Value= width/2 - 20}
            //    }
            //};
            //Resources = new ResourceDictionary();
            //Resources.Add("itemList", itemList);
            var buttonStyle = new Style(typeof(Button))
            {
                Setters = {
                new Setter { Property = Button.TextColorProperty,    Value = Color.Teal }
            }
            };

            Resources = new ResourceDictionary();
            Resources.Add("buttonStyle", buttonStyle);
        }
        
    }
}