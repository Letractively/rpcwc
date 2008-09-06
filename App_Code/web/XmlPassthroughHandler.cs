using System.IO;
using System.Web;

/// <summary>
/// Summary description for HtmlRedirectHandler
/// </summary>
namespace rpcwc.web
{
    public class XmlPassthroughHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (File.Exists(context.Server.MapPath(context.Request.AppRelativeCurrentExecutionFilePath)))
            {
                context.Response.Buffer = true;
                context.Response.Clear();
                context.Response.Status = "200 OK";
                context.Response.ContentType = "text/xml";
                context.Response.WriteFile(context.Request.AppRelativeCurrentExecutionFilePath);
            }
            else
            {
                context.Response.Status = "404 Not Found";
            }
        }

        #endregion
    }
}
