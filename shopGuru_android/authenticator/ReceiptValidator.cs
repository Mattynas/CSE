using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Gms.Vision.Texts;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using shopGuru_android.converters;
using shopGuru_android.Extensions;
using shopGuru_android.interfaces;
using shopGuru_android.Model;

namespace shopGuru_android.authenticator
{
    public class ReceiptValidator
    {
        public static List<IItem> itemList = new List<IItem>();
        private static Dictionary<IText,IText> dictionary = new Dictionary<IText,IText>();

        private static int thresholdY = 10;
        private static int thresholdX = 20;
        private static IText topRightPrice;
        private static IText bottomRightPrice;

        public static bool ValidatePriceString(string price)
        {
            string pattern = @"(\d+[\.\,]\d{2})(.[A|B|C|E|F|N]{1}(\b|\.))";
            return Regex.IsMatch(price, pattern);
        }

        public static List<IItem> ValidateItems(SparseArray items)
        {
            List<IText> lineList = new List<IText>();
            

            for (int i = 0; i < items.Size(); i++)
            {
                lineList.AddRange(((TextBlock)items.ValueAt(i)).Components);
            }
            topRightPrice = FindTopPrice(lineList);
            bottomRightPrice = FindBottomPrice(lineList);
            if (topRightPrice == null || bottomRightPrice == null)
            {
                return itemList;
            }
            var priceList = FindPriceList(lineList);

            foreach (var line in lineList.ToList())
            {
                if (topRightPrice.BoundingBox.CenterY() < line.BoundingBox.CenterY() &&
                   bottomRightPrice.BoundingBox.CenterY() > line.BoundingBox.CenterY())
                {
                    if(FindBelongingItem(line, priceList,itemList))
                    {
                        lineList.Remove(line);
                    }
                }
            }

            foreach(var line in lineList.ToList())
            {

            }

            return itemList;
        }

        public static IText FindTopPrice(List<IText> lineList)
        {
            int rightTopCord = 0;
            IText topRightText = null;
            foreach (var line in lineList)
            {
                if (ValidatePriceString(line.Value))
                {
                    if (rightTopCord == 0)
                    {
                        rightTopCord = line.BoundingBox.Top;
                        topRightText = line;
                    }
                    if (rightTopCord > line.BoundingBox.Top)
                    {
                        rightTopCord = line.BoundingBox.Top;
                        topRightText = line;
                    }
                }
            }
            return topRightText;
        }

        public static IText FindBottomPrice(List<IText> lineList)
        {
            int rightBotCord = 0;
            IText bottomRightText = null;
            foreach (var line in lineList)
            {
                if (ValidatePriceString(line.Value))
                {
                    if (rightBotCord == 0)
                    {
                        rightBotCord = line.BoundingBox.Bottom;
                        bottomRightText = line;
                    }
                    if (rightBotCord < line.BoundingBox.Bottom)
                    {
                        rightBotCord = line.BoundingBox.Bottom;
                        bottomRightText = line;
                    }
                }
            }
            return bottomRightText;

        }
        public static List<IText> FindPriceList(List<IText> lineList)
        {
            var priceList = new List<IText>();

            foreach (var line in lineList.ToList())
            {
                if (ValidatePriceString(line.Value))
                {
                    priceList.Add(line);
                    lineList.Remove(line);
                }
            }
            return priceList;
        }

        public static bool FindBelongingItem(IText line, List<IText> priceList, List<IItem> itemList)
        {
            foreach (var price in priceList.ToList())
            {
                if (Math.Abs(price.BoundingBox.CenterY() - line.BoundingBox.CenterY()) < thresholdY)
                {
                    if(CurrentListComparer(line.Value)) AddToItemList(line, price, itemList);
                    //priceList.Remove(price);
                    return true;
                }
            }
            return false;
        }

        public static List<IItem> AddToItemList(IText name, IText price, List<IItem> itemList)
        {
            try
            {
                itemList.Add(new Item { Name = name.Value, Price = price.Value.StringToDecimal() });
                return itemList;
            }
            catch (FormatException)
            {
                return itemList;
            }
        }

        public static bool CurrentListComparer(string line)
        {
            foreach (var item in itemList)
            {
                if (LevenshteinDistance.Compute(line, item.Name) < 8)
                {
                    return false;
                }
            }
            return true;
        }
    }
}