using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterNavigationMaster : ContentPage
    {
        public ListView ListView;

        public MasterNavigationMaster()
        {
            InitializeComponent();

            BindingContext = new MasterNavigationMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterNavigationMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterNavigationMasterMenuItem> MenuItems { get; set; }

            public MasterNavigationMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterNavigationMasterMenuItem>(new[]
                {
                    new MasterNavigationMasterMenuItem { Id = 0, Title = "SSN Search" },
                    new MasterNavigationMasterMenuItem { Id = 1, Title = "Jobs List" },
                    new MasterNavigationMasterMenuItem { Id = 2, Title = "SerialNo" },
                    new MasterNavigationMasterMenuItem { Id = 3, Title = "Stats" },
                    new MasterNavigationMasterMenuItem { Id = 4, Title = "Logout" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void btnback_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new NavigationDashBoard());
        }
    }
}