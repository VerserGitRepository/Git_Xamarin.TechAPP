using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailsTabbed : TabbedPage
    {
        public static UpdateTechJobDto updateModel = new UpdateTechJobDto();
        public JobDetailsTabbed(string JobNo,byte[] logo)
        {
            InitializeComponent();         
            JobDetailAPICall(JobNo,logo);
        }
        private async void  JobDetailAPICall(string JobNo,byte[] logo)
        {
            var Results = await JobService.JobsDetailsService(JobNo);
            JobService.jobDetailsModel.ProjectLogo = logo;
            //  JobDetailedJobParticulars.jobslistObject = Results ;
        }
        private void PopulateDetails()
        {
           // JobDetailedJobParticulars.jobslistObject = results;
        }
       
    }
}