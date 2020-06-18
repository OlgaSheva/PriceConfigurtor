using CommonMark.Syntax;
using PerseusLibS.Workflow;
using PriceConfigurator.DataAccess;
using PriceConfigurator.DataAccess.Models.ProductModel;
using PriceConfigurator.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace PriceConfigurator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public MainWindow(IProductContext productContext)
        {
            InitializeComponent();
            this.DataContext = new ProductViewModel(productContext);
        }  
        
        //public void Save_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    using var context = new PriceConfiguratorContext();            
        //    foreach (var row in ProductsGrid.Items)
        //    {
        //        Product product = row as Product;
        //        if (product != null)
        //        {

        //        }
        //    }
        //}
    }
}