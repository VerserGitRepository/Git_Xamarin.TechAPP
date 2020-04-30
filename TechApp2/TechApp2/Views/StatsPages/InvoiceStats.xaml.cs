using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.StatsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceStats : ContentPage
    {
        public InvoiceStats()
        {
            InitializeComponent();
            GetInvoiceStats();
        }
        private async void GetInvoiceStats()
        {
            var statsReponse = new TechAppStatsModel();
            HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/InvoiceStats");
            var response = await httpClient.GetStringAsync(Url);
            statsReponse = JsonConvert.DeserializeObject<TechAppStatsModel>(response);
            this.BindingContext = statsReponse;
        }
    }
}