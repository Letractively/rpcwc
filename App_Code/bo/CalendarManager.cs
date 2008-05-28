using System;
using System.Collections;
using System.Web.UI.WebControls;
using Spring.Context;
using Spring.Context.Support;

/// <summary>
/// Summary description for CalendarManager
/// </summary>
public class CalendarManager
{
    private CalendarDAO _calendarDAO;

	public CalendarManager()
	{
	}

    public EventCalendar findEventsByMonth(int year, int month)
    {
        return calendarDAO.getEvents(year, month);
        //return generateEventsForMonth(year, month);
    }

    public IDictionary findDatesByMonth(int year, int month)
    {
        return calendarDAO.findDatesByMonth(year, month);
    }

    public WebControl findEvent(DateTime date)
    {
        return calendarDAO.findEvent(date);
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
}
