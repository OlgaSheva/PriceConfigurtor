using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using PriceConfigurator.Model;

namespace PriceConfigurator.WPF.ViewModels
{
    class CategoryViewModel : INotifyPropertyChanged
    {
        //public ObservableCollection<Product> Products { get; set; }
        //public ObservableCollection<Category> Categories { get; set; }

        //public CategoryViewModel()
        //{
        //    Categories = new ObservableCollection<Category>
        //    {
        //        new Category
        //        {
        //            Name = "Выключатели",
        //            Products = new ObservableCollection<Product>
        //            {
        //                new Product
        //                {
        //                    Name = "Выключатель автоматический PL6 С2, 1P",
        //                    Mark = "PL6-C2/1",
        //                    Code = "286528",
        //                    Manufacturer = "Eaton",
        //                    Provider = "lsys",
        //                    IsPriceAutoUpdate = true,
        //                    Url = "https://lsys.by/katalog/oborudovanie_dlya_ustanovki_na_din_reyku/avtomaticheskie_vyklyuchateli/avt_vyklyuchatel_pl6_c2_1_1p_2a_khar_ka_c_6ka_1m.html",
        //                    XPath = "//*[@class=\"prod__info__current-price\"]/span",
        //                    PriceWithoutVAT_EUR = 4.81m,
        //                    PriceWithoutVAT_BYN = 12.76m,
        //                    PriceLastUpdate = DateTime.Now
        //                },
        //                new Product
        //                {
        //                    Name = "Выключатель автоматический PL7 С2, 1P",
        //                    Mark = "PL7-C2/1",
        //                    Code = "262699",
        //                    Manufacturer = "Eaton",
        //                    Provider = "lsys",
        //                    PriceWithoutVAT_EUR = 3.76m,
        //                    PriceWithoutVAT_BYN = 9.92m,
        //                    PriceLastUpdate = DateTime.Now
        //                }
        //            }
        //        },

        //        new Category
        //        {
        //            Name = "Выключатели1",
        //            Products = new ObservableCollection<Product>
        //            {
        //                new Product
        //                {
        //                    Name = "Выключатель автоматический PL6 С2, 1P",
        //                    Mark = "PL6-C2/1",
        //                    Code = "286528",
        //                    Manufacturer = "Eaton",
        //                    Provider = "lsys",
        //                    IsPriceAutoUpdate = true,
        //                    Url = "https://lsys.by/katalog/oborudovanie_dlya_ustanovki_na_din_reyku/avtomaticheskie_vyklyuchateli/avt_vyklyuchatel_pl6_c2_1_1p_2a_khar_ka_c_6ka_1m.html",
        //                    XPath = "//*[@class=\"prod__info__current-price\"]/span",
        //                    PriceWithoutVAT_EUR = 4.81m,
        //                    PriceWithoutVAT_BYN = 12.76m,
        //                    PriceLastUpdate = DateTime.Now
        //                },
        //                new Product
        //                {
        //                    Name = "Выключатель автоматический PL7 С2, 1P",
        //                    Mark = "PL7-C2/1",
        //                    Code = "262699",
        //                    Manufacturer = "Eaton",
        //                    Provider = "lsys",
        //                    PriceWithoutVAT_EUR = 3.76m,
        //                    PriceWithoutVAT_BYN = 9.92m,
        //                    PriceLastUpdate = DateTime.Now
        //                }
        //            }
        //        }

        //    };
        //}

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
