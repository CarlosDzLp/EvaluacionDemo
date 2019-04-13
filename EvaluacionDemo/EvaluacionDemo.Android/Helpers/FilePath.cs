using System;
using System.Diagnostics;
using DataAccessLayer.Helpers;
using EvaluacionDemo.Droid.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePath))]
namespace EvaluacionDemo.Droid.Helpers
{
    public class FilePath : IPathString
    {

        public string StringPath()
        {
            try
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, "demo.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
