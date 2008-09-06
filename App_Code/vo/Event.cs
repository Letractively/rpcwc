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
namespace rpcwc.vo
{
    public class Event : RPCVO, IComparable
    {
        private DateTime _date;
        private DateTime _endDate;
        private String _title;
        private String _description;
        private String _author;
        private bool _allDayEvent;
        private bool _specialEvent;

        public Event()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            Event otherEvent = (Event) obj;

            if (allDayEvent && !otherEvent.allDayEvent)
                return -1;

            return date.CompareTo(otherEvent.date);
        }

        #endregion

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
        public DateTime endDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
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
        public String author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
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
        public bool specialEvent
        {
            get
            {
                return _specialEvent;
            }
            set
            {
                _specialEvent = value;
            }
        }
    }
}
