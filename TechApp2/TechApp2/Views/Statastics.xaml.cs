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

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statastics : ContentPage
    {       
        public Statastics()
        {
            InitializeComponent();
            GetStats();        
           
        }   
        private async void GetStats()
        {
           TechAppStatsModel statsReponse = new TechAppStatsModel();
           HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/TechAPPStats");
            var response = await httpClient.GetStringAsync(Url);
            statsReponse = JsonConvert.DeserializeObject<TechAppStatsModel>(response);
            this.BindingContext = statsReponse;
        }        
    }
}