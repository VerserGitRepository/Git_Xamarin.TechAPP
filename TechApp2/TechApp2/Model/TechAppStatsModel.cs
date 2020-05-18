using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class TechAppStatsModel
    {
        public int AssetsReceivedCount { get; set; }
        public int AssetsTestedCount { get; set; }
        public int AssetsDispatchedCount { get; set; }
        public int JobsRaisedCount { get; set; }
        public int JobsCompletedCount { get; set; }
        public int JObsReadyTOInvoiceCount { get; set; }
        public int JObsInvoicedCount { get; set; }
        public int NuOrderOnOrderCount { get; set; }
        public int NuOrderProcessedCount { get; set; }
        public int NuOrderPendingCount { get; set; }
    }
}
