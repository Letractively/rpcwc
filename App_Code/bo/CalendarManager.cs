using System;
using System.Collections;
using System.Web.UI.WebControls;
using Spring.Context;
using Spring.Context.Support;
using System.Web.UI;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.vo;
using rpcwc.util;

/// <summary>
/// Summary description for CalendarManager
/// </summary>
namespace rpcwc.bo
{
    public class CalendarManager
    {
        private CalendarDAO _calendarDAO;

        public CalendarManager()
        {
        }

        public Event findEventForMaintenance(int itemId)
        {
            return calendarDAO.findEventDetails(itemId);
        }

        /*public EventCalendar findEventsByMonth(int year, int month)
        {
            return calendarDAO.getEvents(year, month);
            //return generateEventsForMonth(year, month);
        }*/

        public IDictionary findDatesByMonth(int year, int month)
        {
            IList events = calendarDAO.findEventsByDateRange(DateUtils.getSundayBefore(new DateTime(year,month,1)),DateUtils.getSaturdayAfter(new DateTime(year,month,1).AddMonths(1)));
            return CollectionUtils.map(events, new CalendarUtil.EventByDateMapKeyCreator(), true);
            //return calendarDAO.findDatesByMonth(year, month);
        }

        public IList findEventsForDay(DateTime date)
        {
            return findEventsByDateRange(date.Date, date.Date.AddDays(1).AddSeconds(-1));
            //return calendarDAO.findEventsForDay(date);
        }

        public IList findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            return calendarDAO.findEventsByDateRange(startDate, endDate);
        }

        public IList findSpecialEventsFuture()
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
                eventCalendar.events[date] = new ArrayList();

            ((ArrayList)eventCalendar.events[date]).Add(scheduledEvent);
        }

        public CalendarDAO calendarDAO
        {
            get
            {
                return _calendarDAO;
            }
            set
            {
                _calendarDAO = value;
            }
        }

        public Event findEventDetails(int itemId)
        {
            return calendarDAO.findEventDetails(itemId);
        }
    }
}
