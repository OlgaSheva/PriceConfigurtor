using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;

using PriceConfigurator.DataAccess.Models.CategoryModel;
using PriceConfigurator.DataAccess.Models.ProductModel;

namespace PriceConfigurator.WPF.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        //private Product selectedProduct;
        //private RelayCommand addCommand;
        //private RelayCommand removeCommand;
        //private RelayCommand doubleCommand;

        //public ObservableCollection<Product> Products { get; set; }

        public ICollectionView Products { get; private set; }

        public ICollectionView GroupedProducts { get; private set; }

        //public Product SelectedProduct
        //{
        //    get { return selectedProduct; }
        //    set
        //    {
        //        selectedProduct = value;
        //        OnPropertyChanged("SelectedProduct");
        //    }
        //}

        public ProductViewModel(IProductContext context)
        {
            context.Products.Add(new Product
            {
                ProductCategory = new Category { Id=1, Name = "Выключатели" },
                Name = "Выключатель автоматический PL6 С2, 1P",
                Mark = "PL6-C2/1",
                Code = "286528",
                Manufacturer = "Eaton",
                Provider = "lsys",
                IsPriceAutoUpdate = true,
                Url = "https://lsys.by/katalog/oborudovanie_dlya_ustanovki_na_din_reyku/avtomaticheskie_vyklyuchateli/avt_vyklyuchatel_pl6_c2_1_1p_2a_khar_ka_c_6ka_1m.html",
                XPath = "//*[@class=\"prod__info__current-price\"]/span",
                PriceWithoutVAT_EUR = 4.81m,
                PriceWithoutVAT_BYN = 12.76m,
                PriceLastUpdate = DateTime.Now
            });
            context.SaveChangesAsync();

            context.Products.Add(new Product
            {
                ProductCategory = new Category { Id=2, Name = "Выключатели" },
                Name = "Выключатель автоматический PL7 С2, 1P",
                Mark = "PL7-C2/1",
                Code = "262699",
                Manufacturer = "Eaton",
                Provider = "lsys",
                PriceWithoutVAT_EUR = 3.76m,
                PriceWithoutVAT_BYN = 9.92m,
                PriceLastUpdate = DateTime.Now
            });
            context.SaveChangesAsync();

            Products = CollectionViewSource.GetDefaultView(context.Products.ToList());

            GroupedProducts = new ListCollectionView(context.Products.ToList());
            GroupedProducts.GroupDescriptions.Add(new PropertyGroupDescription("Category"));            
        }

        ///// <summary>
        ///// Add product command.
        ///// </summary>
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {
        //              Product product = new Product();
        //              Products.Insert(0, product);
        //              SelectedProduct = product;
        //          }));
        //    }
        //}

        ///// <summary>
        ///// Remove product command.
        ///// </summary>
        //public RelayCommand RemoveCommand
        //{
        //    get
        //    {
        //        return removeCommand ??
        //          (removeCommand = new RelayCommand(obj =>
        //          {
        //              Product product = obj as Product;
        //              if (product != null)
        //              {
        //                  Products.Remove(product);
        //              }
        //          },
        //         (obj) => Products.Count > 0));
        //    }
        //}

        //public RelayCommand DoubleCommand
        //{
        //    get
        //    {
        //        return doubleCommand ??= new RelayCommand(obj =>
        //        {
        //            Product product = obj as Product;
        //            if (product != null)
        //            {
        //                Product productCopy = new Product
        //                {
        //                    Name = product.Name,
        //                    Mark = product.Mark,
        //                    Code = product.Code,
        //                    Manufacturer = product.Manufacturer,
        //                    Provider = product.Provider,
        //                    PriceWithoutVAT_EUR = product.PriceWithoutVAT_EUR,
        //                    PriceWithoutVAT_BYN = product.PriceWithoutVAT_BYN,
        //                    PriceLastUpdate = DateTime.Now
        //                };
        //                Products.Insert(0, productCopy);
        //            }
        //        });
        //    }
        //}

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
