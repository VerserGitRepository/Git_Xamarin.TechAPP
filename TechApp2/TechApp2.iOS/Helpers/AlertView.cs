using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TechApp2.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TechApp2.iOS.Helpers.AlertView))]
namespace TechApp2.iOS.Helpers
{
    public class AlertView : IAlertView
    {
        public void Show(string message)
        {
           Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", message, "OK");
        }
    }
}