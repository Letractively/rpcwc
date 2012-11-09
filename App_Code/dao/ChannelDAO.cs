
/// <summary>
/// Summary description for ChannelDAO
/// </summary>
using rpcwc.vo;
using rpcwc.bo;
namespace rpcwc.dao
{
    public interface ChannelDAO
    {
        Channel FindChannel(RPCConstants.Channel channel);
    }
}
