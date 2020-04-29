using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assets : ContentPage, INotifyPropertyChanged
    {        
        public Assets()
        {
            InitializeComponent();
        }
        private async void  GetAsset(string ssn)
        {
            AssetViewModel assetResponse = new AssetViewModel(); //15097672             
            HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementService/inventorycontrol/assets/ssnlookup/{ssn}");
            var response = await httpClient.GetStringAsync(Url); 
            assetResponse = JsonConvert.DeserializeObject<AssetViewModel>(response);
            this.BindingContext = assetResponse;        
        }
        private void btnSearch_Clicked(object sender, EventArgs e)
        {  
            GetAsset(txtSSN.Text.ToString());
        }        
    }
}