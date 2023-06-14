using NutriAppyWPF2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.ViewModel
{
    class CommonInfoViewModel : BindableBase
    {
        public CommonInfoViewModel() { }

        public ObservableCollection<Nutrient> Nutrients { get; private set; }
            = new ObservableCollection<Nutrient>();

        public CommonInfoViewModel(ObservableCollection<Nutrient> Nutrients)
        {
            this.Nutrients = Nutrients;
        }

        public void updateNutrients(List<Nutrient> NutrientsNew)
        {
            this.Nutrients = new ObservableCollection<Nutrient>(NutrientsNew);
        }
    }
}
