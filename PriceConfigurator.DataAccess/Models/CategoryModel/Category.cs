using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using PriceConfigurator.DataAccess.Models.ProductModel;

namespace PriceConfigurator.DataAccess.Models.CategoryModel
{
    /// <summary>
    /// Product category.
    /// </summary>
    [Table("Category")]
    public class Category : ObservableCollection<Product>, INotifyPropertyChanged
    {
        private int id;
        private string name;
        //private ObservableCollection<Product> products;

        /// <summary>
        /// Category id.
        /// </summary>
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name 
        {
            get { return name; }
            set
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        //public ObservableCollection<Product> Products
        //{
        //    get { return products; }
        //    set
        //    {
        //        products = value;
        //        OnPropertyChanged("Products");
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
