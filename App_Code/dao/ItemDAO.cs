using System.Collections;

/// <summary>
/// Summary description for ItemDAO
/// </summary>
namespace rpcwc.dao
{
    public interface ItemDAO
    {
        IList findItemsRSS(int channelId);
        IList findItemsPrayerRSS(int channelId);
        IList findItemsPodcast(int channelId);
        IList findAllActive(int channelId);
    }
}
