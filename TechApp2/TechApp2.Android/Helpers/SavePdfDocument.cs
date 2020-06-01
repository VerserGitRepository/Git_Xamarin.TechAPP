using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TechApp2.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TechApp2.Droid.Helpers.SavePdfDocument))]
namespace TechApp2.Droid.Helpers
{
    public class SavePdfDocument : ISave
    {
        public async Task<string> Save(byte[] data,string thefileName)
        {
            string root = null;
            string fileName = thefileName;
            root = await GetPath();
            root = Path.Combine(root, Android.OS.Environment.DirectoryDownloads);
          
            Java.IO.File file = new Java.IO.File(root, fileName);
            string filePath = file.Path;
            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
            outs.Write(data);
            var ab = file.Path;
            outs.Flush();
            outs.Close();
            return filePath;
        }
        static async Task<string> GetPath()
        {
            string root = "";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            // Task.FromResult is a placeholder for actual work that returns a string.
            root = await Task.FromResult<string>(root);

            // The method then can process the result in some way.
           

            return root;
        }
    }
}