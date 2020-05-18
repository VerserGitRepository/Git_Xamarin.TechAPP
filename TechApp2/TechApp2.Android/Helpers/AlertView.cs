﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TechApp2.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TechApp2.Droid.Helpers.AlertView))]
namespace TechApp2.Droid.Helpers
{
    public class AlertView : IAlertView
    {
        public void Show(string message)
        {
            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", message, "OK");
        }
    }
}