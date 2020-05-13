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
    public partial class JobDetailedJobRiskAssess : ContentPage
    {
        private RiskAssessmentViewModel riskVM = new RiskAssessmentViewModel();
        public JobDetailedJobRiskAssess()
        {
            InitializeComponent();
        }

        private  void BtnupdateRiskAssess_Clicked(object sender, EventArgs e)
        {
            List<RiskAssessmentViewModel> risksampleData = new List<RiskAssessmentViewModel>();
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Manual Handling", Rating = ManualHandling.SelectedItem == null?"N/A": ManualHandling.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", Created = DateTime.Now });
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Awkward/Irregular Items", Rating = AkwardItems.SelectedItem == null ? "N/A" : AkwardItems.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", Created = DateTime.Now });
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Traffic/Parking/Loading", Rating = TrafficLoading.SelectedItem == null ? "N/A" : TrafficLoading.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", Created = DateTime.Now });
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Powerlines/Eaves/Trees/Docks", Rating = PowerLineDocks.SelectedItem == null ? "N/A" : PowerLineDocks.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", Created = DateTime.Now });
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Slips/Trips/Falls", Rating = SlipTripsFalls.SelectedItem == null ? "N/A" : SlipTripsFalls.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", Created = DateTime.Now });
            risksampleData.Add(new RiskAssessmentViewModel { RiskArea = "Other", Rating = OtherRisk.SelectedItem == null ? "N/A" : OtherRisk.SelectedItem.ToString(), RiskAssessment_Job = JobService.jobDetailsModel.JobNo, CreatedBy = "TestUser", OtherValue = "Test OtherValue", Created = DateTime.Now });
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[4];

        }
    }
}