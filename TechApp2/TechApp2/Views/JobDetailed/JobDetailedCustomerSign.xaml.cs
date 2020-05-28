using Newtonsoft.Json;
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
    {   private RatingDto theRating = new RatingDto();        
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
        }
        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Stream CustomerJObSign = await MainSignaturePad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg, strokeColor: Color.Black, fillColor: Color.White);
            Stream TechSignJOb = await TechSign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg, strokeColor: Color.Black, fillColor: Color.White);
            byte[] image = new byte[CustomerJObSign.Length];
            byte[] Techimage = new byte[TechSignJOb.Length];//declare arraysize
            CustomerJObSign.Read(image, 0, image.Length);
            TechSignJOb.Read(Techimage, 0, Techimage.Length);
            JobDetailsTabbed.updateModel.CustomerSignatureVector = JobService.jobDetailsModel.JobNo + "_Customer_" + DateTime.Now.Ticks + ".pdf";
            JobDetailsTabbed.updateModel.CustomerSignatureImage = image;
            JobDetailsTabbed.updateModel.TechnicianSignatureVector = JobService.jobDetailsModel.JobNo + "_Technician_" + DateTime.Now.Ticks + ".pdf";
            JobDetailsTabbed.updateModel.TechnicianSignatureImage = Techimage;
            JobDetailsTabbed.updateModel.Rating = theRating;
            JobDetailsTabbed.updateModel.Rating.PoliteAndCourteous = PoliteAndCourteous.SelectedItem == null ? 0 : Convert.ToInt32(PoliteAndCourteous.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.ProfessionalService = ProfessionalService.SelectedItem == null ? 0 : Convert.ToInt32(ProfessionalService.SelectedItem);
            JobDetailsTabbed.updateModel.Rating.WorkQuality = WorkQuality.SelectedItem == null ? 0 : Convert.ToInt32(WorkQuality.SelectedItem);
            JobDetailsTabbed.updateModel.JobNo = JobService.jobDetailsModel.JobNo;
            JobDetailsTabbed.updateModel.Rating.Punctuality = Punctuality.SelectedItem == null ? 0 : Convert.ToInt32(Punctuality.SelectedItem);
            JobDetailsTabbed.updateModel.UserName = Settings.LastUsedUserId;
            JobDetailsTabbed.updateModel.ProjectLogo = JobService.jobDetailsModel.ProjectLogo;
            JobDetailsTabbed.updateModel.WorkInstructions = JobService.jobDetailsModel.WorkInstructions;
            JobDetailsTabbed.updateModel.AssetsList = JobService.jobDetailsModel.AssetsList;
            JobDetailsTabbed.updateModel.Department = JobService.jobDetailsModel.Department;
            JobDetailsTabbed.updateModel.CustomerName = JobService.jobDetailsModel.ContactPerson;
            JobDetailsTabbed.updateModel.Building = JobService.jobDetailsModel.Building;
            JobDetailsTabbed.updateModel.Floor = JobService.jobDetailsModel.Floor;
            JobDetailsTabbed.updateModel.ContactPerson = JobService.jobDetailsModel.ContactPerson;
            JobDetailsTabbed.updateModel.Phone1 = JobService.jobDetailsModel.Phone1;
            JobDetailsTabbed.updateModel.Phone2 = JobService.jobDetailsModel.Phone2;
            JobDetailsTabbed.updateModel.Fax = JobService.jobDetailsModel.Fax;
            JobDetailsTabbed.updateModel.Email = JobService.jobDetailsModel.Email;
            JobDetailsTabbed.updateModel.SiteName = JobService.jobDetailsModel.SiteName;
            JobDetailsTabbed.updateModel.SiteAddress = JobService.jobDetailsModel.SiteAddress;       
            
            var ResturnResults = await JobService.UpdateTechJob(JobDetailsTabbed.updateModel);

            var customWebView = new CustomWebView() { VerticalOptions = LayoutOptions.FillAndExpand };

            var button = new Button { Text = "Open PDF" };
            var closeButton = new Button { Text = "Close" };

            button.Clicked += (s, es) =>
            {
                System.IO.File.WriteAllBytes(System.IO.Path.GetTempPath() + "//" + ResturnResults.RetutnPDFFileName, ResturnResults.RetutnPDFFileContent);
                string str = System.IO.Path.GetTempPath() + "//" + ResturnResults.RetutnPDFFileName;

                var exists = File.Exists(str);
                //var document = new PdfDocument();
                string filename =
                //document.Save(str);
                customWebView.Path = str;
            };

            closeButton.Clicked += (s, es) =>
            {
                Application.Current.MainPage = new NavigationPage(new MasterNavigation());
            };

            if (ResturnResults != null)
            {
                if (ResturnResults.IsOperationSuccess)
                {
                    await DisplayAlert("Info", "Job Update Operation Completed Successfull", "OK");
                    this.Navigation.PushAsync(new ContentPage
                    {
                        Title = "Open PDF",
                        Content = new StackLayout
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Children = {
                        button,
                        closeButton,
                        customWebView
                    }
                        }
                    });

                }               
            }
            
        }
    }
}