using System.Collections.Generic;
using shopGuru_ws.Models;

/// <summary>
/// Summary description for IListComparer
/// </summary>
public interface IListComparer
{
    ICollection<ItemPrice> Unmatched { get; }

    HashSet<ItemPrice> CompareList(List<ItemPrice> receipt, int precision);
}