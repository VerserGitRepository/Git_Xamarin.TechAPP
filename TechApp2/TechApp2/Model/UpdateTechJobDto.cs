using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class UpdateTechJobDto
    {
        
        public RatingDto Rating { get; set; }
        public List<RiskAssessmentDto> RiskAssessment { get; set; }
        public List<JobDocumentsDto> JobAssetPhots { get; set; }
        public UpdateTechJobDto()
        {

            Rating = new RatingDto();
            JobAssetPhots = new List<JobDocumentsDto>();
            RiskAssessment = new List<RiskAssessmentDto>();
        }
        public DateTime DateRaised { get; set; }
        public string JobNo { get; set; }
        public int Id { get; set; }
        public string CustomerSignatureImage { get; set; }
        public byte[] CustomerSignatureVector { get; set; }
        public string TechnicianSignatureImage { get; set; }
        public byte[] TechnicianSignatureVector { get; set; }
        public string UserName { get; set; }
        
    }
}
