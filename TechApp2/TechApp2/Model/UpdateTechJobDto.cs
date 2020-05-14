using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class UpdateTechJobDto
    {
        
        public Rating rating { get; set; }
        public List<RiskAssessmentDto> RiskAssessment { get; set; }
        public JobAssetPhotesDto JobAssetPhots { get; set; }
        public UpdateTechJobDto()
        {

            rating = new Rating();
            JobAssetPhots = new JobAssetPhotesDto();
            RiskAssessment = new List<RiskAssessmentDto>();
        }
        public DateTime DateRaised { get; set; }
        public string JobNo { get; set; }
        public string CustomerSignatureImage { get; set; }
        public byte[] CustomerSignatureVector { get; set; }
        public string TechnicianSignatureImage { get; set; }
        public byte[] TechnicianSignatureVector { get; set; }
        
    }
}
