//using PriceConfigurator.DataAccess.Models.CategoryModel;
//using PriceConfigurator.Services.CategoryManagement;
//using System;

//namespace PriceConfigurator.WPF.ViewModels
//{
//    public class CategoryWindowViewModel
//    {
//        private readonly ICategoryService _categoryService;
//        private AsyncCommand<Category> _addCategoryCommand;

//        public CategoryWindowViewModel(ICategoryService categoryService)
//        {
//            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
//        }

//        //public AsyncCommand<Category> AddCategoryCommand
//        //{
//        //    get
//        //    {
//        //        return _addCategoryCommand ??
//        //            (_addCategoryCommand = new AsyncCommand<Category>(async (category) =>
//        //            {
//        //                await _categoryService.CreateCategoryAsync(category);
//        //            }));
//        //    }
//        //}
//    }
//}
