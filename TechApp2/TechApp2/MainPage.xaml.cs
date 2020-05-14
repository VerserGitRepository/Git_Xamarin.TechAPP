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
using Lottie.Forms;
using TechApp2;

namespace TechApp2
{ 
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            UserName.Text = Settings.LastUsedUserId;
            Password.Text = Settings.LastUsedUserPassword;         
            this.animationView.IsVisible = false;
            this.animationView.HeightRequest = 80;         
        }
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            this.animationView.IsVisible = true;
            bool isEmailEmpty = string.IsNullOrEmpty(UserName.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(Password.Text);
            if (isEmailEmpty || isPasswordEmpty)
            {
                DisplayAlert("Warning", "Email Or Password Is Empty", "OK");
               // this.animationView.IsVisible = false;
                return;
            }
            else
            {
                var user = new LoginModel { UserName = UserName.Text.ToString(), Password = Password.Text.ToString() };
                       
                Task<LoginModel> userReturn = LoginService.Login(user);
                var LoginState = userReturn.Result;

                if (LoginState.IsLoggedIn)
                {
                    LoginDetails.UserID = LoginState.FullName;
                    Settings.LastUsedUserId = UserName.Text.ToString();
                    Settings.LastUsedUserPassword = Password.Text.ToString();
                    Application.Current.MainPage = new NavigationPage(new MasterNavigation());
                    this.animationView.IsVisible = false;
                }
                else
                {
                    DisplayAlert("Warning", "The user id or password entered is incorrect.", "OK");
                   // this.animationView.IsVisible = false;
                    return;
                }            
            }      
          }
      }
}
