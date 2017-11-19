using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using shopGuru_android.Extensions;
using shopGuru_android.Model;
using shopGuru_android.Properties;

namespace shopGuru_android.converters
{
    class TextToReceiptConverter
    {

        public static List<Item> ReadItemList(string receiptString)
        {
            List<Item> itemList = new List<Item>();
            float sum = 0;

            //receiptString = receiptString.ToLower();
            string pattern = @"([A-Za-z]{2}[A-Za-z]+.+)(\d+[\.\,]\d{2})(.[A|E|B|F|N|C]{1}(\b|\.))";
            receiptString.Replace("\r\n\r\n", "\r\n");
            string[] lines = Regex.Split(receiptString, pattern);
            List<string> linesList = new List<string>(lines);

            List<string> sublist = new List<string>();
            string prev = String.Empty;

            //string pattern2 = @".+(?= \d)"; //for item name
            //string pattern3 = @"\d+[,.]\d+(?= )"; //for price
            try
            {
                for (int i = 0; i<lines.Length;i++)
                {
                    Match firstMatch = Regex.Match(linesList[i], pattern, RegexOptions.Singleline);
                    if (firstMatch.Success)
                    {
                        Match secondMatch = Regex.Match(prev, @"(?!(.+)?\d{6,}(.+)?)^.+$", RegexOptions.Multiline);
                        if (secondMatch.Success)
                        {
                            itemList.Add(new Item
                            {
                                Name = prev + firstMatch.Groups[1].Value,
                                Price = decimal.Parse(firstMatch.Groups[2].Value.Replace(".",","))
                            });
                        
                        sublist = linesList.GetRange(i + 1, linesList.Count - i - 1);
                        break;
                        }
                        else
                        {
                            itemList.Add(new Item
                            {
                                Name = firstMatch.Groups[1].Value,
                                Price = decimal.Parse(firstMatch.Groups[2].Value.Replace(".", ","))
                            });
                            sublist = linesList.GetRange(i + 1, linesList.Count - i - 1);
                            break;
                        }
                    }
                    else
                    {
                        prev = linesList[i];
                    }
                }

                //working with text
                prev = String.Join(System.Environment.NewLine, sublist);
                prev = Regex.Replace(prev, @"\r", "");
                prev = Regex.Replace(prev, @"\n", " ");
                prev = Regex.Replace(prev, "›", ",");
                prev = Regex.Replace(prev, @"(\d+[\.\,]\d{2}.[A|E|B|F|N|C]{1}(\b|\.))", "$1" + System.Environment.NewLine);

                MatchCollection match = Regex.Matches(prev, pattern, RegexOptions.Multiline);
                if (match.Count != 0)
                {
                    foreach (Match m in match)
                    {
                        itemList.Add(new Item
                        {
                            Name = m.Groups[1].Value.Replace("\n", string.Empty),
                            Price = decimal.Parse(m.Groups[2].Value.Replace(".", ",")),
                        });
                    }
                }
                return itemList;
            }
            catch (FormatException)
            {
                throw new FormatException("format error, please try again");
            }

        }
    }
}