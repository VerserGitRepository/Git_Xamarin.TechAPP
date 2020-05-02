using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;

namespace TechApp2.Services
{
    public static class SSNLookUpService
    {
        public static async Task<AssetViewModel> SSNLookUpRequest(string ssn)
        {
            var responsedata = new AssetViewModel();
            // 15097672
            using (HttpClient client = new HttpClient())
            {
              
                HttpResponseMessage response = await client.GetAsync(string.Format("https://customers.verser.com.au/AssetManagementServicedev/inventorycontrol/assets/TechAPPSSNSearch/{0}", ssn));
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<AssetViewModel>(result);
                }  
            }
            return responsedata;
        }

        public static async Task<AssetViewModel> SerialNoSearchRequest(string serialno)
        {
            var responsedata = new AssetViewModel();
          //DV7V32S
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(string.Format($"https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/{serialno}/FindSerialNo"));
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<AssetViewModel>(result);
                }
            }
            return responsedata;
        }
    }
    
}
