using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for CalendarDAO
/// </summary>
public class CalendarDAO
{
    private static int SPECIAL_EVENT_CALENDAR_CHANNEL_ID = 3;
    private static int REGULAR_EVENT_CALENDAR_CHANNEL_ID = 8;
    private static string eventCalendarCommandString = "SELECT pubDate, title, description FROM CALENDAR WHERE pubDate BETWEEN @startDate AND @endDate";
    private static string eventCalendarDatesCommandString = "SELECT i.pubDate, i.title FROM item i WHERE i.pubDate BETWEEN @startDate AND @endDate AND i.channel_id = @channelIdSpecial OR i.channel_id = @channelIdRegular";
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RPC"].ConnectionString);

    public static EventCalendar getEvents(int year, int month)
    {
        EventCalendar eventCalendar = new EventCalendar();
        eventCalendar.events = new Hashtable();
        connection.Open();
        //commandString
        SqlCommand eventCommand = new SqlCommand(eventCalendarCommandString, connection);
        eventCommand.Parameters.AddWithValue("startDate", new DateTime(year, month, 1));
        eventCommand.Parameters.AddWithValue("endDate", new DateTime(year, month, 1).AddMonths(1).AddMinutes(-1));
        eventCommand.Parameters.AddWithValue("channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
        eventCommand.Parameters.AddWithValue("channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

        SqlDataReader dataReader = eventCommand.ExecuteReader();
        while (dataReader.Read())
        {
            Event oneEvent = new Event();
            oneEvent.date = dataReader.GetDateTime(0);
            oneEvent.title = dataReader.GetString(1);
            oneEvent.description = dataReader.GetString(2);
            addToDate(eventCalendar, oneEvent.date.Date, new EventControl(oneEvent));
        }

        dataReader.Close();
        //String scripture = (String)scriptureCommand.ExecuteScalar();
        connection.Close();
        return eventCalendar;
    }

    public static WebControl findEvent(DateTime date)
    {
        connection.Open();
        //commandString
        SqlCommand eventCommand = new SqlCommand(eventCalendarCommandString, connection);
        eventCommand.Parameters.AddWithValue("startDate", date.Date);
        eventCommand.Parameters.AddWithValue("endDate", date.Date.AddDays(1).AddMinutes(-1));
        eventCommand.Parameters.AddWithValue("channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
        eventCommand.Parameters.AddWithValue("channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

        SqlDataReader dataReader = eventCommand.ExecuteReader();
        WebControl div = new WebControl(HtmlTextWriterTag.Div);
        div.Controls.Add(getDateHeader(date));
        while (dataReader.Read())
        {
            Event oneEvent = new Event();
            oneEvent.date = dataReader.GetDateTime(0);
            oneEvent.title = dataReader.GetString(1);
            oneEvent.description = dataReader.GetString(2);
            div.Controls.Add(new EventControl(oneEvent));
            //addToDate(eventCalendar, oneEvent.date.Date, new EventControl(oneEvent));
        }

        dataReader.Close();
        //String scripture = (String)scriptureCommand.ExecuteScalar();
        
        connection.Close();
        return div;
    }

    private static Control getDateHeader(DateTime date)
    {
        WebControl h4 = new WebControl(HtmlTextWriterTag.H4);
        Label label = new Label();
        label.Text = date.ToString("MMMM d, yyyy");
        h4.Controls.Add(label);

        return h4;
    }

    public static IDictionary findDatesByMonth(int year, int month)
    {
        IDictionary dates = new Hashtable();

        connection.Open();
        //commandString
        SqlCommand eventCommand = new SqlCommand(eventCalendarDatesCommandString, connection);
        eventCommand.Parameters.AddWithValue("startDate", new DateTime(year, month, 1).AddDays(-7));
        eventCommand.Parameters.AddWithValue("endDate", new DateTime(year, month, 1).AddMonths(1).AddDays(7));
        eventCommand.Parameters.AddWithValue("channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
        eventCommand.Parameters.AddWithValue("channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

        SqlDataReader dataReader = eventCommand.ExecuteReader();
        while (dataReader.Read())
        {
            DateTime dateToAdd = dataReader.GetDateTime(0).Date;
            if (!dates.Contains(dateToAdd))
                dates.Add(dateToAdd, dataReader.GetString(1));
            else
                dates[dateToAdd] += "\n" + dataReader.GetString(1);
        }

        dataReader.Close();
        connection.Close();
        return dates;
    }

    private static void addToDate(EventCalendar eventCalendar, DateTime date, EventControl scheduledEvent)
    {
        if (eventCalendar.events[date] == null)
            eventCalendar.events[date] = new ArrayList();

        ((ArrayList)eventCalendar.events[date]).Add(scheduledEvent);
    }
}
