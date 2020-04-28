using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class JobDocumentViewModel
    {
        public int Id { get; set; }
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public int JobDocument_Job { get; set; }
    }
}
