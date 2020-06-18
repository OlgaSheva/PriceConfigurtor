using MvvmHelpers;
using PriceConfigurator.DataAccess.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceConfigurator.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IProductContext _context;

        public MainWindowViewModel(IProductContext context)
        {
            _context = context;            
        }
    }
}
