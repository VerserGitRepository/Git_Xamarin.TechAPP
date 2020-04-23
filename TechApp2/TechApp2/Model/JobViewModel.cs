using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class JobViewModel
    {
        public int Id { get; set; }
        public string JobNo { get; set; }       
        public DateTime DateRaised { get; set; }
        public string ClientRef { get; set; }
        public string ClientPO { get; set; }
        public string JobType { get; set; }
        public string OrderComments { get; set; }
        public string WorkInstructions { get; set; }
        public bool IsExport { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
        public int? JobStatusId { get; set; }
        public int AssetCount { get; set; }
        public decimal? SellPrice { get; set; }
        public int? ProjectInventoryId { get; set; }
        public string ProjectInventoryName { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Department { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string ContactPerson { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string InvoiceNotes { get; set; }
        public string Severity { get; set; }
        public DateTime? ETA { get; set; }
        public string TicketType { get; set; }
        public string JobStatus { get; set; }
        public string SiteName { get; set; }
        public int? SiteId { get; set; }
        public string OpportunityNumber { get; set; }
    }
}
