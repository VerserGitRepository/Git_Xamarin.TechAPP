using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
    public class AecomDto
    {

        public bool ImagingComplete { get; set; }
        public bool SoftwareApplicationsComplete { get; set; }
        public bool DataMigrationsComplete { get; set; }
        public bool Installation { get; set; }
        public bool EMailCheckComplete { get; set; }
        public bool CalenderCheckComplete { get; set; }
        public bool AddressBookCheckComplete { get; set; }
        public bool FavoritesCheckComplete { get; set; }
        public bool MyDocumentsCheckComplete { get; set; }
        public bool EMail2CheckComplete { get; set; }
        public bool Calender2CheckComplete { get; set; }
        public bool AddressBook2CheckComplete { get; set; }
        public string EnduserSignatureVector { get; set; }
        public byte[] EnduserSignatureImage { get; set; }
        public string StaffSignatureVector { get; set; }
        public byte[] StaffSignatureImage { get; set; }

    }
}
