﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Gms.Vision.Texts;
using System.Text.RegularExpressions;

namespace shopGuru_android.authenticator
{
    public static class LotteryTextValidation
    {
        private static string _receiptNumber;
        private static string _cashRegisterNumber;
        private static string _receiptDate;
        

        public static bool ValidateLotteryReceipt(SparseArray items)
        {
            List<string> itemStringList = new List<string>();

            for(int i = 0; i < items.Size(); i++)
            {
                var itemComponents = ((TextBlock)items.ValueAt(i)).Components;
                for (int j = 0; j < itemComponents.Count; j++)
                {
                    if(_cashRegisterNumber != null && _receiptDate != null && _receiptNumber != null)
                    {
                        return true;
                    }

                    var line = itemComponents[j].Value;
                    
                    if(_receiptNumber == null)
                    {
                        ReceiptNumberValidation(line);
                    } 

                    if(_receiptDate == null)
                    {
                        ReceiptDateValidation(line);
                    }

                    if(_cashRegisterNumber == null)
                    {
                        CashRegisterNumberValidation(line);
                    }
                }    

            }
            return false;
        }

        public static Dictionary<string,string> OnValidationComplete()
        {
            Dictionary<string,string> dictionary = new Dictionary<string, string>();

            dictionary["ticket_date"] = _receiptDate;
            dictionary["cash_register_number"] = _cashRegisterNumber;
            dictionary["check_number"] = _receiptNumber;

            _receiptDate = null;
            _cashRegisterNumber = null;
            _receiptNumber = null;
            return dictionary;
        }

        private static void ReceiptNumberValidation(string line)
        {
            string pattern = "([0-9]{5,7})";
            Regex regex = new Regex(pattern);
            Match m = regex.Match(line);
            _receiptNumber = m.Value;
        }
        
        private static void ReceiptDateValidation(string line)
        {
            string pattern = @"(\d{4}.\d{1,2}.\d{1,2})";
            Regex regex = new Regex(pattern);
            Match m = regex.Match(line);
            _receiptDate = m.Value;
        }
        private static void CashRegisterNumberValidation(string line)
        {
            string pattern = @"((RK|IP|WE|IK|LG|IU)\d{8})";
            Regex regex = new Regex(pattern);
            Match m = regex.Match(line);
            _cashRegisterNumber = m.Value;
        }
    }
}