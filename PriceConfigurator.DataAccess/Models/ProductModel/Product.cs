using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using PriceConfigurator.DataAccess.Models.CategoryModel;

namespace PriceConfigurator.DataAccess.Models.ProductModel
{
    //[Table("Products")]
    public class Product : INotifyPropertyChanged, IEditableObject
    {
        //const int PRICE_PRECISION = 2;

        private int _id;
        private string _name;
        private string _mark;
        private string _code;
        private string _manufacturer;
        private string _provider;
        private decimal? _priceEUR;
        private decimal? _priceBYN;
        private DateTime? _priceLastUpdate;
        private bool? _isPriceAutoUpdate;
        private string _url;
        private string _xPath;
        private Category _productCategory;
        private bool? _isDeleted;
        private bool? _isUpdated;

        // Data for undoing canceled edits.
        private Product temp_Product = null;
        private bool m_Editing = false;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Mark
        {
            get { return _mark; }
            set
            {
                if (value != _mark)
                {
                    _mark = value;
                    OnPropertyChanged("Mark");
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (value != _code)
                {
                    _code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (value != _manufacturer)
                {
                    _manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }

        public string Provider
        {
            get { return _provider; }
            set
            {
                if (value != _provider)
                {
                    _provider = value;
                    OnPropertyChanged("Provider");
                }
            }
        }

        public decimal? PriceWithoutVAT_EUR
        {
            get { return _priceEUR; }
            set
            {
                _priceEUR = value;
                _priceLastUpdate = DateTime.Now;
                OnPropertyChanged("PriceWithoutVAT_EUR");
            }
        }

        public decimal? PriceWithoutVAT_BYN
        {
            get { return _priceBYN; }
            set
            {
                _priceBYN = value;
                _priceLastUpdate = DateTime.Now;
                OnPropertyChanged("PriceWithoutVAT_BYN");
            }
        }

        public bool? IsPriceAutoUpdate
        {
            get { return _isPriceAutoUpdate ?? false; }
            set
            {
                if (value != _isPriceAutoUpdate)
                {
                    _isPriceAutoUpdate = value;
                    OnPropertyChanged("IsPriceAutoUpdate");
                }
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                if (value != _url)
                {
                    _url = value;
                    OnPropertyChanged("Url");
                }
            }
        }

        public string XPath
        {
            get { return _xPath; }
            set
            {
                if (value != _xPath)
                {
                    _xPath = value;
                    OnPropertyChanged("XPath");
                }
            }
        }

        /// <summary>
        /// Product category id.
        /// </summary>
        public int? CategoryId { get; private set; }

        /// <summary>
        /// Product category name.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Product category.
        /// </summary>
        public Category ProductCategory
        {
            get { return _productCategory; }
            set
            {
                if (value != _productCategory)
                {
                    _productCategory = value;
                    this.Category = value.Name;
                    this.CategoryId = value.Id;
                    OnPropertyChanged("ProductCategory");
                }
            }
        }

        public DateTime? PriceLastUpdate
        {
            get { return _priceLastUpdate.Equals(DateTime.MinValue) ? null : _priceLastUpdate; }
            //get { return lastUpdate.Equals(DateTime.MinValue) ? DateTime.Now : lastUpdate; }
            set
            {
                _priceLastUpdate = value;
                OnPropertyChanged("PriceLastUpdate");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool? IsDeleted
        {
            get { return _isDeleted ?? false; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    OnPropertyChanged("IsDeleted");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a product is updated.
        /// </summary>
        public bool? IsUpdated
        {
            get { return _isUpdated ?? false; }
            set
            {
                if (_isUpdated != value)
                {
                    _isUpdated = value;
                    OnPropertyChanged("IsUpdated");
                }
            }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Product = this.MemberwiseClone() as Product;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.Name = temp_Product.Name;
                this.Mark = temp_Product.Mark;
                this.Code = temp_Product.Code;
                this.Manufacturer = temp_Product.Manufacturer;
                this.Provider = temp_Product.Provider;
                this.PriceWithoutVAT_EUR = temp_Product.PriceWithoutVAT_EUR;
                this.PriceWithoutVAT_BYN = temp_Product.PriceWithoutVAT_BYN;
                this.PriceLastUpdate = temp_Product.PriceLastUpdate;
                this.IsPriceAutoUpdate = temp_Product.IsPriceAutoUpdate;
                this.Url = temp_Product.Url;
                this.XPath = temp_Product.XPath;
                this.CategoryId = temp_Product.CategoryId;
                this.ProductCategory = temp_Product.ProductCategory;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Product = null;
                m_Editing = false;
            }
        }
    }
}
