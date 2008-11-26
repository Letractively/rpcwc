using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.bo.cache;
using rpcwc.dao;
using rpcwc.vo;

/// <summary>
/// Summary description for CalendarManager
/// </summary>
namespace rpcwc.bo
{
    public class CalendarManager
    {
        private CalendarDAO _calendarDAO;
        private CalendarCache _calendarCache;

        public Event findEventForMaintenance(int itemId)
        {
            return calendarDAO.findEventDetails(itemId);
        }

        public IDictionary<DateTime, IList<Event>> findDatesByMonth(int year, int month)
        {
            IList<Event> events = CalendarCache.findEventsByMonth(year, month);
            
            CalendarUtil.EventByDateMapKeyCreator eventByDateMapKeyCreator = new CalendarUtil.EventByDateMapKeyCreator();
            return CollectionUtils.MapAsLists(events, eventByDateMapKeyCreator);
        }

        public IList<Event> findEventsForDay(DateTime date)
        {
            return CalendarCache.findEventsByDate(date);
        }

        public IList<Event> findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            return CalendarCache.findEventsByDateRange(startDate, endDate);
        }

        public IList<Event> findSpecialEventsFuture()
        {
            return calendarDAO.findSpecialEventsFuture();
        }

        private Event generateEvent(
            DateTime date,
            String description,
            String title
            )
        {
            Event thisEvent = new Event();
            thisEvent.date = date;
            thisEvent.description = description;
            thisEvent.title = title;
            return thisEvent;
        }

        private void addToDate(EventCalendar eventCalendar, DateTime date, Event scheduledEvent)
        {
            if (eventCalendar.events[date] == null)
                eventCalendar.events[date] = new List<Event>();

            eventCalendar.events[date].Add(scheduledEvent);
        }

        public Event findEventDetails(int itemId)
        {
            return calendarDAO.findEventDetails(itemId);
        }

        public CalendarDAO calendarDAO
        {
            get
            { return _calendarDAO; }
            set
            { _calendarDAO = value; }
        }

        public CalendarCache CalendarCache
        {
            get { return _calendarCache; }
            set { _calendarCache = value; }
        }
    }
}
