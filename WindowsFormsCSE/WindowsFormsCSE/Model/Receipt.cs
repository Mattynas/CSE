using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WindowsFormsCSE.Properties;
using System.Windows.Forms;

namespace WindowsFormsCSE.Model
{
    public class Receipt
    {
        private List<Item> itemList;
        private string shopName;
        private string receiptString;

        public Receipt(string receiptString)
        {
            this.receiptString = receiptString;
            itemList = new List<Item>();
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

        public Item this[int index]
        {
            get => itemList[index];
            set => itemList[index] = value;
        }

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
                        float price = StringToFloat(Regex.Match(line, Resources.TEXTANALYSIS_pricePattern).ToString());

                        itemList.Add(new Item { Name = name, Price = price });
                    }
                }
            }
            catch(FormatException e)
            {
                MessageBox.Show(Resources.ERROR_wentWrong + "\r\n" + Resources.ERROR_retry);
            }

        }

        private float StringToFloat(string numberString)
        {
            if (numberString.Contains(".")) numberString.Replace(".", ",");

            float number = System.Convert.ToSingle(numberString);
            //float number = float.Parse(numberString);

            return number;
        }

        public string GetItemList()
        {
            string listString = "";
            int i = 1;
            foreach(var item in itemList)
            {
                listString += i.ToString() + ". Name: " + item.Name + " Price: " + item.Price.ToString() + "\r\n";
                i++;
            }

            return listString;
        }
    }
}
