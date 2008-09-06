using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for EventCalendar
/// </summary>
namespace rpcwc.vo
{
    public class EventCalendar
    {
        //private IList _events;
        private IDictionary _events;

        public EventCalendar()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public IDictionary events
        {
            get
            {
                return _events;
            }
            set
            {
                _events = value;
            }
        }

        /*

        public IList events
        {
            get {
                return _events;
            }
            set {
                _events = value;
            }
        }
         * */
    }
}
