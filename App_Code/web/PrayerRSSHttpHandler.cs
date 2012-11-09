using System.Web;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.bo;


/// <summary>
/// Summary description for PodcastHttpHandler
/// </summary>
namespace rpcwc.web
{
    public class PrayerRSSHttpHandler : IHttpHandler
    {
        private RSSManager _rssManager;

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";

            context.Response.Write(rssManager.getFeed(RPCConstants.Channel.PRAYER));
        }

        #endregion

        public RSSManager rssManager
        {
            get
            {
                return _rssManager;
            }
            set
            {
                _rssManager = value;
            }
        }
    }
}
