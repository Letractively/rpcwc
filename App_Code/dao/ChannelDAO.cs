
/// <summary>
/// Summary description for ChannelDAO
/// </summary>
using rpcwc.vo;
namespace rpcwc.dao
{
    public interface ChannelDAO
    {
        Channel findChannel(int channelId);
    }
}
