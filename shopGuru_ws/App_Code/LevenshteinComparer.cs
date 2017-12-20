using System;
using System.Collections.Generic;
using System.Linq;
using shopGuru_ws.Models;

/// <summary>
/// Gets similar label items from database
/// </summary>
public class LevenshteinComparer : IListComparer
{
    private ICollection<ItemPrice> unmatched;

    public ICollection<ItemPrice> Unmatched { get => unmatched; }

    public LevenshteinComparer() { }

    public HashSet<ItemPrice> CompareList(List<ItemPrice> list, int precision)
    {
        var matchedList = new HashSet<ItemPrice>();
        unmatched = new HashSet<ItemPrice>();

        using (SGEntities context = new SGEntities())
        {
            foreach (var item in list)
            {
                //Leaving only those items that starts with the same first letter;
                var tempList = context.Items.Where(x => x.label.StartsWith(item.name.Substring(0, 1))).ToList();
                bool matched = false;

                foreach (var dbItem in tempList)
                {
                    if (LevenshteinAlgorithm(item.name, dbItem.label, precision))
                    {
                        matched = true;
                        matchedList.Add(ItemPrice.GetItem(dbItem.label));
                        break;
                    }
                }

                if (!matched)
                {
                    unmatched.Add(item);
                }
            }
        }
        return matchedList;
    }

    public bool LevenshteinAlgorithm(string s, string t, int precision)
    {
        if (s == t) return true;

        int n = s.Length;
        int m = t.Length;

        int[,] d = new int[n + 1, m + 1];

        if (n == 0)
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

        return (d[n, m] < precision);
    }
}