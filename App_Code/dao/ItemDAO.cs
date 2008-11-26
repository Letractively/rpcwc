using System.Collections;
using System.Collections.Generic;
using rpcwc.vo;

/// <summary>
/// Summary description for ItemDAO
/// </summary>
namespace rpcwc.dao
{
    public interface ItemDAO
    {
        IList<Item> findItemsRSS(int channelId);
        IList<Item> findItemsPrayerRSS(int channelId);
        IList<Item> findItemsPodcast(int channelId);
        IList<Item> findAllActive(int channelId);
    }
}
