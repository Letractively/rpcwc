<%@ WebHandler Language="C#" Class="music" %>

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class music : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}