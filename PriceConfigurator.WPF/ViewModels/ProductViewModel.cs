//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Windows.Data;

//using PriceConfigurator.DataAccess.Models.CategoryModel;
//using PriceConfigurator.DataAccess.Models.ProductModel;
//using PriceConfigurator.Services.ProductManagement;

//namespace PriceConfigurator.WPF.ViewModels
//{
//    internal class ProductViewModel : INotifyPropertyChanged
//    {
//        private IProductService _service;
//        private Product _selectedProduct;

//        private AsyncCommand<List<Product>> _getCommand;
//        private AsyncCommand<Product> _addCommand;
//        private AsyncCommand<Product> _removeCommand;

//        public ProductViewModel(IProductService productService)
//        {
//            _service = productService ?? throw new ArgumentNullException(nameof(productService));
//            //context.Products.Add(new Product
//            //{
//            //    ProductCategory = new Category { Id = 1, Name = "Выключатели" },
//            //    Name = "Выключатель автоматический PL6 С2, 1P",
//            //    Mark = "PL6-C2/1",
//            //    Code = "286528",
//            //    Manufacturer = "Eaton",
//            //    Provider = "lsys",
//            //    IsPriceAutoUpdate = true,
//            //    Url = "https://lsys.by/katalog/oborudovanie_dlya_ustanovki_na_din_reyku/avtomaticheskie_vyklyuchateli/avt_vyklyuchatel_pl6_c2_1_1p_2a_khar_ka_c_6ka_1m.html",
//            //    XPath = "//*[@class=\"prod__info__current-price\"]/span",
//            //    PriceWithoutVAT_EUR = 4.81m,
//            //    PriceWithoutVAT_BYN = 12.76m,
//            //    PriceLastUpdate = DateTime.Now
//            //});
//            //context.SaveChangesAsync();

//            //context.Products.Add(new Product
//            //{
//            //    ProductCategory = new Category { Id = 2, Name = "Выключатели" },
//            //    Name = "Выключатель автоматический PL7 С2, 1P",
//            //    Mark = "PL7-C2/1",
//            //    Code = "262699",
//            //    Manufacturer = "Eaton",
//            //    Provider = "lsys",
//            //    PriceWithoutVAT_EUR = 3.76m,
//            //    PriceWithoutVAT_BYN = 9.92m,
//            //    PriceLastUpdate = DateTime.Now
//            //});
//            //context.SaveChangesAsync();

//            //Products = CollectionViewSource.GetDefaultView(context.Products.ToList());

//            GroupedProducts = new ListCollectionView(_service.GetProductsAsync().Result);
//            GroupedProducts.GroupDescriptions.Add(new PropertyGroupDescription("Category"));            
//        }

//        //public ICollectionView Products { get; private set; }

//        public ICollectionView GroupedProducts { get; private set; }

//        public Product SelectedProduct
//        {
//            get { return _selectedProduct; }
//            set
//            {
//                _selectedProduct = value;
//                OnPropertyChanged("SelectedProduct");
//            }
//        }

//        public AsyncCommand<List<Product>> GetCommand
//        {
//            get
//            {
//                return _getCommand ??
//                    (_getCommand = new AsyncCommand<List<Product>>(async (c) =>
//                    {
//                        await _service.GetProductsAsync();
//                    }));
//            }
//        }

//        ///// <summary>
//        ///// Add product command.
//        ///// </summary>
//        //public RelayCommand AddCommand
//        //{
//        //    get
//        //    {
//        //        return addCommand ??
//        //          (addCommand = new RelayCommand(obj =>
//        //          {
//        //              Product product = new Product();
//        //              Products.Insert(0, product);
//        //              SelectedProduct = product;
//        //          }));
//        //    }
//        //}

//        ///// <summary>
//        ///// Remove product command.
//        ///// </summary>
//        //public RelayCommand RemoveCommand
//        //{
//        //    get
//        //    {
//        //        return removeCommand ??
//        //          (removeCommand = new RelayCommand(obj =>
//        //          {
//        //              Product product = obj as Product;
//        //              if (product != null)
//        //              {
//        //                  Products.Remove(product);
//        //              }
//        //          },
//        //         (obj) => Products.Count > 0));
//        //    }
//        //}

//        // Implement INotifyPropertyChanged interface.
//        public event PropertyChangedEventHandler PropertyChanged;

//        public void OnPropertyChanged([CallerMemberName] string prop = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
//        }
//    }
//}
