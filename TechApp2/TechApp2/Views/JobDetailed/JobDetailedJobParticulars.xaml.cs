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
    public partial class JobDetailedJobParticulars : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        //public event EventHandler Appearing;
        public JobDetailedJobParticulars()
        {
            InitializeComponent();
            
        }
        public void PopulateJobDetails(object sender,EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;
            Console.WriteLine(jobslistObject);
            this.BindingContext = jobslistObject;
        }
    }
}