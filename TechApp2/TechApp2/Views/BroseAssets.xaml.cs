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
        public BroseAssets()
        {
            InitializeComponent();

            var projectStinglist = new List<string>();
            var ItemTypeStringList = new List<string>();
            var StatusStringList = new List<string>();
           //var projectLists = DropDownListService.ProjectList().Result;
           // var ItemTypeList = DropDownListService.ItemTypesList().Result;
           // var statusLists = DropDownListService.StatusList().Result;

           // foreach (var item in projectLists)
           // {
           //     projectStinglist.Add(item.Value);
           // }
           // foreach (var item in ItemTypeList)
           // {
           //     ItemTypeStringList.Add(item.Value);
           // }
           // foreach (var item in statusLists)
           // {
           //     StatusStringList.Add(item.Value);
           // }
           // Projects.ItemsSource = projectStinglist;
           // ItemTypes.ItemsSource = ItemTypeStringList;
           // Status.ItemsSource = StatusStringList;
        }

        private void btnSearchAssetList_Clicked(object sender, EventArgs e)
        {
            int ProjectID = 36;
            int ItemTypeID = 2;
            int StatusID = 22;

            var AssetList = new List<AssetViewModel>();
            if (ProjectID >0 && ItemTypeID >0 && StatusID >0)
            {
                AssetList = SSNLookUpService.ProjectAssets(ProjectID, ItemTypeID, StatusID).Result;
                this.BindingContext = AssetList;
            }         

        }
    }
}