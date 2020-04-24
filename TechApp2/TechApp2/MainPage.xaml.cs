using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Views;
using TechApp2.Models;
using Xamarin.Forms;
using TechApp2.ServiceHelper;
using System.Net.Http;

namespace TechApp2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            //logoIcon.Source = ImageSource.FromResource("TechApp2.Images.logo.jpg", assembly);
        }

        private  void BtnLogin_Clicked(object sender, EventArgs e)
        {
        
            bool isEmailEmpty = string.IsNullOrEmpty(UserName.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(Password.Text);
            if (isEmailEmpty || isPasswordEmpty)
            {
                DisplayAlert("Warning","Email Or Password Is Empty", "OK");
            }
            else
            {
                var user = new LoginModel { UserName = UserName.Text.ToString(), Password = Password.Text.ToString() };
                //   Task<LoginModel> userReturn = LoginService.Login(user);
                //if (userReturn.Result.IsLoggedIn == true)
                //{ 
                //} 
                // MasterNavigation
                Application.Current.MainPage = new NavigationPage(new MasterNavigation());
            }         
            // Navigation.PushModalAsync(new SSNLookUp()); //working
            //Application.Current.MainPage = new NavigationPage(new JobList()); //working
           

        }

      
    }
}
