using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Model;
using TechApp2.Models;

namespace TechApp2.Services
{
    public static class DropDownListService
    {
        
        public static async Task<List<ListItems>> ProjectList()
        {
            List<ListItems> Projectslist = new List<ListItems>();

            //HttpClient httpClient = new HttpClient();
            //string Url = string.Format("https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/ProjectList");
            //var response = await httpClient.GetStringAsync(Url);
            //Projectslist = JsonConvert.DeserializeObject<List<ListItems>>(response);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/ProjectList");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
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
                HttpResponseMessage response = await client.GetAsync("https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/ItemTypeList");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
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
                HttpResponseMessage response = await client.GetAsync("https://customers.verser.com.au/AssetManagementServiceDev/inventorycontrol/TechAPP/AssetStatusList");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    assetStatus = JsonConvert.DeserializeObject<List<ListItems>>(result);
                }
            }
            return assetStatus;
        }
    }
}
