using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class Assets : ContentPage
    {
       //public string SSN;
       //public string Make;

       //public string Model;
       //public  string Grade;

     

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
        public Assets()
        {
            InitializeComponent();

            GetAsset();

            BindingContext = this;

            //var Result = SSNLookUpService.SSNLookUpRequest("15097672").Result;
            //SSN = Result.SSN;
            //Make = Result.Make;
            //Model = Result.Model;
            //Grade = Result.Grade;
        }
        SearchBar searchBar = new SearchBar
        {
            Placeholder = "Search items...",
            PlaceholderColor = Color.Orange,
            TextColor = Color.Orange,
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(SearchBar)),
            FontAttributes = FontAttributes.Italic
        };
        public static readonly BindableProperty SSNProperty = BindableProperty.Create("SSN", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty MakeProperty = BindableProperty.Create("Make", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty ModelProperty = BindableProperty.Create("Model", typeof(string), typeof(Assets), "");
        public static readonly BindableProperty GradeProperty = BindableProperty.Create("Grade", typeof(string), typeof(Assets), "");


        private async void GetAsset()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://customers.verser.com.au/AssetManagementService/inventorycontrol/assets/ssnlookup/15097672");
            var responsedata = JsonConvert.DeserializeObject<AssetViewModel>(response);
            SSN = responsedata.SSN;
            Make = responsedata.Make;
            Model = responsedata.Model;
            Grade = responsedata.Grade;
        }

        private void btnJobs_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new JobList());
        }
    }
}