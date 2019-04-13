using System;
using System.Diagnostics;
using System.IO;
using DataAccessLayer.Helpers;
using EvaluacionDemo.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePath))]
namespace EvaluacionDemo.iOS.Helpers
{
    public class FilePath : IPathString
    {
        public string StringPath()
        {
            try
            {
                string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, "demo.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
