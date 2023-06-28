using NutriAppyWPF2.DB_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NutriAppyWPF2.Model;
using System.Threading.Tasks;

namespace NutriAppyWPF2.ViewModel
{
    class MainViewModel : BindableBase
    {
        private CommonInfoViewModel _CommonInfoViewModel = new CommonInfoViewModel();
        private NutrientViewModel _NutrientViewModel = new NutrientViewModel();
        private ProductsListViewModel _ProductsListViewModel = new ProductsListViewModel();

        private List<Product> PossibleProducts = new List<Product>();

        private BindableBase _RightViewModel;
        private BindableBase _LeftViewModel;

        /// <summary>
        /// Database logic
        /// </summary>
        DBLogic dbContext = new DBLogic();

        public MainViewModel()
        {
            dbContext = new DBLogic();
            NavCommand = new MyICommand<string>(OnNav);
            LeftViewNavCommand = new MyICommand<string>(OnLeftNav);

            RightViewModel = ProductsListViewModel;
            LeftViewModel = CommonInfoViewModel;
            ProductsListViewModel.loadExmplData();

            AddProductsFromDb();
        }

        public CommonInfoViewModel CommonInfoViewModel
        {
            get => _CommonInfoViewModel;
        }
        public NutrientViewModel NutrientViewModel
        {
            get => _NutrientViewModel;
        }
        public ProductsListViewModel ProductsListViewModel
        {
            get => _ProductsListViewModel;
        }

        /// <summary>
        /// For the right side of window
        /// </summary>
        public BindableBase RightViewModel
        {
            get { return _RightViewModel; }
            set { SetProperty(ref _RightViewModel, value); }
        }
        /// <summary>
        /// For the left side of window
        /// </summary>
        public BindableBase LeftViewModel
        {
            get { return _LeftViewModel; }
            set { SetProperty(ref _LeftViewModel, value); }
        }

        /// <summary>
        /// Commands for changing controls in the future
        /// </summary>
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<string> LeftViewNavCommand { get; private set; }
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "Nutrients":
                    RightViewModel = ProductsListViewModel;
                    ProductsListViewModel.loadExmplData();
                    break;
                case "CommonInfo":
                default:
                    RightViewModel = _CommonInfoViewModel;
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

        /// <summary>
        /// Getting all prerecorded products from database
        /// </summary>
        private void AddProductsFromDb()
        {
            PossibleProducts = dbContext.ReadAllPossibleProducts();
        }
    }
}
