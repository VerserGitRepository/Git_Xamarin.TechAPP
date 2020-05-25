using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class UpdateTechJobDto
    {
        
        public RatingDto Rating { get; set; }
        public byte[] ProjectLogo { get; set; }
        public List<RiskAssessmentDto> RiskAssess { get; set; }
        public List<JobDocumentsDto> Jobphots { get; set; }
        public List<AssetViewModel> AssetsList { get; set; }
        public UpdateTechJobDto()
        {

            Rating = new RatingDto();
            Jobphots = new List<JobDocumentsDto>();
            RiskAssess = new List<RiskAssessmentDto>();
        }
        public DateTime DateRaised { get; set; }
        public string JobNo { get; set; }
        public int Id { get; set; }
        public string CustomerSignatureVector  { get; set; }
        public byte[] CustomerSignatureImage { get; set; }
        public string TechnicianSignatureVector { get; set; }
        public byte[] TechnicianSignatureImage{ get; set; }
        public string UserName { get; set; }
        public string WorkInstructions { get; set; }
        public string TechnicianName { get; set; }
        public string CustomerName { get; set; }
        public string Department { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string ContactPerson { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }        
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string TechnicianComments { get; set; }
    }
}
