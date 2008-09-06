using System.Web;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.bo;


/// <summary>
/// Summary description for PodcastHttpHandler
/// </summary>
namespace rpcwc.web
{
    public class PodcastHttpHandler : IHttpHandler
    {
        private PodcastManager _podcastManager;

        public PodcastHttpHandler()
        {
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";

            context.Response.Write(podcastManager.getFeed(4));

        }

        #endregion

        public PodcastManager podcastManager
        {
            get
            {
                return _podcastManager;
            }
            set
            {
                _podcastManager = value;
            }
        }
    }
}
