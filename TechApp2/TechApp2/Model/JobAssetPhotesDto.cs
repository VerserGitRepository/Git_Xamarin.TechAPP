using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class JobAssetPhotesDto
    {
        public DateTime Created { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public string JobAssetPhoto_JobAsset { get; set; }
    }
}
