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

        public string SSN
        {
            get { return (string)GetValue(SSNProperty); }
            set { SetValue(SSNProperty, value); }
        }
        public string Make
        {
            get { return (string)GetValue(MakeProperty); }
            set { SetValue(MakeProperty, value); }
        }
        public string Model
        {
            get { return (string)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public string Grade
        {
            get { return (string)GetValue(GradeProperty); }
            set { SetValue(GradeProperty, value); }
        }

        public string SerialNo
        {
            get { return (string)GetValue(SerialNoProperty); }
            set { SetValue(SerialNoProperty, value); }
        }
        public string ClientPO
        {
            get { return (string)GetValue(ClientPOProperty); }
            set { SetValue(ClientPOProperty, value); }
        }
        public string ClientRef
        {
            get { return (string)GetValue(ClientRefProperty); }
            set { SetValue(ClientRefProperty, value); }
        }
        public string AssetStatusId
        {
            get { return (string)GetValue(GradeProperty); }
            set { SetValue(GradeProperty, value); }
        }

        public string BuyPrice
        {
            get { return (string)GetValue(BuyPriceProperty); }
            set { SetValue(BuyPriceProperty, value); }
        }
        public string SellPrice
        {
            get { return (string)GetValue(SellPriceProperty); }
            set { SetValue(SellPriceProperty, value); }
        }
        public string ProjectId
        {
            get { return (string)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }
        public string ItemTypeId
        {
            get { return (string)GetValue(ItemTypeIdProperty); }
            set { SetValue(ItemTypeIdProperty, value); }
        }
        public string AssetTag
        {
            get { return (string)GetValue(AssetTagProperty); }
            set { SetValue(AssetTagProperty, value); }
        }
        public Assets()
        {
            InitializeComponent();

            //bindingContext = new AssetMVVMModel();
            BindingContext = this;
        }
        public static readonly BindableProperty SSNProperty = BindableProperty.Create("SSN", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty MakeProperty = BindableProperty.Create("Make", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ModelProperty = BindableProperty.Create("Model", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty GradeProperty = BindableProperty.Create("Grade", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty SerialNoProperty = BindableProperty.Create("SerialNo", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ClientPOProperty = BindableProperty.Create("ClientPO", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ClientRefProperty = BindableProperty.Create("ClientRef", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty AssetStatusIdProperty = BindableProperty.Create("AssetStatusId", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty BuyPriceProperty = BindableProperty.Create("BuyPrice", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty SellPriceProperty = BindableProperty.Create("SellPrice", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ProjectIdProperty = BindableProperty.Create("ProjectId", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ItemTypeIdProperty = BindableProperty.Create("ItemTypeId", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty AssetTagProperty = BindableProperty.Create("AssetTag", typeof(string), typeof(Assets), "");

        private async void  GetAsset(string ssn)
        {
             AssetViewModel assetResponse = new AssetViewModel(); //15097672 

         //  AssetMVVMModel assetmvmmodeldata = new AssetMVVMModel();

            HttpClient httpClient = new HttpClient();
            string Url = string.Format($"https://customers.verser.com.au/AssetManagementService/inventorycontrol/assets/ssnlookup/{ssn}");
            var response = await httpClient.GetStringAsync(Url); 
            assetResponse = JsonConvert.DeserializeObject<AssetViewModel>(response);

            //assetmvmmodeldata.SSN = assetResponse.SSN;
            //assetmvmmodeldata.Make = assetResponse.Make;
            //assetmvmmodeldata.Model = assetResponse.Model;
            //assetmvmmodeldata.Grade = assetResponse.Grade;
            //assetmvmmodeldata.SerialNo = assetResponse.SerialNo;            
            
            SSN = assetResponse.SSN;
            Make = assetResponse.Make;
            Model = assetResponse.Model;
            Grade = assetResponse.Grade;
            SerialNo = assetResponse.SerialNo;
            ClientPO = assetResponse.ClientPO;
            ClientRef = assetResponse.ClientRef;
            AssetTag = assetResponse.AssetTag;
            AssetStatusId = assetResponse.AssetStatusId.ToString();
            BuyPrice = assetResponse.BuyPrice.ToString();
            SellPrice = assetResponse.SellPrice.ToString();
            ProjectId = assetResponse.ProjectId.ToString();
            ItemTypeId = assetResponse.ItemTypeId.ToString();
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {  
            GetAsset(txtSSN.Text.ToString());
        }
        //private void btnback_Clicked(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new NavigationPage(new NavigationDashBoard());
        //}
    }
}