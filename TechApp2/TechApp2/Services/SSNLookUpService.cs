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
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://customers.verser.com.au/AssetManagementService/inventorycontrol/assets/ssnlookup/{0}",ssn));
            responsedata = JsonConvert.DeserializeObject<AssetViewModel>(response);          
           
            return responsedata;
        }
    }
    
}
