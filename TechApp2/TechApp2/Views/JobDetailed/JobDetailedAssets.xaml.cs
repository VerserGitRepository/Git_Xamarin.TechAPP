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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2.Views.JobDetailed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailedAssets : ContentPage
    {
        private byte[] imageButeArray;
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        private MediaFile _mediaFile;        
        public JobDetailedAssets()
        {
            InitializeComponent();
        }
        public void PopulateJobDetails(object sender, EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;

            JObAsetsList.ItemsSource= jobslistObject.AssetsList;
            //Console.WriteLine(jobslistObject);
            //this.BindingContext = jobslistObject.AssetsList;
        }

        private void AssetSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchtext = AssetSearchBar.Text;
            var SerachResults= jobslistObject.AssetsList.Where(a => a.SSN.Contains(searchtext)).ToList();
            if (SerachResults.Count > 0)
            {
                JObAsetsList.ItemsSource = SerachResults;
            }
            else
            {
                DisplayAlert("Information", "Asset Not Fount!", "OK");
                JObAsetsList.ItemsSource= jobslistObject.AssetsList;
            }            

        }
        private async void ListItemTapped(object sender, EventArgs e)
        {
            var actionSheet = await DisplayActionSheet("Action "+Environment.NewLine+" Take Picture", "Cancel", "Click");

            switch (actionSheet)
            {
                case "Cancel":
                    break;

                case "Click":
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Warning", "NonSerializedAttribute Pic", "OK");
                        return;

                    }
                    _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 500 });
                    if (_mediaFile == null)
                        return;
                    imageButeArray = new byte[_mediaFile.GetStream().Length];  //declare arraysize
                    _mediaFile.GetStream().Read(imageButeArray, 0, imageButeArray.Length);
                   
                    JobDetailsTabbed.updateModel.AssetsList = new List<AssetViewModel>();
                    JobDetailsTabbed.updateModel.AssetsList.Add((AssetViewModel)(sender as ListView).SelectedItem);

                    JobDetailsTabbed.updateModel.AssetsList.Find(x => x.AssetID == ((AssetViewModel)(sender as ListView).SelectedItem).AssetID).AssetPicture = imageButeArray;

                    break;

            }
        }
    }
}