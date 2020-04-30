using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
    public class DispatchModel
    {
        public int Id { get; set; }
        public string DispatchNo { get; set; }       
        public DateTime? DispatchDate { get; set; }
        public string DispatchUser { get; set; }
    }
}
