using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
    public class AssetViewModel
    {
        public int Id { get; set; }
        public string AssetID { get; set; }
        public string SSN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string Barcode { get; set; }
        public string ClientPO { get; set; }
        public string ClientRef { get; set; }
        public string AssetTag { get; set; }
        public string ClientAssetTag { get; set; }
        public int? ItemTypeId { get; set; }
        public int? LoadId { get; set; }
        public int ProjectId { get; set; }
        public int? WarehouseId { get; set; }
        public int? LocationId { get; set; }
        public int AssetStatusId { get; set; }
        public int? DispatchId { get; set; }
        public string Jobs { get; set; }
        public int? QtyOnHand { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? ExpectedSellPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public string Completeness { get; set; }
        public string Appearance { get; set; }
        public string Services { get; set; }
        public string Operability { get; set; }
        public DateTime? ConditionReportedDate { get; set; }
        public Nullable<DateTime> DateReceived { get; set; }
        public string ConditionReportedUser { get; set; }
        public double? DV { get; set; }
        public string Grade { get; set; }
        public string Condition { get; set; }
        public bool Recycle { get; set; }
        public bool IsTested { get; set; }
        public bool IsLeased { get; set; }
        public bool IsManualTest { get; set; }
        public bool IsModified { get; set; }
        public bool IDLocked { get; set; }
        public string ReservationComment { get; set; }
        public string PalletNo { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? ReservationCode { get; set; }
        public string R2Grade { get; set; }
        public string Asset_DispatchBoxNo { get; set; }
        public string AssetComment { get; set; }
    }
}
