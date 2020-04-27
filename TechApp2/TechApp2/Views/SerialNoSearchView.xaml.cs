using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            BindingContext = this;
        }

        private async void btnSerialSearch_Clicked(object sender, EventArgs e)
        {
            var responsedata = new AssetViewModel();
            responsedata = await  SSNLookUpService.SerialNoSearchRequest(txtSerialNo.Text.ToString());          
        }

        //private void btnSerialSearch_Clicked_1(object sender, EventArgs e)
        //{

        //}

        //private void btnback_Clicked(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new NavigationPage(new NavigationDashBoard());
        //}
    }
}