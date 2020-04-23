using Newtonsoft.Json;
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
    }
}
