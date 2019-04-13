using System;
using System.ComponentModel;
using CoreGraphics;
using EvaluacionDemo.Controls;
using EvaluacionDemo.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderEntry), typeof(BorderEntryRenderer))]
namespace EvaluacionDemo.iOS.Controls
{
    public class BorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (BorderEntry)Element;
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));

                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
                if (view != null)
                {
                    SetIcon(view);

                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (BorderEntry)Element;
            if (e.PropertyName == BorderEntry.IconProperty.PropertyName)
            {
                SetIcon(view);
            }
        }

        private void SetIcon(BorderEntry view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {

                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.LeftViewRect(new CGRect(5, 5, 5, 5));
                Control.LeftView = new UIImageView(UIImage.FromBundle(view.Icon));
            }
            else
            {
                Control.LeftViewMode = UITextFieldViewMode.Never;
                Control.LeftView = null;
            }
        }
    }
}
