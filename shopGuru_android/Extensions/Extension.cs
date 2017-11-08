using System;

namespace shopGuru_android.Extensions
{
    public static class Extension
    {
        public static float StringToFloat(this String numberString)
        {
            if (numberString.Contains(".")) numberString.Replace(".", ",");

            float number = System.Convert.ToSingle(numberString);
            //float number = float.Parse(numberString);

            return number;
        }
    }
}
