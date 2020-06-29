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
           await Navigation.PopModalAsync();
        }
    }
}