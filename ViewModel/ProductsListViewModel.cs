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
        public ObservableCollection<Product> Products { get; set; }
           = new ObservableCollection<Product>();

    }
}
