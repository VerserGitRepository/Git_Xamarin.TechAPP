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
        private async void  GetAsset(string ssn)
        {
            AssetViewModel assetResponse = new AssetViewModel(); //15097672             
            HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/assets/TechAPPSSNSearch/{ssn}");
            var response = await httpClient.GetStringAsync(Url); 
            assetResponse = JsonConvert.DeserializeObject<AssetViewModel>(response);
            this.BindingContext = assetResponse;        
        }
        private void btnSearch_Clicked(object sender, EventArgs e)
        {  
            GetAsset(txtSSN.Text.ToString());
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
                    Barcodetxt.Text = result.Text;
                    bacodeData = result.Text.ToString();
                    
                });
            };
           // await Navigation.PushAsync(scanPage);
            if (bacodeData !=null)
            {
                GetAsset(bacodeData);
            }
            
        }

        //private async Task btnBarcodeScan_ClickedAsync(object sender, EventArgs e)
        //{
        //    ZXingScannerPage scanPage = new ZXingScannerPage();
        //    scanPage.OnScanResult += (result) =>
        //    {
        //        scanPage.IsScanning = false;
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            Navigation.PopAsync();
        //          var  text =  result.Text;
        //        });
        //    };
        //    await Navigation.PushAsync(scanPage);

        //    // results.Text = result.Text;
        //}
    }
}