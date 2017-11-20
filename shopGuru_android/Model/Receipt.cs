using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using shopGuru_android.Properties;
using shopGuru_android.Extensions;
using shopGuru_android.interfaces;

namespace shopGuru_android.Model
{
    public class Receipt: IComparable
    {
        private List<IItem> itemList;
        private string shopName;
        private string receiptString;
        private float sum = 0;



        public Receipt(List<IItem> itemList, float sum, string rs, string sn)
        {
            receiptString = rs;
            this.sum = sum;
            shopName = sn;
            ItemList = itemList;
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

        public List<IItem> ItemList { get => itemList; set => itemList = value; }

        public IItem this[int index]
        {
            get => ItemList[index];
            set => ItemList[index] = value;
        }
        
        public float Sum { get => sum; }


       


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
