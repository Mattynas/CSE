using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WindowsFormsCSE.Properties;
using System.Windows.Forms;
using WindowsFormsCSE.Extensions;

namespace WindowsFormsCSE.Model
{
    public class Receipt: IComparable
    {
        private List<Item> itemList;
        private string shopName;
        private string receiptString;
        private float sum = 0;



        public Receipt(string receiptString)
        {
            this.receiptString = receiptString;
            ItemList = new List<Item>();
            ReadItemList();
        }

        public string ShopName
        {
            get
            {
                return shopName;
            }
            set
            {
                shopName = value;
            }
        }

        public List<Item> ItemList { get => itemList; set => itemList = value; }

        public Item this[int index]
        {
            get => ItemList[index];
            set => ItemList[index] = value;
        }
        
        public float Sum { get => sum; }


        private void ReadItemList()
        {
            //receiptString = receiptString.ToLower();
            string pattern = @"\n";
            receiptString.Replace("\r\n\r\n", "\r\n");
            string[] lines = Regex.Split(receiptString, pattern);

            //string pattern2 = @".+(?= \d)"; //for item name
            //string pattern3 = @"\d+[,.]\d+(?= )"; //for price
            try
            {
                foreach (var line in lines)
                {
                    if (!line.Contains(" -"))
                    {
                        string name = Regex.Match(line, Resources.TEXTANALYSIS_namePattern).ToString();
                        //using extension method
                        float price = Regex.Match(line, Resources.TEXTANALYSIS_pricePattern).ToString().StringToFloat();
                        sum += price;
                        
                        ItemList.Add(new Item { Name = name, Price = price });
                    }
                }
            }
            catch(FormatException)
            {
                MessageBox.Show(Resources.ERROR_wentWrong + "\r\n" + Resources.ERROR_retry);
            }

        }


        public string GetItemList()
        {
            string listString = "";
            int i = 1;
            foreach(var item in ItemList)
            {
                listString += i.ToString() + ". Name: " + item.Name + " Price: " + item.Price.ToString() + "\r\n";
                i++;
            }
            
            return listString;
        }

        public int CompareTo(object obj)
        {
            Receipt otherReceipt = obj as Receipt;
            if (otherReceipt != null)
            {
                float otherSum = otherReceipt.Sum;
                return this.sum.CompareTo(otherSum);
            }
            else
            {
                throw new ArgumentException("Object is not a Receipt");
            }
        }
    }
}
