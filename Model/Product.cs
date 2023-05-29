using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.Model
{
    internal class Product : INotifyPropertyChanged
    {
        private string name;
        private string description = string.Empty;
        private List<Nutrient> nutrients = new List<Nutrient>();

        public Product(string name, string description, List<Nutrient> nutrients)
        {
            this.name = name;
            this.description = description;
            this.nutrients = nutrients;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
