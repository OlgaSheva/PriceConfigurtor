using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PriceConfigurator.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string mark;
        private string code;
        private string manufacturer;
        private string provider;
        private decimal? priceEUR;
        private decimal? priceBYN;
        private DateTime? lastUpdate;
        private bool? isPriceAutoUpdate;
        private string xPath;
        private int categoryId;
        private Category category;

        public int Id
        { 
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Mark
        {
            get { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged("Mark");
            }
        }

        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        public string Provider
        {
            get { return provider; }
            set
            {
                provider = value;
                OnPropertyChanged("Provider");
            }
        }

        public decimal? PriceWithoutVAT_EUR
        {
            get { return priceEUR; }
            set
            {
                priceEUR = value;
                OnPropertyChanged("PriceWithoutVAT_EUR");
            }
        }

        public decimal? PriceWithoutVAT_BYN
        {
            get { return priceBYN; }
            set
            {
                priceBYN = value;
                OnPropertyChanged("PriceWithoutVAT_BYN");
            }
        }

        public bool? IsPriceAutoUpdate
        {
            get { return isPriceAutoUpdate ?? false; }
            set
            {
                isPriceAutoUpdate = value;
                OnPropertyChanged("IsPriceAutoUpdate");
            }
        }

        public string XPath
        {
            get { return xPath; }
            set
            {
                xPath = value;
                OnPropertyChanged("XPath");
            }
        }

        public int CategoryId { get; private set; }

        public Category ProductCategory
        {
            get { return category; }
            set
            {
                category = value;
                categoryId = value.Id;
                OnPropertyChanged("Category");
            }
        }

        public DateTime? PriceLastUpdate
        {
            get { return lastUpdate.Equals(DateTime.MinValue) ? null : lastUpdate; }
            //get { return lastUpdate.Equals(DateTime.MinValue) ? DateTime.Now : lastUpdate; }
            set
            {
                lastUpdate = value;
                OnPropertyChanged("PriceLastUpdate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
