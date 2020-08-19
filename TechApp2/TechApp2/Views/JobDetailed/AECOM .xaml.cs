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
    public partial class AECOM : ContentPage
    {
        private RiskAssessmentViewModel riskVM = new RiskAssessmentViewModel();
       
        public AECOM()
        {
            InitializeComponent();
        }

        private async void BtnupdateRiskAssess_Clicked(object sender, EventArgs e)
        {
            //TechnicianComments need to clubed into work instruction or somewhere
            AecomDto check = new AecomDto();
            JobDetailsTabbed.updateModel.AecomDeliverables.ImagingComplete = ImagingComplete.SelectedItem == null ? false : ImagingComplete.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.SoftwareApplicationsComplete = SoftwareApplicationsComplete.SelectedItem == null ? false : SoftwareApplicationsComplete.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.DataMigrationsComplete = DataMigrationsComplete.SelectedItem == null ? false : DataMigrationsComplete.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.Installation = Installation.SelectedItem == null ? false : Installation.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.EMailCheckComplete = EMail.SelectedItem == null ? false : EMail.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.CalenderCheckComplete = Calender.SelectedItem == null ? false : Calender.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.AddressBookCheckComplete = AddressBook.SelectedItem == null ? false : AddressBook.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.FavoritesCheckComplete = Favorites.SelectedItem == null ? false : Favorites.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.MyDocumentsCheckComplete = MyDocuments.SelectedItem == null ? false : MyDocuments.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.EMail2CheckComplete = EMail2.SelectedItem == null ? false : EMail2.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.Calender2CheckComplete = Calender2.SelectedItem == null ? false : Calender2.SelectedItem.ToString() == "Yes";
            JobDetailsTabbed.updateModel.AecomDeliverables.AddressBook2CheckComplete = AddressBook2.SelectedItem == null ? false : AddressBook2.SelectedItem.ToString() == "Yes";
            await Navigation.PopModalAsync();
        }
    }
}