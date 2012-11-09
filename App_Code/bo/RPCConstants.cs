
/// <summary>
/// Summary description for RPCConstants
/// </summary>
namespace rpcwc.bo
{
    public static class RPCConstants
    {
        public enum Channel:byte
        {
            SERMON_BLOG = 1,
            BLOG_COMMENTS = 2,
            SPECIAL_EVENT = 3,
            SERMON_AUDIO = 4,
            ALERTS = 5,
            PRAYER = 6,
            BULLETIN = 7,
            REGULAR_EVENT = 8,
            RECOMMENDED_READING = 9,
            NEWS_AND_NOTES = 10
        }
    }
}
