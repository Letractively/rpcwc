using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using rpcwc.bo;

/// <summary>
/// Summary description for CalendarMaintenanceController
/// </summary>
namespace rpcwc.web
{
    public class CalendarMaintenanceController : IHttpHandler
    {
        private CalendarManager _calendarManager;
        private bool _isReusable;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
        }

        public void displayEdit(HttpRequest request, HttpResponse response)
        {
            String itemId = request["itemId"];
            TextBox x = new TextBox();

            response.Write(calendarManager.findEventDetails(Int16.Parse(itemId)));
        }

        public bool IsReusable
        {
            get { return _isReusable; }
            set { _isReusable = value; }
        }

        public CalendarManager calendarManager
        {
            get { return _calendarManager; }
            set { _calendarManager = value; }
        }

        public CalendarMaintenanceController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}