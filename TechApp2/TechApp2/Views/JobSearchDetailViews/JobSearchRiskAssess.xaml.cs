using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobSearchDetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSearchRiskAssess : ContentPage
    {
        public JobSearchRiskAssess(JobDetailsViewModel JobObject)
        {
            InitializeComponent();
            ManualHandling.Text = JobObject.RiskAssessment.RiskArea.Contains("Manual Handling").ToString();
            AwkawardItems.Text = JobObject.RiskAssessment.RiskArea.Contains("Awkaward").ToString();
            TrafficParkingLoading.Text = JobObject.RiskAssessment.RiskArea.Contains("Traffic").ToString();
            SlipsTripsFalls.Text = JobObject.RiskAssessment.RiskArea.Contains("Slips").ToString();
            PowerlinesTrees.Text = JobObject.RiskAssessment.RiskArea.Contains("Powerlines").ToString();
            Others.Text = JobObject.RiskAssessment.RiskArea.Contains("Others").ToString();
            this.BindingContext = JobObject;
        }
        private void BtnBackToJobDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}