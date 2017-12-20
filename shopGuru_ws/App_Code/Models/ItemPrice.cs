using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopGuru_ws.Models;

/// <summary>
/// Summary description for ItemPrice
/// </summary>
public struct ItemPrice
{
    public string name;
    public bool weightable;
    public decimal iki;
    public decimal maxima;
    public decimal rimi;

    public static ItemPrice GetItem(string label)
    {
        ItemPrice item = new ItemPrice();
        using (SGEntities context = new SGEntities())
        {
            LevenshteinComparer comp = new LevenshteinComparer();
            var items = from i in context.Items
                        join p in context.Prices
                        on i.id equals p.item
                        where comp.LevenshteinAlgorithm(i.label, label, 5)
                        select new {i.label, i.weightable, p.shop, p.price1 };
            foreach (var i in items)
            {
                if (i.shop == "Iki" || i.shop == "iki") item.iki = i.price1;
                if (i.shop == "Rimi" || i.shop == "rimi") item.rimi = i.price1;
                if (i.shop == "Maxima" || i.shop == "maxima") item.maxima = i.price1;
                if (i.weightable.HasValue) item.weightable = i.weightable.Value;
                else item.weightable = false;
                item.name = i.label;
            }
        }

        return item;
    }
}