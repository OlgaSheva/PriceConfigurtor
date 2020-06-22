using System;
using System.Windows;
using PriceConfigurator.DataAccess.Models.CategoryModel;
using PriceConfigurator.Services.CategoryManagement;

namespace PriceConfigurator.WPF
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private readonly ICategoryService _service;

        public CategoryWindow(ICategoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            InitializeComponent();
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            var category = new Category { Name = categoryBox.Text };
            await _service.CreateCategoryAsync(category);
            
            this.DialogResult = true;
        }
    }
}
