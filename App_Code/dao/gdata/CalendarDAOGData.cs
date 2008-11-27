using System;
using System.Collections.Generic;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Collections;
using rpcwc.vo;

namespace rpcwc.dao.gdata
{
    class CalendarDAOGData : CalendarDAO
    {
        private String _specialEventsURL;
        private String _regularEventsURL;

        public IList<Event> findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Event> events = getRegularEvents(startDate, endDate);
            events.AddRange(getSpecialEvents(startDate, endDate));
            events.Sort();
            return events;
        }

        public Event findEventDetails(int itemId)
        {
            return null;
        }

        private List<Event> getRegularEvents(DateTime startDate, DateTime endDate)
        {
            return getEvents(_regularEventsURL, startDate, endDate);
        }

        private List<Event> getSpecialEvents(DateTime startDate, DateTime endDate)
        {
            return getEvents(_specialEventsURL, startDate, endDate);
        }

        public IList<Event> findSpecialEventsFuture()
        {
            List<Event> events = getEvents(_specialEventsURL, DateTime.Now, DateTime.Now.AddYears(1).AddMonths(6));
            events.Sort();
            return events;
        }

        private List<Event> getEvents(String url, DateTime startDateTime, DateTime endDateTime)
        {
            // Create the query object:
            EventQuery query = new EventQuery();
            query.Uri = new Uri(url);
            query.SingleEvents = true;
            query.FutureEvents = false;
            query.StartTime = startDateTime;
            query.EndTime = endDateTime.Date.AddDays(1).AddSeconds(-1);
            query.NumberToRetrieve = 100;
            
            // Tell the service to query:
            EventFeed calFeed = getService().Query(query);
            AtomEntryCollection entries = calFeed.Entries;

            return mapEvents(entries);
        }

        private List<Event> mapEvents(AtomEntryCollection entries)
        {
            List<Event> events = new List<Event>();

            foreach (EventEntry entry in entries)
                foreach (When time in entry.Times)
                    events.Add(mapEvent(entry, time));

            return events;
        }

        private Event mapEvent(EventEntry entry, When time)
        {
            Event eventEntry = new Event();

            eventEntry.title = entry.Title.Text;
            eventEntry.description = entry.Content.Content;
            
            eventEntry.date = time.StartTime;
            eventEntry.endDate = time.EndTime;
            eventEntry.allDayEvent = time.AllDay;
            if (eventEntry.allDayEvent && eventEntry.endDate.Equals(eventEntry.date.AddDays(1)))
                eventEntry.endDate = eventEntry.endDate.AddDays(-1);
            eventEntry.active = entry.Status.Equals(EventEntry.EventStatus.CONFIRMED);
            
            //eventEntry.id = entry.Id.ToString();

            return eventEntry;
        }

        private CalendarService getService()
        {
            // Create a CalenderService and authenticate
            CalendarService googleCalendarService = new CalendarService("rpcwc-rpcwcorg-2");
            googleCalendarService.setUserCredentials("raymond.rishty@rpcwc.org", "Vert1go");
            return googleCalendarService;
        }

        public String regularEventsURL
        {
            get { return _regularEventsURL; }
            set { _regularEventsURL = value; }
        }

        public String specialEventsURL
        {
            get { return _specialEventsURL; }
            set { _specialEventsURL = value; }
        }
    }
}
