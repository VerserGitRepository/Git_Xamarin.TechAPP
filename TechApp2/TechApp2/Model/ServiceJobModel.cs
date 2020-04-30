using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class ServiceJobModel
    {
        public int Id { get; set; }
        public string JobNo { get; set; }
        public string ProjectName { get; set; }
        public string SiteName { get; set; }
        public string JobDate { get; set; }
        public string ClientRef { get; set; }
        public string ClientPO { get; set; }
        public string TicketType { get; set; }
        public string Status { get; set; }
        public int AssetCount { get; set; }
    }
}
