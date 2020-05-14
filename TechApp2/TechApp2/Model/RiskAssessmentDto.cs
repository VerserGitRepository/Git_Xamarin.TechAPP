using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
    public class RiskAssessmentDto
    {
        
        public string RiskArea { get; set; }
        public string Rating { get; set; }
      
        public string RiskAssessment_Job { get; set; }
        public string CreatedBy { get; set; }
       
        public DateTime Created { get; set; }
    }
}
