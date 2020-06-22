using CommonMark.Syntax;
using PerseusLibS.Workflow;
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

using PriceConfigurator.Services.CategoryManagement;
using PriceConfigurator.Services.ProductManagement;
using PriceConfigurator.WPF.ViewModels;
using PriceConfigurator.DataAccess.Models.CategoryModel;

namespace PriceConfigurator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICategoryService _categoryService;

        public MainWindow(IProductService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;

            InitializeComponent();

            this.DataContext = new MainWindowViewModel(productService, categoryService);
        }

        private void Add_Category_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow category = new CategoryWindow(_categoryService);

            if (category.ShowDialog() == true)
            {
                MessageBox.Show("Категория добавлена");
            }
        }

        //private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var comboBox = sender as ComboBox;
        //    comboBox.ItemsSource = CategoryNames;
        //    comboBox.SelectedIndex = 0;
        //}
    }
}