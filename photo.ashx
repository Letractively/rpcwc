<%@ WebHandler Language="C#" Class="photo" %>

using System;
using System.Web;
using rpcwc.dao.GData;

public class photo : IHttpHandler {
    private GDataDaoHelper _gDataDaoHelper;
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

    public GDataDaoHelper GDataDaoHelper
    {
        get { return _gDataDaoHelper; }
        set { _gDataDaoHelper = value; }
    }

}