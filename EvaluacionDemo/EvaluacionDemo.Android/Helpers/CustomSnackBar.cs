using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
using DataAccessLayer.Helpers;
using EvaluacionDemo.Droid.Helpers;
using EvaluacionDemo.Helpers;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(CustomSnackBar))]
namespace EvaluacionDemo.Droid.Helpers
{
    public class CustomSnackBar : ISnackBar
    {
        public  async Task SnackError(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Android.Support.Design.Widget.Snackbar snackBar = Android.Support.Design.Widget.Snackbar.Make(activityRootView, message, Snackbar.LengthLong);
            snackBar.SetActionTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
            Android.Views.View snackbarview = snackBar.View;
            snackbarview.SetBackgroundResource(Resource.Drawable.snackBackground);
            ViewGroup.MarginLayoutParams paramss = (ViewGroup.MarginLayoutParams)snackbarview.LayoutParameters;
            paramss.SetMargins(30, 0, 30, 40);
            snackbarview.SetBackground(
                MainActivity.CurrentActivity.ApplicationContext.GetDrawable(Resource.Drawable.snackBarError));
            snackBar.Show();
        }

        public async Task SnackSuccess(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Android.Support.Design.Widget.Snackbar snackBar = Android.Support.Design.Widget.Snackbar.Make(activityRootView, message, Snackbar.LengthLong);
            snackBar.SetActionTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
            Android.Views.View snackbarview = snackBar.View;
            snackbarview.SetBackgroundResource(Resource.Drawable.snackBackground);
            ViewGroup.MarginLayoutParams paramss = (ViewGroup.MarginLayoutParams)snackbarview.LayoutParameters;
            paramss.SetMargins(30, 0, 30, 40);
            snackbarview.SetBackground(
                MainActivity.CurrentActivity.ApplicationContext.GetDrawable(Resource.Drawable.snackBackground));
            snackBar.Show();
        }
    }
}
