﻿using System;
using System.Collections.Generic;
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
    public partial class JobDetailedJobParticulars : ContentPage
    {
        public static JobDetailsViewModel jobslistObject = new JobDetailsViewModel();
        //public event EventHandler Appearing;
        public JobDetailedJobParticulars()
        {
            InitializeComponent();            
        }
        public void PopulateJobDetails(object sender,EventArgs e)
        {
            jobslistObject = JobService.jobDetailsModel;
            if (jobslistObject.SiteName == null)
            {
                jobslistObject.SiteName = "350 Paramatta Rd Homebush NSW 2140";
            }
            //Console.WriteLine(jobslistObject);
            this.BindingContext = jobslistObject;
        }
        private void btninstructionDetails_Clicked(object sender, EventArgs e)
        {
            string workinstructiondata= LblJobWorkInstruction.Text.ToString();
            Navigation.PushModalAsync(new JobWorkInstructionDetails(workinstructiondata));
        }
        private async void SiteMap_Pressed(object sender, EventArgs e)
        {
            string site = jobslistObject.SiteName;
            if (!string.IsNullOrEmpty(site) )
            {   var SupportUri = await Launcher.CanOpenAsync("comgooglemaps://");
                Uri uri = new System.Uri($"http://maps.google.com/maps?q={site}");
                Launcher.OpenAsync(uri);
            }
        }
    }
}