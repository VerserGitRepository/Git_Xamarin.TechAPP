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
    public partial class BlancooReports : ContentPage
    {
        public BlancooReports()
        {
            InitializeComponent();
        }

        private void btnback_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new NavigationDashBoard());
        }
    }
}