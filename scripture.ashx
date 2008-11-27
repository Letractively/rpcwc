<%@ WebHandler Language="C#" Class="scripture" %>

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

public class scripture : IHttpHandler {
    private String apiKey = "abadd0c82e7d0361";
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        //context.Response.Write("Hello World");

        StringBuilder sUrl = new StringBuilder();
        sUrl.Append("http://www.esvapi.org/v2/rest/passageQuery");
        sUrl.Append("?key="+apiKey);
        sUrl.Append("&passage=" + context.Request.Params["ref"]);
        //sUrl.Append("&action=doPassageQuery");
        sUrl.Append("&include-headings=true");
        sUrl.Append("&include-subheadings=false");
        sUrl.Append("&include-audio-link=false");
        sUrl.Append("&include-footnotes=false");
        sUrl.Append("&include-footnote-links=false");
    
        WebRequest oReq = WebRequest.Create(sUrl.ToString());
        StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

        StringBuilder sOut = new StringBuilder();
        sOut.Append(sStream.ReadToEnd());
        sStream.Close();
        
        sOut.Replace("h4>", "h5>");
        sOut.Replace("h2>", "h4>");
        
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.Cache.SetExpires(DateTime.Now.AddDays(7));
        context.Response.Cache.VaryByParams["ref"] = true;
        
        context.Response.Write(sOut.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}