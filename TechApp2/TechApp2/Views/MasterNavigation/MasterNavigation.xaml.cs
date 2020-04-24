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

            menu.Add(new MenuItems { OptionName = "Job List" });
            menu.Add(new MenuItems { OptionName = "SSN Search" });
            menu.Add(new MenuItems { OptionName = "Serial Number Search" });
            menu.Add(new MenuItems { OptionName = "Stats" });
            menu.Add(new MenuItems { OptionName = "Logout" });
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
                    case "Job List":
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
                    case "Serial Number Search":
                        {
                            Detail.Navigation.PushAsync(new SerialNoSearchView());
                            IsPresented = false;
                        }
                        break;
                    case "Stats":
                        {
                            Detail.Navigation.PushAsync(new Statastics());
                            IsPresented = false;
                        }
                        break;
                    case "Logout"://
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
    }


    public class MenuItems
    {
        public string OptionName { get; set; }
    }
}
