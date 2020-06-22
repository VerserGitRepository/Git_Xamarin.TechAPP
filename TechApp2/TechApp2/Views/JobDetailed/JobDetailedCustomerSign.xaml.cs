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
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Xamarin.Essentials;
using System.Reflection;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedCustomerSign : ContentPage
    {   private RatingDto theRating = new RatingDto();        
        public JobDetailedCustomerSign()
        {
            InitializeComponent();
            this.animationView.IsVisible = false;
        }
        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            this.animationView.IsVisible = true;
            this.SaveBtn.IsEnabled = false;
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

            //var ResturnResults = await JobService.UpdateTechJob(JobDetailsTabbed.updateModel);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JobDetailedCustomerSign)).Assembly;
            //var name = System.IO.Path.GetFileName(path);
            Stream stream = assembly.GetManifestResourceStream("TechApp2.insght.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var ResturnResults = JsonConvert.DeserializeObject<JobUpdateReturnDto[]>(text);

            var customWebView = new CustomWebView() { VerticalOptions = LayoutOptions.FillAndExpand };
            string filename1 = "";

              //< Button Text = "Pick Photo"  Grid.Row = "0" Grid.Column = "0"
              //      BackgroundColor = "Orange" WidthRequest = "30" HeightRequest = "50"
              //      TextColor = "White"
              //      Clicked = "PickDocument_Clicked"
              //      FontSize = "10"
              //       CornerRadius = "10"
              //      Margin = "0,20,10,0" />

                //< Button Text = "Take Photo" Grid.Row = "0" Grid.Column = "2"
                //    BackgroundColor = "Orange"
                //    TextColor = "White"
                //    Clicked = "TakePhoto_Clicked"
                //    FontSize = "10"
                //     CornerRadius = "10"
                //    Margin = "0,20,10,0" />

            var button = new Button { Text = "Open PDF", BackgroundColor = Color.Orange, WidthRequest = 30, HeightRequest = 50, TextColor = Color.White, FontSize = 10, CornerRadius = 10 };
            var closeButton = new Button { Text = "Close", BackgroundColor = Color.Orange, WidthRequest = 30, HeightRequest = 50, TextColor = Color.White, FontSize = 10, CornerRadius = 10 };
            var emailButton = new Button { Text = "Email", BackgroundColor = Color.Orange, WidthRequest = 30, HeightRequest = 50, TextColor = Color.White, FontSize = 10, CornerRadius = 10 };
            PdfDocument outputDocument = new PdfDocument();

            // Iterate files
            foreach (JobUpdateReturnDto dto in ResturnResults)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(new MemoryStream(dto.RetutnPDFFileContent), PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }
            }
            filename1 = System.IO.Path.GetTempPath() + "//" + DateTime.Now.Ticks + ".pdf";
            outputDocument.Save(filename1);
            button.Clicked += (s, es) =>
            {
                string filename =
                customWebView.Path = filename1;
            };

            closeButton.Clicked += (s, es) =>
            {
                Application.Current.MainPage = new NavigationPage(new MasterNavigation());
            };

            if (ResturnResults != null)
            {
                if (ResturnResults[0].IsOperationSuccess)
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
                        emailButton,
                        customWebView
                    }
                        }
                    });

                }               
            }
            emailButton.Clicked += (s, es) =>
            {
               
                var message = new EmailMessage
                {
                    Subject = "Hello",
                    Body = "World",
                };

               // var fn = "Attachment.txt";
                var file = filename1;
                File.WriteAllText(file, "Hello World");

                message.Attachments.Add(new EmailAttachment(file));

                Email.ComposeAsync(message);
            };

        }
    }
}