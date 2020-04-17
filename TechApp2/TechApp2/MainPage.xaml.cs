using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Views;
using Xamarin.Forms;
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
            var MyEntry = new Entry { IsPassword = true, Placeholder = "Password" };

            var username = new Entry { Placeholder = "UserID" };
            //  Navigation.PushModalAsync(new JobList()); //working
            Application.Current.MainPage = new NavigationPage(new JobList()); //working

        }
    }
}
