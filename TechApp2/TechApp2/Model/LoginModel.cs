using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechApp2.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
    }

    public static class LoginDetails
    {
        public static string UserID{ get; set; }
        public static bool _IsLoggedIn { get; set; }
    }
}