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
        private List<Nutrient> nutrients;

        public Product() { }
        public Product(string name, string description, List<Nutrient> nutrients = null)
        {
            nutrients = new List<Nutrient>();
            this.name = name;
            this.description = description;
            this.nutrients = nutrients;
        }

        public void addNutrient(Nutrient nutrientToAdd)
        {
            nutrients.Add(nutrientToAdd);
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
