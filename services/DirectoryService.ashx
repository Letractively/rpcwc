<%@ WebHandler Language="C#" Class="DirectoryService" %>

using System;
using System.Web;
using System.Collections.Generic;
using rpcwc.bo;
using rpcwc.vo.directory;
using System.Web.Script.Serialization;

public class DirectoryService : IHttpHandler {
    public DirectoryManager DirectoryManager { get; set; }
    IDictionary<String, DirectoryServiceController> map = new Dictionary<String, DirectoryServiceController>();
    
    public void ProcessRequest (HttpContext context) {
        String field = context.Request.Params["Field"];
        String operation = context.Request.Params["operation"];
        String key = context.Request.Params["key"];
        String value = context.Request.Params["value"];

        IList<Directory> directory = DirectoryManager.getDirectory();
        
        JavaScriptSerializer js = new JavaScriptSerializer();
        
        context.Response.ContentType = "text/plain";
        context.Response.Write(js.Serialize(directory));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}