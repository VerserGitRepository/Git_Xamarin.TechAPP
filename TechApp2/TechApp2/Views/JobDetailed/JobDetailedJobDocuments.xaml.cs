using Plugin.Media;
using Plugin.Media.Abstractions;
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

            //documents = jobslistObject.JobDocuments[];

            //byte[] bytes = Convert.FromBase64String(base64BinaryStr);

            //string filepath = await DependencyService.Get<ISaveFile>().SaveFiles("FileName", bytes);            
        }
        private async void PickDocument_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Warning", "NonSerializedAttribute Pic", "OK");
                return;

            }
            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile == null)
                return;

            LocalPathLabel.Text = _mediaFile.Path;

            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });

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
                Directory="Sample",
                Name="MyImage.jpg"
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

        }
    }
}