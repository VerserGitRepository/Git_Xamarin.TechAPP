using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class InsightDeliverablesDto
    {

        public bool IsDataMigrated { get; set; }
        public bool IsOSUpgraded { get; set; }
        public bool IsDeliverablesConfigured { get; set; }
        public bool IsSoftwareInstalled { get; set; }
        public bool IsOSTested { get; set; }
        public bool IsFilesValidationCompleted { get; set; }
        public bool IsStoreCompleted { get; set; }
        public bool IsRevisitRequired { get; set; }

    }
}
