using Accessibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAD_TPRPO21.Pages
{
    /// <summary>
    /// Логика взаимодействия для DevicePage.xaml
    /// </summary>
    public partial class DevicePage :Page, INotifyPropertyChanged
    {
        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                OnPropertyChanged();
                _manufacturer = value;
                FilterLV();
            }
        }

        private decimal _minprice = new();
        public decimal MinPrice
        {
            get { return _minprice; }
            set
            {
                OnPropertyChanged();
                _minprice = value;
                FilterLV();
            }
        }

        private Device _select = new();
        public Device select
        {
            get => _select;
            set
            {
                OnPropertyChanged();
                _select = value;
            }
            

        }
        public async void FilterLV()
        {
            _Devices.Clear();
            List<Device> response = new();
            if (!String.IsNullOrEmpty(Manufacturer) && MinPrice > 0)
            {
                var resp = await MainWindow.HC.GetFromJsonAsync<List<Device>>
                ($"api/v1/Dievice?Manufacturer={Manufacturer}&minPrice={MinPrice}");
                response = resp;
            } else if (MinPrice > 0)
            {
                var resp = await MainWindow.HC.GetFromJsonAsync<List<Device>>
                ($"api/v1/Dievice?minPrice={MinPrice}");
                response = resp;
            } else if (!String.IsNullOrEmpty(Manufacturer))
            {
                var resp = await MainWindow.HC.GetFromJsonAsync<List<Device>>
               ($"api/v1/Dievice?Manufacturer={Manufacturer}");
                response = resp;
            }else
                GetProductsAsync();



            if (response != null)

            {
                foreach (var c in response)
                {
                    Devices.Add(c);

                }
            } else
            {
                MessageBox.Show($"Ошибка");
            }
        }

        private ObservableCollection<Device> _Devices = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged ([CallerMemberName] string? propname =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public ObservableCollection<Device> Devices
        {
            get { return _Devices; }
            set { _Devices = value; }
        }


        public DevicePage ()
        {

            InitializeComponent();
            GetProductsAsync();
        }

        public async void GetProductsAsync ()
        {
            _Devices.Clear();
            var response =
                await MainWindow.HC.GetFromJsonAsync<List<Device>>("api/v1/Dievice");


            if (response != null)

            {
                foreach (var c in response)
                {
                    Devices.Add(c);

                }
            } else
            {
                MessageBox.Show($"Ошибка");
            }
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            if(select.Name == null)
            {
                MessageBox.Show("Сначало нужно выбрать");
                return;
            }
            NavigationService.Navigate(new EditPage(select));
        }

        private async void Button_Click_1 (object sender, RoutedEventArgs e)
        {
            if (select.Name == null)
            {
                MessageBox.Show("Сначало нужно выбрать");
                return;
            }
            HttpResponseMessage response = await MainWindow.HC.DeleteAsync(@$"api/v1/Dievice/{select.Id}");
            FilterLV();
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Успешно удален");
            else
                MessageBox.Show($"Не удален {response.StatusCode}");
        }

        private void Button_Click_2 (object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new AddPage());
        }

        private void Button_Click_3 (object sender, RoutedEventArgs e)
        {
            if(select == null|| select.Name == null)
            {
                MessageBox.Show("Сначало надо выбрать");
                return;
            }
                
            NavigationService.Navigate(new FullEditPage(select));
        }
    }
}
