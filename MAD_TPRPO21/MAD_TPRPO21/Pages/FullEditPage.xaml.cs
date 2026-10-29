using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для FullEditPage.xaml
    /// </summary>
    public partial class FullEditPage :Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged ([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));



        }
        private Device _d = new();
        public Device device
        {
            get { return _d; }
            set
            {
                OnPropertyChanged();
                _d = value;
            }
        }
        public int ID;
        public FullEditPage (Device d)
        {
            ID = d.Id;
            InitializeComponent();
        }
        public async void Put ()
        {
            HttpResponseMessage response = await MainWindow.HC.PutAsJsonAsync(
                $"api/v1/Dievice/{ID}",
                device
                );
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Товар Успешно изменен");
            else
                MessageBox.Show($"Товар не изменен {response.StatusCode}");


        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(device.Name) ||
                 device.Quantity == null ||
                 device.IsActive == null ||
                 device.Price == null
                 )
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            Put();
            NavigationService.GoBack();
        }

        private void Button_Click_1 (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DevicePage());
        }
    }
}
