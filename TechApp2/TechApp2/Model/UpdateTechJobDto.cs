using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class UpdateTechJobDto
    {
        
        public RatingDto Rating { get; set; }
        public List<RiskAssessmentDto> RiskAssess { get; set; }
        public List<JobDocumentsDto> Jobphots { get; set; }
        public UpdateTechJobDto()
        {

            Rating = new RatingDto();
            Jobphots = new List<JobDocumentsDto>();
            RiskAssess = new List<RiskAssessmentDto>();
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
