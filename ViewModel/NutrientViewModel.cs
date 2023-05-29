using NutriAppyWPF2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutriAppyWPF2.ViewModel
{
    class NutrientViewModel : BindableBase
    {
        public int CHCKINFO;
        public ObservableCollection<Nutrient> Nutrients { get; set; }
            = new ObservableCollection<Nutrient>();


        public NutrientViewModel()
        {

        }

        public void LoadExampleNutrients()
        {
            Nutrients.Add(new Nutrient("Calories", 242, "Cal"));
            Nutrients.Add(new Nutrient("Fat", 14, "g"));
            Nutrients.Add(new Nutrient("Carbohydrates", 0, "g"));
            Nutrients.Add(new Nutrient("Iron", 0.9m, "mg"));
            Nutrients.Add(new Nutrient("Zinc", 1.5m, "mg"));
        }
    }
}
