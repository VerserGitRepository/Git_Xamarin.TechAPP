using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Services;
using TechApp2.Views.JobDetailed;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchJobNo : ContentPage
    {
        public SearchJobNo()
        {
            InitializeComponent();
        }
        private void btnJobNoSearch_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJobNoSearch.Text))
            {
                var JobData = JobService.JobsDetailsService(txtJobNoSearch.Text);
                this.Navigation.PushAsync(new JobDetailsTabbed(JobData.ToString()));
            }        
        }
    }
}