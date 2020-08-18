﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechApp2.Model
{
  public  class JobListViewModel
    {
        public int Id { get; set; }
        public string TechnicianName { get; set; }
        public string JobNo { get; set; }
        public string JobStatus { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
     
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JobDate { get; set; }
        public Byte[] Logo
        {
            get;
            set;
        }
    }
}
