using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechApp2.Interfaces
{
    public interface ISave
    {
        string Save(byte[] data, string thefileName);
    }
}
