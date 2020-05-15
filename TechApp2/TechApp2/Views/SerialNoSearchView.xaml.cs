using System;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SerialNoSearchView : ContentPage
    {
        public SerialNoSearchView()
        {
            InitializeComponent();           
        }
        private async void btnSerialBarcodeScan_Clicked(object sender, EventArgs e)
        {
            var responseSerialNoScandata = new AssetViewModel();
            string bacodeData = string.Empty;
            var scanPage = new ZXingScannerPage();
            await Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    bacodeData = result.Text.ToString();
                    if (!string.IsNullOrEmpty(bacodeData))
                    {
                        responseSerialNoScandata=await SSNLookUpService.SerialNoSearchRequest(bacodeData);
                        this.BindingContext = responseSerialNoScandata;
                    }
                });
            };

        }
        private async void txtSerialNo_SearchButtonPressed(object sender, EventArgs e)
        {
            var responsedata = new AssetViewModel();
            if (string.IsNullOrEmpty(txtSerialNo.Text.ToString()))
            {
                DisplayAlert("Warning", "Please Enter SerialNo !", "OK");
            }
            else
            {
                responsedata = await SSNLookUpService.SerialNoSearchRequest(txtSerialNo.Text.ToString());
                this.BindingContext = responsedata;
            }
        }
    }
}