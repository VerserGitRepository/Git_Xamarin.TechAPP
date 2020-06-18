using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Interfaces;
using TechApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobSearchDetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSearchDocs : ContentPage
    {
        JobDetailsViewModel _JobObject = new JobDetailsViewModel();
        string SearchJobNo = string.Empty;
        public JobSearchDocs(JobDetailsViewModel JobObject)
        {
            InitializeComponent();
            if (JobObject != null)
            {
                _JobObject = JobObject;
                JobDocuments.ItemsSource = JobObject.JobDocuments;
            }
        }
        private void BtnBackToJobDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
        private async void JobDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                byte[] grnbytedata = (e.CurrentSelection.First() as JobDocumentViewModel).FileContent;
                string theFileName = (e.CurrentSelection.First() as JobDocumentViewModel).FileName;
                string filePath = await DependencyService.Get<ISave>().Save(grnbytedata, theFileName);
                string message = "The PDF has been saved to " + filePath;
                DependencyService.Get<IAlertView>().Show(message);
            }
            catch (Exception ex)
            {
                DependencyService.Get<IAlertView>().Show(ex.Message);
                return;
            }
        }
    }
}