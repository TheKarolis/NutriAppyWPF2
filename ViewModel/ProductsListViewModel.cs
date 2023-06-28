using NutriAppyWPF2.DB_Logic;
using NutriAppyWPF2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.ViewModel
{
    class ProductsListViewModel : BindableBase
    {
        public MyICommand<string> AddProductCommand { get; private set; }

        public ProductsListViewModel()
        {
            Products = new ObservableCollection<Product>();
            AddProductCommand = new MyICommand<string>(AddProduct);
        }

        private void AddProduct(string data)
        {
            //To be implemented
            OnPropertyChanged(nameof(Products));
        }

        /// <summary>
        /// Temporary method for testing purposes
        /// </summary>
        public void loadExmplData()
        {
            Products = new ObservableCollection<Product>();
            List<Nutrient> nutrients = new List<Nutrient>();
            nutrients.Add(new Nutrient("Calories", 365, "Cal"));
            nutrients.Add(new Nutrient("Carbohydrates", 28, "g"));
            Products.Add(new Product("Rice", "boiled", nutrients));
            OnPropertyChanged(nameof(Products));
        }
        public ObservableCollection<Product> Products { get; set; }
           = new ObservableCollection<Product>();

    }
}
