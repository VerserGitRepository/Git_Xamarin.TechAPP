using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechApp2.Models;

namespace TechApp2.Services
{
    public static class DropDownListService
    {
        
        public static async Task<List<ListItems>> ProjectList()
        {
            List<ListItems> Projectslist = new List<ListItems>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{Settings.AMSBaseTechAPPURL}ProjectList").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false); 
                    Projectslist = JsonConvert.DeserializeObject<List<ListItems>>(result);
                }
            }
            return Projectslist;
        }

        public static async Task<List<ListItems>> ItemTypesList()
        {
            List<ListItems> itemtypes = new List<ListItems>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{Settings.AMSBaseTechAPPURL}ItemTypeList").ConfigureAwait(false); ;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false); ;
                    itemtypes = JsonConvert.DeserializeObject<List<ListItems>>(result);
                }
            }
            return itemtypes;
        }

        public static async Task<List<ListItems>> StatusList()
        {
            List<ListItems> assetStatus = new List<ListItems>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{Settings.AMSBaseTechAPPURL}AssetStatusList").ConfigureAwait(false); ;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false); 
                    assetStatus = JsonConvert.DeserializeObject<List<ListItems>>(result);
                }
            }
            return assetStatus;
        }
    }
}
