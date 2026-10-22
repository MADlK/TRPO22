using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAD_TPRPO21
{
    public class Device: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged ([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        private int _id;
        public int Id { get=> _id;
            set 
            {
                OnPropertyChanged();
                _id = value;
            }

                }


        private string? _name= null!;
        public string? Name
        { get => _name;
            set
            {
                OnPropertyChanged();
                _name = value;
            }

                 }



        private string? _manufacturer = null!;
        public string? Manufacturer { get => _manufacturer;
            set
            {
                OnPropertyChanged();
                _manufacturer = value;
            }
                }


        private decimal? _price = new();
        public decimal? Price { get => _price;
            set
            {
                OnPropertyChanged();
                _price = value;
            }
                }



        private int? _quantity;
        public int? Quantity { get=>_quantity; 
            set
            {
                OnPropertyChanged();
                _quantity = value;
            }
                }

        private bool? _isacive;
        public bool? IsActive { get=> _isacive;
            set 
            {
                OnPropertyChanged();
                _isacive = value;
            }
        }
    }
}
