using System;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CalendarManager
/// </summary>
public class CalendarManager
{
    private CalendarDAO _calendarDAO;

	public CalendarManager()
	{
        calendarDAO = new CalendarDAO();
		//
		// TODO: Add constructor logic here
		//
	}

    public static EventCalendar findEventsByMonth(int year, int month)
    {
        return CalendarDAO.getEvents(year, month);
        //return generateEventsForMonth(year, month);
    }

    public static IDictionary findDatesByMonth(int year, int month)
    {
        return CalendarDAO.findDatesByMonth(year, month);
    }

    public static WebControl findEvent(DateTime date)
    {
        return CalendarDAO.findEvent(date);
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
