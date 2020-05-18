using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class JobDetailedCustomerSign : ContentPage
    {
       
        private RatingDto theRating = new RatingDto();
        
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
        }

       

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Stream CustomerJObSign = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
            Stream TechSignJOb = await TechSign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);

            byte[] image = new byte[CustomerJObSign.Length];
            byte[] Techimage = new byte[TechSignJOb.Length];//declare arraysize
            CustomerJObSign.Read(image, 0, image.Length);
            TechSignJOb.Read(Techimage, 0, Techimage.Length);
            JobDetailsTabbed.updateModel.CustomerSignatureVector = image;
            JobDetailsTabbed.updateModel.CustomerSignatureImage = JobService.jobDetailsModel.JobNo+"_Customer_"+DateTime.Now.Ticks+".pdf";
            JobDetailsTabbed.updateModel.TechnicianSignatureVector = Techimage;
            JobDetailsTabbed.updateModel.TechnicianSignatureImage = JobService.jobDetailsModel.JobNo + "_Technician_" + DateTime.Now.Ticks + ".pdf";
            JobDetailsTabbed.updateModel.Rating = theRating;
            JobDetailsTabbed.updateModel.Rating.PoliteAndCourteous = PoliteAndCourteous.SelectedItem == null ? 0 : Convert.ToInt32(PoliteAndCourteous.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.ProfessionalService = ProfessionalService.SelectedItem == null ? 0 : Convert.ToInt32(ProfessionalService.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.WorkQuality = WorkQuality.SelectedItem == null ? 0 : Convert.ToInt32(WorkQuality.SelectedItem);
            JobDetailsTabbed.updateModel.JobNo = JobService.jobDetailsModel.JobNo;
            JobDetailsTabbed.updateModel.Rating.Punctuality = Punctuality.SelectedItem == null ? 0 : Convert.ToInt32(Punctuality.SelectedItem);
            UpdateTechJobDto s = await JobService.UpdateTechJob(JobDetailsTabbed.updateModel);

        }
    }
}