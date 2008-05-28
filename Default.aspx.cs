using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using Spring.Context;
using Spring.Context.Support;

public partial class _Default : System.Web.UI.Page
{
    protected IDictionary dates;
    private CalendarManager _calendarManager;

    public _Default()
    {
        IApplicationContext context = ContextRegistry.GetContext();
        calendarManager = (CalendarManager)context.GetObject("CalendarManager");
    }

    public CalendarManager calendarManager
    {
        get
        {
            return _calendarManager;
        }
        set
        {
            _calendarManager = value;
        }
    }
}
