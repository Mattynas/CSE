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
using System.Text.RegularExpressions;
using Android.Util;
using Android.Graphics;
using System.Collections;
using Android.Gms.Vision.Texts;
using shopGuru_android.interfaces;
using shopGuru_android.Model;
using shopGuru_android.Extensions;

namespace shopGuru_android.authenticator
{
    public class ReceiptTextValidation
    {
        private static List<IItem> _itemList = new List<IItem>();
        private static int _epsilon = 10;

        public static bool ValidatePriceString(string price)
        {
            string pattern = @"(\d+[\.\,]\d{2})(.[A|B|C|E|F|N]{1}(\b|\.))";
            return Regex.IsMatch(price, pattern);
        }
        public static Tuple<List<IItem>, string> ValidateItems(SparseArray items)
        {
            var rectTextDictionary = new Dictionary<Rect, TextBlock>();
            ArrayList rectArray = new ArrayList();
            List<IItem> itemList = new List<IItem>();

            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < items.Size(); i++)
            {
                var boundingBox = ((TextBlock)items.ValueAt(i)).BoundingBox;
                rectArray.Add(boundingBox);
                var textBlock = (TextBlock)items.ValueAt(i);
                rectTextDictionary.Add(boundingBox, textBlock);
            }

            List<IText> prevList = new List<IText>();
            bool match = false;
            string itemLine;
            IText prevText;
            try
            {
                for (int i = 0; i < rectArray.Count; i++)
                {
                    var box = (Rect)rectArray[i];

                    IList<IText> lineList = rectTextDictionary.GetValueOrDefault(box).Components;
                    foreach (var line in lineList)
                    {
                        var lineBox = line.BoundingBox;
                        itemLine = "";
                        match = false;
                        string prevs = "";


                        for (int j = i; j < rectArray.Count; j++)
                        {
                            var anotherBox = (Rect)rectArray[j];
                            IList<IText> anotherLineList = rectTextDictionary.GetValueOrDefault(anotherBox).Components;


                            foreach (var anotherLine in anotherLineList)
                            {
                                var anotherLineBox = anotherLine.BoundingBox;
                                if (System.Math.Abs(anotherLineBox.CenterY() - lineBox.CenterY()) < _epsilon && line.Value != anotherLine.Value)
                                {
                                    match = true;
                                    if (ValidatePriceString(anotherLine.Value))
                                    {
                                        foreach (var prev in prevList)
                                        {
                                            if (Math.Abs(prev.BoundingBox.Left - lineBox.Left) < 2 && Math.Abs(prev.BoundingBox.Bottom - lineBox.Top) < 6)
                                            {
                                                prevs = prev.Value;
                                                prevList.Remove(prev);
                                                break;
                                            }
                                        }
                                        itemLine = string.Concat(prevs, System.String.Format("{0} {1} \n", line.Value, anotherLine.Value));
                                        AddToItemList(prevs + line.Value, anotherLine.Value, itemList);
                                    }
                                    else if (ValidatePriceString(line.Value))
                                    {

                                        itemLine = string.Concat(prevs, System.String.Format("{1} {0} \n", line.Value, anotherLine.Value));
                                        AddToItemList(prevs + anotherLine.Value, line.Value, itemList);
                                    }
                                    else continue;
                                }
                            }
                        }
                        if (itemLine.Length != 0)
                        {
                            sb.Append(itemLine);
                        }
                        string lineVal = line.Value;

                        if (!match && !(ValidatePriceString(line.Value)) &&
                            !lineVal.Contains("PVM") && !lineVal.Contains("Kvitas") && !lineVal.Contains("kodas"))
                        {
                            prevList.Add(line);
                        }
                    }
                }
                return new Tuple<List<IItem>, string>(itemList, sb.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }


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
        public static List<IItem> AddToItemList(string name, string price, List<IItem> itemList)
        {
            try
            {
                itemList.Add(new Item { Name = name, Price = price.StringToDecimal() });
                return itemList;
            }
            catch (FormatException)
            {
                return itemList;
            }
        }
    }
}