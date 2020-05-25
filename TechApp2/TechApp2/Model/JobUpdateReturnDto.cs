using System;
using System.Collections.Generic;
using System.Text;

namespace TechApp2.Model
{
   public class JobUpdateReturnDto
    {
        public byte[] RetutnPDFFileContent { get; set; }
        public string RetutnPDFFileName { get; set; }
        public bool IsOperationSuccess { get; set; }
        public string ReturnMessage { get; set; }
    }
}
