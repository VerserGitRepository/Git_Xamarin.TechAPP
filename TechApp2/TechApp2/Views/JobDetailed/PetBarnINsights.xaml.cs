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
    public partial class PetBarnINsights : ContentPage
    {
        private RiskAssessmentViewModel riskVM = new RiskAssessmentViewModel();
       
        public PetBarnINsights()
        {
            InitializeComponent();
        }

        private async void BtnupdateRiskAssess_Clicked(object sender, EventArgs e)
        {
            //TechnicianComments need to clubed into work instruction or somewhere
            InsightDeliverablesDto check = new InsightDeliverablesDto();
            JobDetailsTabbed.updateModel.InsightDeliverables.IsDataMigrated = DataMigration.SelectedItem == null ? false : DataMigration.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsOSUpgraded = UpgradeOS.SelectedItem == null ? false : UpgradeOS.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsDeliverablesConfigured = DeliverablesConfig.SelectedItem == null ? false : DeliverablesConfig.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsSoftwareInstalled = Installation.SelectedItem == null ? false : Installation.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsOSTested = Testing.SelectedItem == null ? false : Testing.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsFilesValidationCompleted = Validation.SelectedItem == null ? false : Validation.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsStoreCompleted = StoreComplete.SelectedItem == null ? false : StoreComplete.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.InsightDeliverables.IsRevisitRequired = RevisitRequired.SelectedItem == null ? false : RevisitRequired.SelectedItem.ToString() == "Yes";
            await Navigation.PopModalAsync();
        }
    }
}