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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage :Page, INotifyPropertyChanged
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
        public EditPage (Device d)
        {
            _d = d;
            InitializeComponent();
        }


        public async void PatchAsJsonAsync ()
        {
            HttpResponseMessage response = await MainWindow.HC.PatchAsJsonAsync(
                $"api/v1/Dievice/{device.Id}",
                device
                );
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Товар Успешно изменен");
            else
                MessageBox.Show($"Товар не изменен {response.StatusCode}");


        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            PatchAsJsonAsync();
        }

        private void Button_Click_1 (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DevicePage());
        }
    }
}
