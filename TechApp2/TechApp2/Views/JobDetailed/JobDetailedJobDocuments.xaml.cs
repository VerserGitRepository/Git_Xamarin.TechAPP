using Plugin.FilePicker;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechApp2.Interfaces;
using TechApp2.Model;
using TechApp2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class JobDetailedJobDocuments : ContentPage
    {
        //private UpdateTechJobDto updateModel = new UpdateTechJobDto();
        private List<JobAssetPhotesDto> Jobassetphoto = new List<JobAssetPhotesDto>();
        private byte[] imageButeArray;
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
                imageButeArray = new byte[_mediaFile.GetStream().Length];  //declare arraysize
                _mediaFile.GetStream().Read(imageButeArray, 0, imageButeArray.Length);
                return _mediaFile.GetStream();
            });
        }

        private async void UploadFile_Clicked(object sender, EventArgs e)
        {
            //var directory = Environment.CurrentDirectory;
            //directory = Path.Combine(directory, Environment.SystemDirectory);
            //string file = Path.Combine(directory.ToString(), "temp.pdf");
            //System.IO.File.WriteAllBytes(file, grnbytedata);
            List<JobAssetPhotesDto> item = new List<JobAssetPhotesDto>();
            item.Add(new JobAssetPhotesDto { Image = imageButeArray, JobAssetPhoto_JobAsset = int.Parse(JobService.jobDetailsModel.JobNo), CreatedBy = "TestUser" });
            //updateModel.JobAssetPhots = item;

            
            JobDetailsTabbed.updateModel.JobAssetPhots = item;
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[3];

        }

        private void JobDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            byte[] grnbytedata = (e.CurrentSelection.First() as JobDocumentViewModel).FileContent;
            string theFileName = (e.CurrentSelection.First() as JobDocumentViewModel).FileName;
            string filePath = DependencyService.Get<ISave>().Save(grnbytedata,theFileName);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
            LocalPathLabel.Text = filePath;
        }
    }
}