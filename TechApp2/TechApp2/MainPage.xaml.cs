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
        }

        private  void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var UserID = UserName.Text;
            var _Password = Password.Text;
            var user = new LoginModel {  UserName = UserID.ToString(), Password = _Password };

            //  Task<LoginModel> userReturn = LoginService.Login(user);

            //if (userReturn.Result.IsLoggedIn == true)
            //{ 

            //}           
            // Navigation.PushModalAsync(new SSNLookUp()); //working
            //Application.Current.MainPage = new NavigationPage(new JobList()); //working
            Application.Current.MainPage = new NavigationPage(new Assets()); 

        }

      
    }
}
