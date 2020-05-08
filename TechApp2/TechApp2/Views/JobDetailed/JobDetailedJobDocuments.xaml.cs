using Plugin.FilePicker;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class JobDetailedJobDocuments : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        private MediaFile _mediaFile;
        public JobDetailedJobDocuments()
        {
            InitializeComponent();
        }
        public void PopulateJobDetails(object sender, EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;
             var documents = new JobDocumentViewModel();
            JobDocuments.ItemsSource = jobslistObject.JobDocuments;
            //documents = jobslistObject.JobDocuments[];

            //byte[] bytes = Convert.FromBase64String(base64BinaryStr);

            //string filepath = await DependencyService.Get<ISaveFile>().SaveFiles("FileName", bytes);            
        }
        private async void PickDocument_Clicked(object sender, EventArgs e)
        {
            //await CrossMedia.Current.Initialize();
            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("Warning", "NonSerializedAttribute Pic", "OK");
            //    return;

            //}
            //_mediaFile = await CrossMedia.Current.PickPhotoAsync();
            //if (_mediaFile == null)
            //    return;

            //LocalPathLabel.Text = _mediaFile.Path;

            //FileImage.Source = ImageSource.FromStream(() =>
            //{
            //    return _mediaFile.GetStream();
            //});

            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                LocalPathLabel.Text = file.FileName;
            }

        }
        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Warning", "NonSerializedAttribute Pic", "OK");
                return;

            }
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "MyImage.jpg"
            });
            if (_mediaFile == null)
                return;

            LocalPathLabel.Text = _mediaFile.Path;

            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }

        private async void UploadFile_Clicked(object sender, EventArgs e)
        {
            //var directory = Environment.CurrentDirectory;
            //directory = Path.Combine(directory, Environment.SystemDirectory);
            //string file = Path.Combine(directory.ToString(), "temp.pdf");
            //System.IO.File.WriteAllBytes(file, grnbytedata);


            byte[] grnbytedata = jobslistObject.JobDocuments[0].FileContent;
            var myStr = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(myStr, "test.pdf");

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            string targetStr = null;
            if (Device.RuntimePlatform == Device.iOS)
            {
                targetStr = "iOS";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                targetStr = "Droid";
            }
            else
            {
                targetStr = "UWP";
            }
            File.WriteAllBytes(filePath, grnbytedata);
            LocalPathLabel.Text = filePath;


        }
    }
}