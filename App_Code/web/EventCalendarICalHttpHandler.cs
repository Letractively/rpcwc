using System;
using System.Collections;
using System.IO;
using System.Web;
using rpcwc.bo;
using rpcwc.vo;

/// <summary>
/// Summary description for EventCalendarICalHttpHandler
/// </summary>
namespace rpcwc.web
{
    public class EventCalendarICalHttpHandler : IHttpHandler
    {
        private CalendarManager _calendarManager;
        private String _prodId;
        private String _xWrCalName;

        private static String VERSION = "2.0";


        public EventCalendarICalHttpHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IHttpHandler Members

        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            StringWriter content = new StringWriter();

            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            DateTime startDate = DateTime.Today.AddDays(-DateTime.Today.Day);
            DateTime endDate = startDate.AddMonths(3);
            IList events = calendarManager.findEventsByDateRange(startDate, endDate);

            Response.ContentType = "text/calendar";
            //Response.ContentType = "text/plain";
            content.WriteLine("BEGIN:VCALENDAR");
            content.WriteLine("VERSION:" + VERSION);
            content.WriteLine("PRODID:" + prodId);
            content.WriteLine("CALSCALE:GREGORIAN");
            content.WriteLine("METHOD:PUBLISH");
            content.WriteLine("X-WR-CALNAME:" + xWrCalName);
            content.WriteLine("X-WR-TIMEZONE:America/New_York");
            content.WriteLine("BEGIN:VTIMEZONE");
            content.WriteLine("TZID:America/New_York");
            content.WriteLine("X-LIC-LOCATION:America/New_York");
            content.WriteLine("BEGIN:DAYLIGHT");
            content.WriteLine("TZOFFSETFROM:-0500");
            content.WriteLine("TZOFFSETTO:-0400");
            content.WriteLine("TZNAME:EDT");
            content.WriteLine("DTSTART:19700308T020000");
            content.WriteLine("RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=2SU");
            content.WriteLine("END:DAYLIGHT");
            content.WriteLine("BEGIN:STANDARD");
            content.WriteLine("TZOFFSETFROM:-0400");
            content.WriteLine("TZOFFSETTO:-0500");
            content.WriteLine("TZNAME:EST");
            content.WriteLine("DTSTART:19701101T020000");
            content.WriteLine("RRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU");
            content.WriteLine("END:STANDARD");
            content.WriteLine("END:VTIMEZONE");
            foreach (Event calendarEvent in events)
            {
                content.WriteLine("BEGIN:VEVENT");
                if (calendarEvent.allDayEvent)
                    content.WriteLine("DTSTART:" + calendarEvent.date.ToString("yyyyMMdd"));
                else
                    content.WriteLine("DTSTART:" + calendarEvent.date.ToUniversalTime().ToString("yyyyMMddTHHmmssZ"));

                if (calendarEvent.endDate != null && calendarEvent.endDate.Ticks > 0 && !calendarEvent.endDate.Equals(calendarEvent.date))
                {
                    if (calendarEvent.allDayEvent)
                        content.WriteLine("DTEND:" + calendarEvent.endDate.ToString("yyyyMMdd"));
                    else
                        content.WriteLine("DTEND:" + calendarEvent.endDate.ToUniversalTime().ToString("yyyyMMddTHHmmssZ"));
                }
                if (calendarEvent.description != null)
                    content.WriteLine("DESCRIPTION:" + calendarEvent.description.Replace("\n", " "));
                content.WriteLine("SUMMARY:" + calendarEvent.title);
                content.WriteLine("END:VEVENT");
            }

            content.WriteLine("END:VCALENDAR");

            Response.Write(content.ToString());
        }

        #endregion

        public CalendarManager calendarManager
        {
            get { return _calendarManager; }
            set { _calendarManager = value; }
        }

        public String prodId
        {
            get { return _prodId; }
            set { _prodId = value; }
        }

        public String xWrCalName
        {
            get { return _xWrCalName; }
            set { _xWrCalName = value; }
        }
    }
}