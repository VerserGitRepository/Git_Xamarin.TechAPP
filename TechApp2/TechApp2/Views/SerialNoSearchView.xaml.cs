using System;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SerialNoSearchView : ContentPage
    {
        public SerialNoSearchView()
        {
            InitializeComponent();
           // BindingContext = this;
        }

        private async void btnSerialSearch_Clicked(object sender, EventArgs e)
        {
            var responsedata = new AssetViewModel();
            responsedata = await  SSNLookUpService.SerialNoSearchRequest(txtSerialNo.Text.ToString());
            this.BindingContext = responsedata;
        }
    }
}