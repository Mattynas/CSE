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
using shopGuru_android.interfaces;

namespace shopGuru_android.authenticator
{
    class ItemListComparer
    {
        public List<IItem> CompareLists(List<IItem> receiptList, List<IItem> dbList)
        {
            var matchedList = new List<IItem>();
            int precision = 5;

            foreach(var item in receiptList)
            {
                //Leaving only those items that starts with the same first letter;
                var tempList = receiptList.Where(x => x.Name.StartsWith(item.Name.Substring(0,1))).ToList();

                foreach(var dbItem in tempList)
                {
                    if(LevenshteinAlgorithm(item.Name, dbItem.Name, precision))
                    {
                        matchedList.Add(dbItem);
                    }
                }
            }

            return matchedList;
        }

        private bool LevenshteinAlgorithm(string s, string t, int precision)
        {
            int n = s.Length;
            int m = t.Length;

            int[,] d = new int[n + 1, m + 1];

            if(n == 0)
            {
                return (m < precision);
            }

            if (m == 0)
            {
                return (n < precision);
            }

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return (d[n,m] < precision);
        }

    }
}