using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using rpcwc.web.email;
using System.Text;

namespace rpcwc.web.SmallGroup
{
    public partial class Registration : Page
    {
        protected EmailSender _emailSender;


        public void Submit(Object source, EventArgs eventArgs)
        {
            StringBuilder body = new StringBuilder();
            body.Append("Name: ");
            body.Append(Request.Form["Name"]);
            body.Append("\nEmail: ");
            body.Append(Request.Form["email"]);
            body.Append("\nPhone: ");
            body.Append(Request.Form["phone"]);
            body.Append("\n");
            body.Append("Day Of Week: ");
            body.Append(Request.Form["dayofweek"]);
            body.Append("\n");
            body.Append("Day or Evening: ");
            body.Append(Request.Form["dayorevening"]);
            body.Append("\n");
            body.Append("Locale: ");
            body.Append(Request.Form["locale"]);
            body.Append("\n");
            emailSender.sendEmail(emailSender.pastorEmail, "", "Reformed Presbyterian Church Cluster Group Registration", body.ToString());
            Response.Redirect("sgresponse.aspx");
        }

        public EmailSender emailSender
        {
            get { return _emailSender; }
            set { _emailSender = value; }
        }
    }
}
