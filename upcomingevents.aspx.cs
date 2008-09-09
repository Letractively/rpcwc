using System;
using System.Web.UI.WebControls;
using rpcwc.bo;
using Spring.Web.UI;

/// <summary>
/// Summary description for upcomingevents
/// </summary>
namespace rpcwc.web
{
    public partial class UpcomingEvents : Page
    {
        private CalendarManager _calendarManager;

        public void SetObjectDataSourceInstance(Object source, ObjectDataSourceEventArgs eventArgs)
        {
            eventArgs.ObjectInstance = calendarManager;
        }

        public CalendarManager calendarManager
        {
            get { return _calendarManager; }
            set { _calendarManager = value; }
        }
    }
}
