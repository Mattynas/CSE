using System;
using System.Text.RegularExpressions;
namespace shopGuru_android.Extensions
{
    public static class Extension
    {
        public static decimal StringToDecimal(this String numberString)
        {
            if (numberString.Contains(".")) numberString.Replace(".", ",");
            string pattern = @"(\d+)(\.\d{2})";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(numberString);

            string numb = match.Value;
            try
            {
                decimal number = Convert.ToDecimal(numb);
                return number;
            }
            catch(FormatException)
            {
                throw new FormatException("decimal value conversion exception");
            }
            //float number = float.Parse(numberString);

            
        }
    }
}
