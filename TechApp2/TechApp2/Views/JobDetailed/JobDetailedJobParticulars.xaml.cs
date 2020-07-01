using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedJobParticulars : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        //public event EventHandler Appearing;

           
        public JobDetailedJobParticulars()
        {
            InitializeComponent();
            jobslistObject.JobMapLogo = "MapLogo.png";
        }
        public void PopulateJobDetails(object sender,EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;
            if (jobslistObject.SiteAddress == null)
            {
                jobslistObject.SiteAddress = "350 Paramatta Rd Homebush NSW 2140";
            }

            //Console.WriteLine(jobslistObject);
            this.BindingContext = jobslistObject;
        }
        private void btninstructionDetails_Clicked(object sender, EventArgs e)
        {
            string workinstructiondata= LblJobWorkInstruction.Text.ToString();
            Navigation.PushModalAsync(new JobWorkInstructionDetails(workinstructiondata));
        }
        private async void SiteMap_Pressed(object sender, EventArgs e)
        {
            string site = jobslistObject.SiteName;
            if (!string.IsNullOrEmpty(site) )
            {   var SupportUri = await Launcher.CanOpenAsync("comgooglemaps://");
                Uri uri = new System.Uri($"http://maps.google.com/maps?q={site}");
                Launcher.OpenAsync(uri);
            }
        }
        private async void PhoneButtonClicked(object sender, EventArgs e)
        {
            if (jobslistObject.Phone1 == null || jobslistObject.Phone1 == string.Empty)
                return;

            var actionSheet = await DisplayActionSheet("Action"+Environment.NewLine+"Call: "+jobslistObject.Phone1+" ?", "Cancel", "Call");
            switch (actionSheet)
            {
                case "Cancel":
                    break;

                case "Call":
                    
                   PhoneDialer.Open(jobslistObject.Phone1);
                   break;
            }
        }
    }
}