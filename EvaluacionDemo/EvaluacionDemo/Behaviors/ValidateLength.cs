using System;
using Xamarin.Forms;

namespace EvaluacionDemo.Behaviors
{
    public class ValidateLength : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = args.NewTextValue.Length >= 7;
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.FromHex("#FBC5D0");

        }
    }
}
