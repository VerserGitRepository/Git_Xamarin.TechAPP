using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationDashBoard : ContentPage
    {
        public NavigationDashBoard()
        {
            InitializeComponent();
        }

        private void btnSearchSSN_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Assets());
        }

        private void btnjobslist_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new JobList());
        }

        private void btnSerialsearch_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SerialNoSearchView());
        }
        private void btnlogout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void btnreport_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new BlancooReports());
        }

        private void btnstats_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Statastics());
        }
    }
}