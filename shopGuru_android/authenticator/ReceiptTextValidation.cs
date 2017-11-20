using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using shopGuru_android.converters;
using shopGuru_android.Exceptions.Process;

namespace shopGuru_android.authenticator
{
    public class ReceiptTextValidation
    {
        public static bool CheckTextResult(string text)
        {
            try
            {
                if (TextToReceiptConverter.ReadItemList(text).Count != 0)
                {
                    return true;
                }
                else return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ReceiptNotReadableException)
            {
                return false;
            }
        }
    }
}