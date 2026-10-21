using Accessibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    public partial class DevicePage :Page
    {
        public HttpClient HC = new HttpClient();
        private ObservableCollection<Device> _Devices = new();
        public ObservableCollection<Device> Devices
        {
            get { return _Devices; }
            set { _Devices = value; }
        }


        public DevicePage ()
        {
            HC.BaseAddress = new Uri("https://localhost:7153/");
            InitializeComponent();
            GetProductsAsync();
        }

        public async void GetProductsAsync ()
        {
            _Devices.Clear();
            var response =
                await HC.GetFromJsonAsync<List<Device>>("api/v1/Dievice");


            if (response != null)

            {
                foreach (var c in response)
                {
                    Devices.Add(c);
                    
                }
            }else
            {
                MessageBox.Show($"Ошибка");
            }
        }
    }
}
