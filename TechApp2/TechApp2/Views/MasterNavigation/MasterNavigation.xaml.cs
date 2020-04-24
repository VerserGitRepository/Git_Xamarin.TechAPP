using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TechApp2.Views;

namespace TechApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterNavigation : MasterDetailPage
    {
        List<MenuItems> menu;
        public MasterNavigation()
        {
            InitializeComponent();
            menu = new List<MenuItems>();

            menu.Add(new MenuItems { OptionName = "Jobs DashBoard" });
            menu.Add(new MenuItems { OptionName = "SSN Search" });
            menu.Add(new MenuItems { OptionName = "SerialNo" });
            menu.Add(new MenuItems { OptionName = "Search JOB" });
            menu.Add(new MenuItems { OptionName = "Repoprts" }); 
            menu.Add(new MenuItems { OptionName = "statistics" });
            menu.Add(new MenuItems { OptionName = "LogOut" });
            navigationList.ItemsSource = menu;
            Detail = new NavigationPage(new JobList());
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;

                switch (item.OptionName)
                {
                    case "Jobs DashBoard":
                        {
                            Detail = new NavigationPage(new JobList());
                            IsPresented = true;
                        }
                        break;
                    case "SSN Search":
                        {
                            Detail = new NavigationPage(new Assets());
                            IsPresented = false;
                        }
                        break;
                    case "SerialNo":
                        {
                            Detail.Navigation.PushAsync(new SerialNoSearchView());
                            IsPresented = false;
                        }
                        break;
                    case "Search JOB":
                        {
                            Detail.Navigation.PushAsync(new SearchJobNo());
                            IsPresented = false;
                        }
                        break;
                        
                    case "Repoprts":
                        {
                            Detail.Navigation.PushAsync(new BlancooReports());
                            IsPresented = false;
                        }
                        break;
                    case "statistics":
                        {
                            Detail.Navigation.PushAsync(new Statastics());
                            IsPresented = false;
                        }
                        break;
                    case "LogOut":
                        {
                            Application.Current.MainPage = new NavigationPage(new MainPage());
                            IsPresented = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBackToMenu_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MasterNavigation());
        }
    }


    public class MenuItems
    {
        public string OptionName { get; set; }
    }
}
