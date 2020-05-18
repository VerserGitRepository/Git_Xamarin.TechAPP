using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class JobAssetPhotesDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int JobAssetPhoto_JobAsset { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
