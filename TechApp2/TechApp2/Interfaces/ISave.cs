using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TechApp2.Interfaces
{
    public interface ISave
    {
        Task<string> Save(byte[] data, string thefileName);
    }
}
