using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsCSE.Model;
using System.Collections.Generic;

namespace WindowsFormsCSETests
{
    [TestClass]
    public class TextProcessing
    {
        [TestMethod]
        public void TextProcessingTest()
        {
            String receiptString = "Pienas 0,87 A";

            String testName = "Pienas";
            float testPrice = 0.87F;

            List<Item> itemList = new List<Item>();
            var item = new Item{ Name = testName, Price = testPrice };

            var receipt = new Receipt(receiptString);
            String.Format("name {0}, price {1}", receipt.ItemList[0].Name, receipt.ItemList[0].Price);
            
            Assert.AreEqual(item.Name, receipt.ItemList[0].Name);
            //Assert.AreEqual(Math.Round(item.Price,1), Math.Round(receipt.ItemList[0].Price,1));
        }
    }
}
