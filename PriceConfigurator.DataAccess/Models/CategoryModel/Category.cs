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
    //[Table("Categories")]
    public class Category : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private bool _isDeleted;
        private bool _isUpdated;

        /// <summary>
        /// Gets or sets a category identifier.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// Gets or sets a category name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a category is deleted.
        /// </summary>
        public bool IsDeleted
        {
            get { return _isDeleted; }
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
        /// Gets or sets a value indicating whether a category is updated.
        /// </summary>
        public bool IsUpdated
        {
            get { return _isUpdated; }
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
    }
}
