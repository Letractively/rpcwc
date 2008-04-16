using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for HtmlRedirectHandler
/// </summary>
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
