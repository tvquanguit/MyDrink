using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyDrink.ViewModels
{
    public class DetailDrinkViewModel: INotifyPropertyChanged
    {
        public List<SizeDrink> listSizeDrink { get; set; }
        public SizeDrink _selectedSize { get; set; }
        public SizeDrink SelectedSize
        {
            get { return _selectedSize; }
            set
            {
                if (_selectedSize != value)
                {
                    _selectedSize = value;
                }
            }
        }
        public DetailDrinkViewModel()
        {
            listSizeDrink = GetListSizeDrink().OrderBy(t => t.Value).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public List<SizeDrink> GetListSizeDrink()
        {
            var listSize = new List<SizeDrink>()
            {
                new SizeDrink(){ Key = 1, Value = "M"},
                new SizeDrink(){ Key = 2, Value = "L"},
                new SizeDrink(){ Key = 3, Value = "S"}
            };
            return listSize;
        }
    }
    public class SizeDrink
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
