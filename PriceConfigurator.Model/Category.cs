using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PriceConfigurator.Model
{
    /// <summary>
    /// Product category.
    /// </summary>
    public class Category
    {
        private int id;
        private string name;
        private List<Product> productList;

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

        public List<Product> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
