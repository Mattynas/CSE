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
            var rectTextDictionary = new Dictionary<Rect, Android.Gms.Vision.Texts.TextBlock>();
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

            Stack<string> prevStack = new Stack<string>();
            bool match = false;
            string itemLine = "";
            try
            {
                for (int i = 0; i < rectArray.Count; i++)
                {
                    var box = (Rect)rectArray[i];

                    IList<IText> lineList = rectTextDictionary.GetValueOrDefault(box).Components;
                    foreach (var line in lineList)
                    {
                        var lineBox = line.BoundingBox;


                        if (match && prevStack.Count != 0)
                        {
                            prevStack.Clear();
                        }
                        match = false;

                        itemLine = "";
                        for (int j = i; j < rectArray.Count; j++)
                        {
                            var anotherBox = (Rect)rectArray[j];
                            IList<IText> anotherLineList = rectTextDictionary.GetValueOrDefault(anotherBox).Components;


                            foreach (var anotherLine in anotherLineList)
                            {
                                var anotherLineBox = anotherLine.BoundingBox;
                                if (System.Math.Abs(anotherLineBox.CenterY() - lineBox.CenterY()) < _epsilon && line.Value != anotherLine.Value)
                                {
                                    if (ValidatePriceString(anotherLine.Value))
                                    {
                                        string prevs = "";
                                        while (prevStack.Count != 0)
                                        {
                                            prevs += prevStack.Pop();
                                        }
                                        itemLine = string.Concat(prevs, System.String.Format("{0} {1} \n", line.Value, anotherLine.Value));
                                        AddToItemList(line.Value, anotherLine.Value, itemList);
                                    }
                                    else if (ValidatePriceString(line.Value))
                                    {
                                        string prevs = "";
                                        while (prevStack.Count != 0)
                                        {
                                            prevs += prevStack.Pop();
                                        }
                                        itemLine = string.Concat(prevs, System.String.Format("{1} {0} \n", line.Value, anotherLine.Value));
                                        AddToItemList(anotherLine.Value, line.Value, itemList);
                                    }
                                    else continue;

                                    match = true;
                                }
                            }
                        }
                        if (itemLine.Length != 0)
                        {
                            sb.Append(itemLine);
                        }
                        if (prevStack.Count != 0 && !(ValidatePriceString(prevStack.Peek())))
                        {
                            prevStack.Push(line.Value + " ");
                        }
                    }
                }
                return new Tuple<List<IItem>, string>(itemList, sb.ToString());
            }
            catch(Exception e )
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
        public static List<IItem> AddToItemList(string name,string price, List<IItem> itemList)
        {
            try
            {
                itemList.Add(new Item { Name = name, Price = price.StringToDecimal() });
                return itemList;
            }
            catch(FormatException)
            {
                return itemList;
            }
        }
    }
}