using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Services;
using TechApp2.Views.JobDetailed;
using TechApp2.Views.JobSearchDetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchJobNo : ContentPage
    {
        public JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        public SearchJobNo()
        {
            InitializeComponent();
        }
        private async void btnJobNoSearch_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJobNoSearch.Text))
            {
                jobslistObject = await JobService.JobsDetailsService(txtJobNoSearch.Text);
                this.BindingContext = jobslistObject;
              //  this.Navigation.PushAsync(new JobDetailsTabbed(JobData.ToString()));
            }        
        }
        private void btninstructionDetails_Clicked(object sender, EventArgs e)
        {
            string workinstructiondata = LblJobWorkInstruction.Text.ToString();
            Navigation.PushModalAsync(new JobSearchInstructionDetails(workinstructiondata));
        }

        private void btnJobAssets_Clicked(object sender, EventArgs e)
        {
            if (jobslistObject != null)
            {
                Navigation.PushModalAsync(new JobSearchAssetList(jobslistObject));
            }
        }

        private void btnJobSearchRiskAssess_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new JobSearchRiskAssess(jobslistObject));
        }
        private void btnJobSearchJobDocs_Clicked(object sender, EventArgs e)
        {
            if (jobslistObject != null)
            {
                Navigation.PushModalAsync(new JobSearchDocs(jobslistObject));
            }
        }

    }
}