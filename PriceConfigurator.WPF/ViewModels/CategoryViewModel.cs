//using PriceConfigurator.DataAccess.Models.CategoryModel;
//using PriceConfigurator.Services.CategoryManagement;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Windows.Documents;

//namespace PriceConfigurator.WPF.ViewModels
//{
//    internal class CategoryViewModel : INotifyPropertyChanged
//    {
//        private readonly ICategoryService _service;
//        private Category _selectedCategory;

//        private AsyncCommand<List<Category>> _getCommand;
//        private AsyncCommand<Category> _addCommand;
//        private AsyncCommand<Category> _deleteCommand;
//        private AsyncCommand<Category> _updateCommand;

//        public CategoryViewModel(ICategoryService service)
//        {
//            _service = service ?? throw new ArgumentNullException(nameof(service));
//        }

//        public Category SelectedCategory
//        {
//            get { return _selectedCategory; }
//            set
//            {
//                _selectedCategory = value;
//                OnPropertyChanged("SelectedCategory");
//            }
//        }

//        public AsyncCommand<List<Category>> GetCommand
//        {
//            get
//            {
//                return _getCommand ??
//                    (_getCommand = new AsyncCommand<List<Category>>(async (c) =>
//                    {
//                        await _service.GetCategoriesAsync();
//                    }));
//            }
//        }

//        public AsyncCommand<Category> AddCommand
//        {
//            get
//            {
//                return _addCommand ??
//                    (_addCommand = new AsyncCommand<Category>(async (category) =>
//                    {
//                        await _service.CreateCategoryAsync(category);
//                        SelectedCategory = category;
//                    }));
//            }
//        }

//        public AsyncCommand<Category> DeleteCommand
//        {
//            get
//            {
//                return _deleteCommand ??
//                    (_deleteCommand = new AsyncCommand<Category>(async (selectedItem) =>
//                    {
//                        if (selectedItem == null) return;
//                        Category category = selectedItem as Category;
//                        await _service.DeleteCategoryAsync(category.Id);
//                    }));
//            }
//        }

//        public AsyncCommand<Category> UpdateCommand
//        {
//            get
//            {
//                return _updateCommand ??
//                    (_updateCommand = new AsyncCommand<Category>(async (category) =>
//                    {
//                        if (category == null) return;
//                        await _service.UpdateCategoryAsync(category);
//                    }));
//            }
//        }

//        // Implement INotifyPropertyChanged interface.
//        public event PropertyChangedEventHandler PropertyChanged;
//        public void OnPropertyChanged([CallerMemberName] string prop = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
//        }
//    }
//}
