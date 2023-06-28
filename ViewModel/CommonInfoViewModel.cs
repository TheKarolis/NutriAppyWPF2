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
    class CommonInfoViewModel : BindableBase
    {
        DBLogic dbcontext = new DBLogic(); 
        public CommonInfoViewModel() { }
        public CommonInfoViewModel(DBLogic dbContext)
        {
            this.dbcontext = dbContext;
        }

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
