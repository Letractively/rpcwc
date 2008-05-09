using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Event
/// </summary>
public class Event : RPCVO
{
    private DateTime _date;
    private String _title;
    private String _description;
    private bool _allDayEvent;

	public Event()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DateTime date
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }
    public String title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
    public String description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    public bool allDayEvent
    {
        get
        {
            return _allDayEvent;
        }
        set
        {
            _allDayEvent = value;
        }

    }
}
