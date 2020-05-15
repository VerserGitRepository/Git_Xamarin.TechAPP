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

namespace TechApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BroseAssets : ContentPage
    {
       public List<ListItems> Projectlists = new List<ListItems>();
       public List<ListItems> statusLists = new List<ListItems>();
       public List<ListItems> ItemTypeList = new List<ListItems>();
        public int ProjectID = 0;
        public int ItemTypeID = 0;
        public int StatusID = 0;

        public BroseAssets()
        {
            InitializeComponent();

            var projectStinglist = new List<string>();
            var ItemTypeStringList = new List<string>();
            var StatusStringList = new List<string>();

            Projectlists = DropDownListService.ProjectList().Result;
            statusLists = DropDownListService.ItemTypesList().Result;
            ItemTypeList = DropDownListService.StatusList().Result;          

            foreach (var item in Projectlists)
            {
                projectStinglist.Add(item.Value);
            }
            foreach (var item in ItemTypeList)
            {
                ItemTypeStringList.Add(item.Value);
            }
            foreach (var item in statusLists)
            {
                StatusStringList.Add(item.Value);
            }
            Projects.ItemsSource = projectStinglist;
            ItemTypes.ItemsSource = ItemTypeStringList;
            Status.ItemsSource = StatusStringList;
        }

        private void btnSearchAssetList_Clicked(object sender, EventArgs e)
        {
            if (Projects.SelectedItem !=null)
            {
                ProjectID = Projectlists.Where(p => p.Value.Contains(Projects.SelectedItem.ToString())).FirstOrDefault().Id;
            }
            if (Status.SelectedItem != null)
            {
                StatusID = statusLists.Where(p => p.Value.Contains(Status.SelectedItem.ToString())).FirstOrDefault().Id;
            }
            if (ItemTypes.SelectedItem != null)
            {
                ItemTypeID = ItemTypeList.Where(p => p.Value.Contains(ItemTypes.SelectedItem.ToString())).FirstOrDefault().Id;
            }
            var AssetList = new List<AssetViewModel>();
            if (ProjectID >0 && ItemTypeID >0 && StatusID >0)
            {
                AssetList = SSNLookUpService.ProjectAssets(ProjectID, ItemTypeID, StatusID).Result;
                BrowseAsetsList.ItemsSource = AssetList;
            }
            else
            {
                DisplayAlert("Warning", "One Or more Selection List Is Empty!", "OK");
            }     
        }
    }
}