using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace EvaluacionDemo.Behaviors
{
    public class ValidatePassword : Behavior<Entry>
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

            bool isValid = IsValid(args.NewTextValue);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.FromHex("#FBC5D0");

        }
        public bool IsValid(string emailaddress)
        {
            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{10,}$";
            Regex regex = new Regex(passwordRegex);
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
