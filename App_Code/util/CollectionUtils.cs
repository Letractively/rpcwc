using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for CollectionUtils
/// </summary>
public static class CollectionUtils
{
    public static IDictionary map(ICollection collection, MapKeyCreator mapKeyCreator, bool mapAsLists)
    {
        IDictionary map = new Hashtable();

        foreach (Object obj in collection)
        {
            if (mapAsLists) {
                if (!map.Contains(mapKeyCreator.createKey(obj)))
                    map.Add(mapKeyCreator.createKey(obj), new ArrayList());
                ((IList) map[mapKeyCreator.createKey(obj)]).Add(obj);
            } else {
                map.Add(mapKeyCreator.createKey(obj), obj);
            }
        }

        return map;
    }

    public interface MapKeyCreator
    {
        Object createKey(Object obj);
    }
}
