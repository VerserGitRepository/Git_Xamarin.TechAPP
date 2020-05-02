using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechApp2.Models;

namespace TechApp2.ServiceHelper
{
    public class LoginService
    {
        private  static string BaseUri = "https://customers.verser.com.au/JMSLoginManager/";
        //   string BaseUri = ConfigurationManager.AppSettings["LoginManagerBase"]; 
        public async static Task<LoginModel> Login(LoginModel login)
        {
            var returnmessage = new LoginModel();            
            var postdata = JsonConvert.SerializeObject(login);
            HttpContent content = new StringContent(postdata, System.Text.Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.PostAsync("https://customers.verser.com.au/JMSLoginManager/Login/AuthenticateUser", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    returnmessage = JsonConvert.DeserializeObject<LoginModel>(result);
                }
            }
            return returnmessage;
        }
        public async static Task<List<ListItems>> UserRoleList(string UserName)
        {
           var returnmessage = new List<ListItems>();         

            using (HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                HttpResponseMessage response = client.GetAsync(string.Format("Login/{0}/UserRole",UserName)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();                 
                    returnmessage = JsonConvert.DeserializeObject<List<ListItems>>(data) as List<ListItems>;               

                    //foreach (var p in result)
                    //{
                    //    returnmessage.Add(new ListItems() { Id = p.Id, Value = p.Value });
                    //}
                }
            }
            return returnmessage;
        }
    }
}

                   