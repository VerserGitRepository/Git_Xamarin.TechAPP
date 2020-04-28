﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;

namespace TechApp2.Services
{
   public static class JobService
    {
        public static string ListOfJobsURl = string.Format("https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/order/sthomas/TechAssignedJobs");
       // public static string jobDetailsURl = ""; //078102/FindJob
        public static async Task<List<JobListViewModel>> JobsListService()
        {
            List<JobListViewModel> jobslistObject = new List<JobListViewModel>();
            using ( HttpClient client = new HttpClient() )
            {
               var response= await client.GetStringAsync(ListOfJobsURl);
                jobslistObject = JsonConvert.DeserializeObject<List<JobListViewModel>>(response);
            }
            return jobslistObject;
        }
        public static async Task<JobDetailsViewModel> JobsDetailsService(string jobno)
        {
            var jobslistObject = new JobDetailsViewModel();
          string  jobDetailsURl = string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/{jobno}/FindJob");
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(jobDetailsURl);
                jobslistObject = JsonConvert.DeserializeObject<JobDetailsViewModel>(response);
            }
            return jobslistObject;
        }
    }
}
//
