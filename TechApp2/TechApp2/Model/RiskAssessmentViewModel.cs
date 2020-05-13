using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
    public class RiskAssessmentViewModel
    {
        public int Id { get; set; }
        public string RiskArea { get; set; }
        public string Rating { get; set; }
        public string OtherValue { get; set; }
        public string RiskAssessment_Job { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public DateTimeOffset? Created { get; set; }
    }
}
