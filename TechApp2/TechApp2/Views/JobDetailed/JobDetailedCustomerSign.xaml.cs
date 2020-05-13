using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedCustomerSign : ContentPage
    {
        List<JobAssetPhotes> Jobassetphoto = new List<JobAssetPhotes>();
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
        }

       

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {


           

            
          
        }
    }
}