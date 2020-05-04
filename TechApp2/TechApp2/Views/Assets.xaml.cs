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
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assets : ContentPage, INotifyPropertyChanged
    {       
        public Assets()
        {
            InitializeComponent();
        }
        private async void GetAsset(string ssn)
        {
            if (!string.IsNullOrEmpty(ssn))
            { 
            AssetViewModel assetResponse = new AssetViewModel();          
            HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/assets/TechAPPSSNSearch/{ssn}");
            var response = await httpClient.GetStringAsync(Url);
            assetResponse = JsonConvert.DeserializeObject<AssetViewModel>(response);
            this.BindingContext = assetResponse;
            }
        }
        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSSN.Text.ToString()))
            {
                DisplayAlert("Warning", "Please Enter SSN !", "OK");               
            }
            else
            { 
            GetAsset(txtSSN.Text.ToString());
            }
        }
        private async void btnBarcodeScan_Clicked(object sender, EventArgs e)
        {
            string bacodeData = string.Empty;
            var scanPage = new ZXingScannerPage();
            await Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread( async () =>
                {
                    await Navigation.PopAsync();                   
                    bacodeData = result.Text.ToString();
                    if (!string.IsNullOrEmpty(bacodeData))
                    {
                        GetAsset(bacodeData);
                    }
                });
            };     
        }        
    }
}