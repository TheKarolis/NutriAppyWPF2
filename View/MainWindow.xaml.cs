using NutriAppyWPF2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NutriAppyWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //CommonInfoViewModel commonInfoViewModel = new CommonInfoViewModel(2);
            //NutrientViewModel nutrientViewModel = new NutrientViewModel(2);
            //MainViewModel mainViewModel = new MainViewModel(commonInfoViewModel, nutrientViewModel);
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            //CommonInfoControl.DataContext = mainViewModel.CommonInfoViewModel;
            //NutrientControl.DataContext = mainViewModel.NutrientViewModel;

        }

        //private void NutrientViewControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    NutrientViewModel nutrientViewModel = new NutrientViewModel();
        //    nutrientViewModel.LoadExampleNutrients();

        //    NutrientViewControl.DataContext = nutrientViewModel;
        //}
    }
}
