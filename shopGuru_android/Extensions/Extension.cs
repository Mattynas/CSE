using System;
using System.Globalization;
using System.Text.RegularExpressions;
namespace shopGuru_android.Extensions
{
    public static class Extension
    {
        public static decimal StringToDecimal(this String numberString)
        {
            string pattern = @"(\d+\,\d{2})";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(numberString);
            var style = NumberStyles.AllowDecimalPoint;

            string numb = match.Value;

            numb = numb.Replace(',', '.');

            try
            {
                decimal number = decimal.Parse(numb,style);
                //decimal number = Convert.ToDecimal(numb,CultureInfo.InvariantCulture);
                return number;
            }
            catch(FormatException)
            {
                throw new FormatException("decimal value conversion exception, Current string value:" + numb);
            }
            //float number = float.Parse(numberString);

            
        }
    }
}
