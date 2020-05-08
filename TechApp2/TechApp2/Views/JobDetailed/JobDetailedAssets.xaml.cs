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
    public partial class JobDetailedAssets : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        public JobDetailedAssets()
        {
            InitializeComponent();
        }
        public void PopulateJobDetails(object sender, EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;

            JObAsetsList.ItemsSource= jobslistObject.AssetsList;
            //Console.WriteLine(jobslistObject);
            //this.BindingContext = jobslistObject.AssetsList;
        }

        private void AssetSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchtext = AssetSearchBar.Text;
            var SerachResults= jobslistObject.AssetsList.Where(a => a.SSN.Contains(searchtext)).ToList();
            if (SerachResults.Count > 0)
            {
                JObAsetsList.ItemsSource = SerachResults;
            }
            else
            {
                DisplayAlert("Information", "Asset Not Fount!", "OK");
                JObAsetsList.ItemsSource= jobslistObject.AssetsList;
            }            

        }
    }
}