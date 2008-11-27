using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for CollectionUtils
/// </summary>
public static class CollectionUtils
{
    public static IList<T> ConcatenateLists<T>(ICollection<IList<T>> lists)
    {
        List<T> concatenatedList = new List<T>();

        foreach (IList<T> list in lists)
        {
            concatenatedList.AddRange(list);
        }

        return concatenatedList;
    }

    public static IDictionary<TKey, TValue> Map<TKey, TValue>(ICollection<TValue> collection, MapKeyCreator<TKey, TValue> mapKeyCreator)
    {
        IDictionary<TKey, TValue> map = new Dictionary<TKey, TValue>();

        foreach (TValue obj in collection)
        {
            map.Add(mapKeyCreator.createKey(obj), obj);
        }

        return map;
    }

    public static IDictionary<TKey, IList<TValue>> MapAsLists<TKey, TValue>(ICollection<TValue> collection, MapKeyCreator<TKey, TValue> mapKeyCreator)
    {
        IDictionary<TKey, IList<TValue>> map = new Dictionary<TKey, IList<TValue>>();

        foreach (TValue obj in collection)
        {
            if (!map.ContainsKey(mapKeyCreator.createKey(obj)))
                map.Add(mapKeyCreator.createKey(obj), new List<TValue>());
            ((IList)map[mapKeyCreator.createKey(obj)]).Add(obj);
        }

        return map;
    }

    public interface MapKeyCreator<TKey, TValue>
    {
        TKey createKey(TValue obj);
    }
}
