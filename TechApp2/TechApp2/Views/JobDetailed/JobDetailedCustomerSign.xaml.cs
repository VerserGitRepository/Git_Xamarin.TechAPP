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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using TechApp2.Interfaces;

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
            
            
            var ResturnResults = await JobService.UpdateTechJob(JobDetailsTabbed.updateModel);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JobDetailedCustomerSign)).Assembly;
            //var name = System.IO.Path.GetFileName(path);
            Stream stream = assembly.GetManifestResourceStream("TechApp2.insght.json");
            Stream Logostream = assembly.GetManifestResourceStream("TechApp2.images.VerserLogo.png");
            string text = "";
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    text = reader.ReadToEnd();
            //}

            //var ResturnResults = JsonConvert.DeserializeObject<JobUpdateReturnDto[]>(text);

            var customWebView = new CustomWebView() { VerticalOptions = LayoutOptions.FillAndExpand };
            string filename1 = "";

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
            emailButton.Clicked += async (s, es) =>
            {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "Hello",
                        Body = "World",
                    };

                    var file = filename1;                  

                    string result = await DisplayPromptAsync("Email", "Please enter the eMail Address of the recipient. For multiple emails, use ','",placeholder: $"{JobService.jobDetailsModel.Email}");
                    if (result.Trim() == string.Empty)
                    {
                        result = JobService.jobDetailsModel.Email;
                        if (result == string.Empty)
                        {
                            DependencyService.Get<IAlertView>().Show("Email Id Cannot be blank.");
                            return;
                        }
                        //DependencyService.Get<IAlertView>().Show("Email Id Cannot be blank.");
                        //return;
                    }
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");
                    mail.From = new MailAddress("kalyan.vedula@verser.com.au");
                    mail.To.Add(result);
                   
                   
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString($"Hi {JobService.jobDetailsModel.ContactPerson}, <br> Automated CAF Signed Job Completion Email With PDF reference Copy .<br><br>Regards<br><br><img src=cid:myImage>", null, "text/html");
                   // MemoryStream ms = new MemoryStream(JobService.jobDetailsModel.ProjectLogo);
                    LinkedResource r = new LinkedResource(Logostream);
                    r.ContentId = "myImage";
                    var base64 = Convert.ToBase64String(JobService.jobDetailsModel.ProjectLogo);
                    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                    mail.Subject = JobService.jobDetailsModel.JobNo + "- CAF";
                    mail.Body = "This is an automated email.Please do not reply to this. \r\nFor any further queries, please call us on 1200800900.\r\n\r\n\r\nRegards";
                   
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(filename1);
                    mail.Attachments.Add(attachment);
                    //end email attachment part
                    htmlView.LinkedResources.Add(r);
                    mail.AlternateViews.Add(htmlView);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("kalyan.vedula@verser.com.au", "VerserKV19");
                    SmtpServer.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object sender1, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    await SmtpServer.SendMailAsync(mail);
                    DependencyService.Get<IAlertView>().Show("The email has been delivered successfully.");
                }
                catch (Exception ex)
                {
                    DependencyService.Get<IAlertView>().Show(ex.Message);
                }
            };

        }
    }
}