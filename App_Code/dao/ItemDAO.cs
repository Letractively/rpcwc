using System.Collections;
using System.Collections.Generic;
using rpcwc.vo;
using rpcwc.bo;

/// <summary>
/// Summary description for ItemDAO
/// </summary>
namespace rpcwc.dao
{
    public interface ItemDAO
    {
        IList<Item> FindItemsRSS(RPCConstants.Channel channel);
        IList<Item> FindItemsPrayerRSS(RPCConstants.Channel channel);
        IList<Item> FindItemsPodcast(RPCConstants.Channel channel);
        IList<Item> FindAllActive(RPCConstants.Channel channel);
    }
}
