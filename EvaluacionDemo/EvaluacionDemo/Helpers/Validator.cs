using System;
using System.Text.RegularExpressions;

namespace EvaluacionDemo.Helpers
{
    public static class Validator
    {
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool ValidateLegth(string text)
        {
            bool isValid = text.Length >= 7;
            return isValid;
        }
        public static bool ValidatePassword(string password)
        {
            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{10,}$";
            Regex regex = new Regex(passwordRegex);
            Match match = regex.Match(password);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
