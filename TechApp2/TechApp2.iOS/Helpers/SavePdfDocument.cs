using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp2.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TechApp2.iOS.Helpers.SavePdfDocument))]
namespace TechApp2.iOS.Helpers
{
    public class SavePdfDocument : ISave
    {
        public async Task<string> Save(byte[] data,string thefileName)
        {
            string root = null;
            string fileName = thefileName;
            root = await GetPath();
            //root = Path.Combine(root, iOS.OS.Environment.DirectoryDownloads);

          //  FileInfo file = new System.IO.FileInfo(root, fileName);
            string filePath = root +"/"+ thefileName;
            //if (file.Exists()) file.Delete();
            StreamWriter outs = new StreamWriter(filePath);
            outs.Write(data);
            //var ab = file.Path;
            outs.Flush();
            outs.Close();
            var text = File.ReadAllText(filePath);

            Console.WriteLine(text);
            return filePath;
        }
        static async Task<string> GetPath()
        {
            string root = "";
            //if (Android.OS.Environment.IsExternalStorageEmulated)
            //{
            //    root = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            //}
            //else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            // Task.FromResult is a placeholder for actual work that returns a string.
            root = await Task.FromResult(root);

            // The method then can process the result in some way.
           

            return root;
        }
    }
}