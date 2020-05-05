using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Models;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedJobDocuments : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        public JobDetailedJobDocuments()
        {
            InitializeComponent();
        }
        public void PopulateJobDetails(object sender, EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;
             var documents = new JobDocumentViewModel();

            //documents = jobslistObject.JobDocuments[];

            //byte[] bytes = Convert.FromBase64String(base64BinaryStr);

            //string filepath = await DependencyService.Get<ISaveFile>().SaveFiles("FileName", bytes);            
        }
    }
}