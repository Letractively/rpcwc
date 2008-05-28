using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Spring.Data.Common;
using Spring.Data.Core;
using Spring.Data.Objects;

/// <summary>
/// Summary description for CalendarDAO
/// </summary>
public class CalendarDAO
{
    private static int SPECIAL_EVENT_CALENDAR_CHANNEL_ID = 3;
    private static int REGULAR_EVENT_CALENDAR_CHANNEL_ID = 8;
    private string _eventCalendarCommandString;
    private string _eventCalendarDatesCommandString;
    //private SqlConnection _connection;
    private IDbCommand _eventCommand;
    private IDbCommand _eventDatesCommand;
    private IDbConnection _dbConnection;
    private IDbProvider _dbProvider;
    private AdoTemplate _adoTemplate;
    private EventCalendarFindQuery eventCalendarFindQuery;
    private EventFindQuery eventFindQuery;

    public CalendarDAO()
    {
        //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RPC"].ConnectionString);
        //dbProvider = DbProviderFactory.GetDbProvider("System.Data.SqlClient");
        dbConnection = DbProviderFactory.GetDbProvider("System.Data.SqlClient").CreateConnection();
        dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RPC"].ConnectionString;
        eventCommand = dbConnection.CreateCommand();
        eventDatesCommand = dbConnection.CreateCommand();
    }

    public class EventFindQuery : MappingAdoQuery
    {
        public EventFindQuery(IDbProvider dbProvider, String sql)
            : base(dbProvider, sql)
        {
            CommandType = CommandType.Text;
            DeclaredParameters = new DbParameters(dbProvider);
            DeclaredParameters.Add("startDate", SqlDbType.SmallDateTime);
            DeclaredParameters.Add("endDate", SqlDbType.SmallDateTime);
            DeclaredParameters.Add("channelIdSpecial", SqlDbType.TinyInt);
            DeclaredParameters.Add("channelIdRegular", SqlDbType.TinyInt);
            Compile();
        }

        protected override object MapRow(IDataReader reader, int num)
        {
            Event oneEvent = new Event();
            oneEvent.date = reader.GetDateTime(0);
            oneEvent.title = reader.GetString(1);
            if (!reader.IsDBNull(2))
                oneEvent.description = reader.GetString(2);
            if (!reader.IsDBNull(3))
                oneEvent.allDayEvent = reader.GetBoolean(3);

            return oneEvent;
        }
    }

    public class EventCalendarFindQuery : MappingAdoQuery
    {
        public EventCalendarFindQuery(IDbProvider dbProvider, String sql)
            : base(dbProvider, sql)
        {
            CommandType = CommandType.Text;
            DeclaredParameters = new DbParameters(dbProvider);
            DeclaredParameters.Add("startDate", SqlDbType.SmallDateTime);
            DeclaredParameters.Add("endDate", SqlDbType.SmallDateTime);
            DeclaredParameters.Add("channelIdSpecial", SqlDbType.TinyInt);
            DeclaredParameters.Add("channelIdRegular", SqlDbType.TinyInt);
            Compile();
        }

        protected override object MapRow(IDataReader reader, int num)
        {
            Event oneEvent = new Event();
            oneEvent.date = reader.GetDateTime(0);
            oneEvent.title = reader.GetString(1);
            if (!reader.IsDBNull(2))
                oneEvent.description = reader.GetString(2);

            return oneEvent;
        }
    }



    public EventCalendar getEvents(int year, int month)
    {
        IDictionary parameterMap = new Hashtable(4);
        parameterMap.Add("@startDate", new DateTime(year, month, 1));
        parameterMap.Add("@endDate", new DateTime(year, month, 1).AddMonths(1).AddMinutes(-1));
        parameterMap.Add("@channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
        parameterMap.Add("@channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

        EventCalendar eventCalendar = new EventCalendar();
        eventCalendar.events = new Hashtable();

        IList events = getEventCalendarFindQuery().QueryByNamedParam(parameterMap);

        foreach (Event oneEvent in events)
        {
            addToDate(eventCalendar, oneEvent.date.Date, new EventControl(oneEvent));
        }

        return eventCalendar;
    }

    public WebControl findEvent(DateTime date)
    {
        IDictionary parameterMap = new Hashtable(4);
        parameterMap.Add("@startDate", date.Date);
        parameterMap.Add("@endDate", date.Date.AddDays(1).AddMinutes(-1));
        parameterMap.Add("@channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
        parameterMap.Add("@channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

        WebControl div = new WebControl(HtmlTextWriterTag.Div);
        div.Controls.Add(getDateHeader(date));

        IList events = getEventFindQuery().QueryByNamedParam(parameterMap);

        foreach (Event oneEvent in events)
        {
            div.Controls.Add(new EventControl(oneEvent));
        }

        return div;
    }

    private EventCalendarFindQuery getEventCalendarFindQuery()
    {
        if (eventCalendarFindQuery == null)
            eventCalendarFindQuery = new EventCalendarFindQuery(dbProvider, eventCalendarCommandString);
        return eventCalendarFindQuery;
    }

    private EventFindQuery getEventFindQuery()
    {
        if (eventFindQuery == null)
            eventFindQuery = new EventFindQuery(dbProvider, eventCalendarCommandString);
        return eventFindQuery;
    }

    private Control getDateHeader(DateTime date)
    {
        WebControl h4 = new WebControl(HtmlTextWriterTag.H4);
        Label label = new Label();
        label.Text = date.ToString("MMMM d, yyyy");
        h4.Controls.Add(label);

        return h4;
    }

    public IDictionary findDatesByMonth(int year, int month)
    {
        IDictionary dates = new Hashtable();
        dbConnection.Open();
        eventDatesCommand.CommandText = eventCalendarDatesCommandString;

        eventDatesCommand.Parameters.Clear();
        eventDatesCommand.Parameters.Add(new SqlParameter("startDate", new DateTime(year, month, 1).AddDays(-7)));
        eventDatesCommand.Parameters.Add(new SqlParameter("endDate", new DateTime(year, month, 1).AddMonths(1).AddDays(7)));
        eventDatesCommand.Parameters.Add(new SqlParameter("channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID));
        eventDatesCommand.Parameters.Add(new SqlParameter("channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID));

        IDataReader dataReader = eventDatesCommand.ExecuteReader();
        while (dataReader.Read())
        {
            DateTime dateToAdd = dataReader.GetDateTime(0).Date;
            if (!dates.Contains(dateToAdd))
                dates.Add(dateToAdd, dataReader.GetString(1));
            else
                dates[dateToAdd] += "\n" + dataReader.GetString(1);
        }

        dataReader.Close();
        dbConnection.Close();
        return dates;
    }

    private static void addToDate(EventCalendar eventCalendar, DateTime date, EventControl scheduledEvent)
    {
        if (eventCalendar.events[date] == null)
            eventCalendar.events[date] = new ArrayList();

        ((ArrayList)eventCalendar.events[date]).Add(scheduledEvent);
    }

    public IDbCommand eventCommand
    {
        get
        {
            return _eventCommand;
        }
        set
        {
            _eventCommand = value;
        }
    }

    public IDbCommand eventDatesCommand
    {
        get
        {
            return _eventDatesCommand;
        }
        set
        {
            _eventDatesCommand = value;
        }
    }

    public string eventCalendarCommandString
    {
        get
        {
            return _eventCalendarCommandString;
        }
        set
        {
            _eventCalendarCommandString = value;
        }
    }

    public string eventCalendarDatesCommandString
    {
        get
        {
            return _eventCalendarDatesCommandString;
        }
        set
        {
            _eventCalendarDatesCommandString = value;
        }
    }

    public IDbConnection dbConnection
    {
        get
        {
            return _dbConnection;
        }
        set
        {
            _dbConnection = value;
        }
    }

    public IDbProvider dbProvider
    {
        get
        {
            return _dbProvider;
        }
        set
        {
            _dbProvider = value;
        }
    }

    public AdoTemplate adoTemplate
    {
        get
        {
            return _adoTemplate;
        }
        set
        {
            _adoTemplate = value;
        }
    }
}
