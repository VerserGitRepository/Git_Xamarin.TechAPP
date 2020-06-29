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
    public partial class FeedbackAssessmentForm : ContentPage
    {
        private RiskAssessmentViewModel riskVM = new RiskAssessmentViewModel();
       
        public FeedbackAssessmentForm()
        {
            InitializeComponent();
        }

        private async void BtnupdateRiskAssess_Clicked(object sender, EventArgs e)
        {
            JobDetailsTabbed.updateModel.Rating.PoliteAndCourteous = PoliteAndCourteous.SelectedItem == null ? 0 : Convert.ToInt32(PoliteAndCourteous.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.ProfessionalService = ProfessionalService.SelectedItem == null ? 0 : Convert.ToInt32(ProfessionalService.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.WorkQuality = WorkQuality.SelectedItem == null ? 0 : Convert.ToInt32(WorkQuality.SelectedItem);
            //JobDetailsTabbed.updateModel.JobNo = JobService.jobDetailsModel.JobNo;
            JobDetailsTabbed.updateModel.Rating.Punctuality = Punctuality.SelectedItem == null ? 0 : Convert.ToInt32(Punctuality.SelectedItem);
            await Navigation.PopModalAsync();
        }
    }
}