using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobSearchDetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSearchAssetList : ContentPage
    {
        JobDetailsViewModel _JobObject = new JobDetailsViewModel();
        string SearchJobNo = string.Empty;
        public JobSearchAssetList(JobDetailsViewModel JobObject)
        {
            InitializeComponent();             
            if (JobObject != null)
            {
                _JobObject = JobObject;
                JobAsetsList.ItemsSource = JobObject.AssetsList;
            }            
        }
        private void BtnBackToJobDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }      

        private void SearchAssetBar_SearchButtonPressed(object sender, EventArgs e)
        {
            if (_JobObject != null)
            {
                JobAsetsList.ItemsSource = _JobObject.AssetsList.Where(x => x.SSN.Contains(SearchAssetBar.Text.ToString())).ToList();
            }
        }
    }
}