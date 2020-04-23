using System;
using TechApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           // MainPage = new NavigationPage(n);
           MainPage = new MainPage();
          //  MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
