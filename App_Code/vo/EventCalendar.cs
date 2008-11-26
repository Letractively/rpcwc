using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for EventCalendar
/// </summary>
namespace rpcwc.vo
{
    public class EventCalendar
    {
        //private IList _events;
        private IDictionary<DateTime, IList<Event>> _events;

        public IDictionary<DateTime, IList<Event>> events
        {
            get { return _events; }
            set { _events = value; }
        }
    }
}
