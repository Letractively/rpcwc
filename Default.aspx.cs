using System.Collections;
using rpcwc.bo;
using Spring.Context;
using Spring.Context.Support;
using System;

namespace rpcwc.web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected IDictionary dates;
        private CalendarManager _calendarManager;

        public _Default()
        {
            //IApplicationContext context = ContextRegistry.GetContext();
            //calendarManager = (CalendarManager)context.GetObject("CalendarManager");
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
}
