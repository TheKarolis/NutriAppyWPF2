using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.ViewModel
{
    class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            LeftViewNavCommand = new MyICommand<string>(OnLeftNav);

            CurrentViewModel = NutrientViewModel;
            LeftViewModel = NutrientViewModel;
        }

        private CommonInfoViewModel _CommonInfoViewModel = new CommonInfoViewModel();
        private NutrientViewModel _NutrientViewModel = new NutrientViewModel();
        private ProductsListViewModel _ProductsListViewModel = new ProductsListViewModel();

        private BindableBase _CurrentViewModel;
        private BindableBase _LeftViewModel;

        public NutrientViewModel NutrientViewModel
        {
            get => _NutrientViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }
        public BindableBase LeftViewModel
        {
            get { return _LeftViewModel; }
            set { SetProperty(ref _LeftViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<string> LeftViewNavCommand { get; private set; }
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "Nutrients":
                    CurrentViewModel = _NutrientViewModel;
                    NutrientViewModel.LoadExampleNutrients();
                    break;
                case "CommonInfo":
                default:
                    CurrentViewModel = _CommonInfoViewModel;
                    break;
            }
        }

        private void OnLeftNav (string destination)
        {
            switch (destination)
            {
                case "Nutrients":
                    LeftViewModel = _NutrientViewModel;
                    break;
                case "CommonInfo":
                default:
                    LeftViewModel = _CommonInfoViewModel;
                    break;
            }
        }

    }
}
