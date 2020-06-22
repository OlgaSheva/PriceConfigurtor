using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MvvmHelpers;

using PriceConfigurator.DataAccess.Models.CategoryModel;
using PriceConfigurator.DataAccess.Models.ProductModel;
using PriceConfigurator.Services.CategoryManagement;
using PriceConfigurator.Services.ProductManagement;

namespace PriceConfigurator.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private Category _selectedCategory;
        private Product _selectedProduct;

        private AsyncCommand<List<Category>> _getCategoryCommand;
        private AsyncCommand<Category> _addCategoryCommand;
        private AsyncCommand<Category> _deleteCategoryCommand;
        private AsyncCommand<Category> _updateCategoryCommand;
        private List<string> _categoryNames;

        private AsyncCommand<List<Product>> _getProductCommand;
        private AsyncCommand<Product> _addProductCommand;
        private AsyncCommand<Product> _removeProductCommand;

        public MainWindowViewModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

            GroupedProducts = new ListCollectionView(_productService.GetProductsAsync().Result);
            GroupedProducts.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            CategoryNames = new List<string>(_categoryService.GetCategoryNamesAsync().Result);
        }

        #region Product

        public ICollectionView GroupedProducts { get; private set; }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public AsyncCommand<List<Product>> GetCommand
        {
            get
            {
                return _getProductCommand ??
                    (_getProductCommand = new AsyncCommand<List<Product>>(async (c) =>
                    {
                        await _productService.GetProductsAsync();
                    }));
            }
        }

        #endregion

        #region Category

        public List<string> CategoryNames
        {
            get { return _categoryNames; }
            set
            {
                _categoryNames = value;
                OnPropertyChanged();
            }
        }
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public AsyncCommand<List<Category>> GetCategoryCommand
        {
            get
            {
                return _getCategoryCommand ??
                    (_getCategoryCommand = new AsyncCommand<List<Category>>(async (c) =>
                    {
                        await _categoryService.GetCategoriesAsync();
                    }));
            }
        }

        public AsyncCommand<Category> AddCategoryCommand
        {
            get
            {
                return _addCategoryCommand ??
                    (_addCategoryCommand = new AsyncCommand<Category>(async (category) =>
                    {
                        await _categoryService.CreateCategoryAsync(category);
                        SelectedCategory = category;
                    }));
            }
        }

        public AsyncCommand<Category> DeleteCategoryCommand
        {
            get
            {
                return _deleteCategoryCommand ??
                    (_deleteCategoryCommand = new AsyncCommand<Category>(async (selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Category category = selectedItem as Category;
                        await _categoryService.DeleteCategoryAsync(category.Id);
                    }));
            }
        }

        public AsyncCommand<Category> UpdateCategoryCommand
        {
            get
            {
                return _updateCategoryCommand ??
                    (_updateCategoryCommand = new AsyncCommand<Category>(async (category) =>
                    {
                        if (category == null) return;
                        await _categoryService.UpdateCategoryAsync(category);
                    }));
            }
        }

        #endregion

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
