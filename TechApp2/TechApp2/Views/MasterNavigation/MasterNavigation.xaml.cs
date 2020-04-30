using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TechApp2.Views;
using TechApp2.Models;

namespace TechApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterNavigation : MasterDetailPage
    {
        public string username
        {
            get { return (string)GetValue(userNameProperty); }
            set { SetValue(userNameProperty, value); }

        }
        List<MenuItems> menu;
        public MasterNavigation()
        {
            InitializeComponent();
            menu = new List<MenuItems>();
            
            menu.Add(new MenuItems { OptionName = "JOBS DASHBOARD" });
            menu.Add(new MenuItems { OptionName = "SSN LOOKUP" });
            menu.Add(new MenuItems { OptionName = "SERIALNO LOOKUP" });
            menu.Add(new MenuItems { OptionName = "SEARCH JOB" });
            menu.Add(new MenuItems { OptionName = "BLANCCO REPORT" });             
            menu.Add(new MenuItems { OptionName = "BROWSE ASSETS" });
            menu.Add(new MenuItems { OptionName = "STATISTICS" });
            menu.Add(new MenuItems { OptionName = "LOGOUT" });
            navigationList.ItemsSource = menu;
            Detail = new NavigationPage(new JobList());
            BindingContext = this;
            username ="Hello " + LoginDetails.UserID;
        }
        public static readonly BindableProperty userNameProperty = BindableProperty.Create("username", typeof(string), typeof(Assets), "");
        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;

                switch (item.OptionName)
                {
                    case "JOBS DASHBOARD":
                        {
                            Detail = new NavigationPage(new JobList());
                            IsPresented = true;                               
                        }
                        break;
                    case "SSN LOOKUP":
                        {
                            Detail = new NavigationPage(new Assets());
                            IsPresented = false;
                        }
                        break;
                    case "SERIALNO LOOKUP":
                        {
                            Detail.Navigation.PushAsync(new SerialNoSearchView());
                            IsPresented = false;
                        }
                        break;
                    case "SEARCH JOB":
                        {
                            Detail.Navigation.PushAsync(new SearchJobNo());
                            IsPresented = false;
                        }
                        break;
                        
                    case "BLANCCO REPORT":
                        {
                            Detail.Navigation.PushAsync(new BlancooReports());
                            IsPresented = false;
                        }
                        break;
                   
                    case "BROWSE ASSETS":
                        {
                            Detail.Navigation.PushAsync(new BroseAssets());
                            IsPresented = false;
                        }
                        break;
                    case "STATISTICS":
                        {
                            Detail.Navigation.PushAsync(new Statastics());
                            IsPresented = false;
                        }
                        break;
                    case "LOGOUT":
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
