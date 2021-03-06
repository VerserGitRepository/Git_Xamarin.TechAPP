﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Models;

namespace TechApp2.Services
{
    public static class JobService
    {
       // public static string ListOfJobsURl = string.Format();
        public static JobDetailsViewModel jobDetailsModel = new JobDetailsViewModel();

        public static async Task<List<JobListViewModel>> JobsListService()
        {
            List<JobListViewModel> jobslistObject = new List<JobListViewModel>();
            using ( HttpClient client = new HttpClient() )
            {
               //var response= await client.GetStringAsync(ListOfJobsURl);
                HttpResponseMessage response = await client.GetAsync($"{Settings.AMSBaseInventoryURL}order/{Settings.LastUsedUserId}/TechAssignedJobs");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    jobslistObject = JsonConvert.DeserializeObject<List<JobListViewModel>>(result);
                }                      
            }
            return jobslistObject;
        }
        public static async Task<JobDetailsViewModel> JobsDetailsService(string jobno)
        {
            var jobslistObject = new JobDetailsViewModel();
            
                string jobDetailsURl = string.Format($"{Settings.AMSBaseTechAPPURL}{jobno}/FindJob");
            using (HttpClient client = new HttpClient())
            {  
                HttpResponseMessage response = await client.GetAsync(jobDetailsURl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    jobslistObject = JsonConvert.DeserializeObject<JobDetailsViewModel>(result);
                }
            }
            JobService.jobDetailsModel = jobslistObject;
            return jobslistObject;
        }

        public static async Task<List<JobListViewModel>> JobsDetailsByUserDateService(string UserId,DateTime jobdate)
        {
            string _jobdate = jobdate.ToString("MM-dd-yyyy");
            var jobslistObject = new List<JobListViewModel>();
            string jobDetailsURl = string.Format($"{Settings.AMSBaseTechAPPURL}{LoginDetails.UserID}/{_jobdate}/JoblistByUserDate");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(jobDetailsURl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    jobslistObject = JsonConvert.DeserializeObject<List<JobListViewModel>>(result);
                }
            }
            return jobslistObject;
        }

        public static async Task<JobUpdateReturnDto> UpdateTechJob(UpdateTechJobDto theModel)
        {

            var postdata = JsonConvert.SerializeObject(theModel);
            JobUpdateReturnDto returnmessage = new JobUpdateReturnDto();
            HttpContent content = new StringContent(postdata, System.Text.Encoding.UTF8, "application/json");
            string jobDetailsURl = string.Format($"{Settings.AMSBaseTechAPPURL}UpdateTechJobWorkCompleted");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(jobDetailsURl,content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<JobUpdateReturnDto>().ConfigureAwait(false);
                    returnmessage = result;
                }
            }
            return returnmessage;
        }
    }
}

