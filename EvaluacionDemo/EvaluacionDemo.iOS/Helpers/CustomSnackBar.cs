using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using EvaluacionDemo.Helpers;
using EvaluacionDemo.iOS.Helpers;
using TTGSnackBar;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomSnackBar))]
namespace EvaluacionDemo.iOS.Helpers
{
    public class CustomSnackBar : ISnackBar
    {
        public async Task SnackError(string message)
        {
            var snackbar = new TTGSnackbar(message);
            snackbar.BackgroundColor = UIKit.UIColor.Green;
            snackbar.MessageTextColor = UIColor.White;
            snackbar.Duration = TimeSpan.FromSeconds(3);
            snackbar.Show();
        }

        public async Task SnackSuccess(string message)
        {
            var snackbar = new TTGSnackbar(message);
            snackbar.BackgroundColor = UIKit.UIColor.Red;
            snackbar.MessageTextColor = UIColor.White;
            snackbar.Duration = TimeSpan.FromSeconds(3);
            snackbar.Show();
        }
    }
}
