<%@ WebHandler Language="C#" Class="rpcwc.web.admin.GuestReport" %>

using System;
using System.Web;
using rpcwc.bo;

namespace rpcwc.web.admin
{
    public class GuestReport : IHttpHandler
    {
        public GuestRegistrationManager GuestRegistrationManager { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            String reportName = context.Request.Params["reportName"];
            GuestRegistrationManager.GenerateReport(reportName);
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}