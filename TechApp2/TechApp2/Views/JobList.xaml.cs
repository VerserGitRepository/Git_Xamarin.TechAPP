using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Models;
using TechApp2.Services;
using TechApp2.Views.JobDetailed;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobList : ContentPage
    {     
        public JobList()
        {
            InitializeComponent();          
        }      
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var jobs = await JobService.JobsListService();
            JobListView.ItemsSource = jobs;
           // JobLogo.Source = ImageSource.FromStream(() => new MemoryStream(jobs.Single().Logo));

        }
        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

            var selectdate = ((DatePicker)sender).Date.ToString();
           string username = LoginDetails.UserID;
            base.OnAppearing();
            var jobs = await JobService.JobsDetailsByUserDateService(username, Convert.ToDateTime(selectdate).Date);
        }

        private void JobListView_ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var evnt = e;
            var selectedjob = e.CurrentSelection[0] as JobListViewModel;
            //Application.Current.MainPage = new NavigationPage(new JobDetailsTabbed(selectedjob.JobNo.ToString()));
            this.Navigation.PushAsync(new JobDetailsTabbed(selectedjob.JobNo.ToString()));
        }

    }
}