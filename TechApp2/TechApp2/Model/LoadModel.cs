using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class LoadModel
    {
        public int Id { get; set; }
        public string LoadNo { get; set; }
        public string LoadStatus { get; set; }
        public DateTime DateReceived { get; set; } = DateTime.Now;
        public int WarehouseId { get; set; }
        public int ProjectId { get; set; }
        public int? JobId { get; set; }
        public string Connote { get; set; }
        public string GRAPath { get; set; }
        public string ReceivingUser { get; set; }
        public string ClientPO { get; set; }
        public string ClientRef { get; set; }
        public int ProjectInventoryId { get; set; }
        public int? LeasingCustomerId { get; set; }
        public string Comments { get; set; }
        public int? EstimatedQty { get; set; }
        public int? AssetCount { get; set; }
        public DateTime? GRADate { get; set; }
    }
}
