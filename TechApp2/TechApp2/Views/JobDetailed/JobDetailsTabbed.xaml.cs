using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailsTabbed : TabbedPage
    {
        public JobDetailsTabbed(string JobNo)
        {
            InitializeComponent();         
            JobDetailAPICall(JobNo);
        }
        private async void  JobDetailAPICall(string JobNo)
        {
            var Results = await JobService.JobsDetailsService(JobNo);
        }       
    }
}