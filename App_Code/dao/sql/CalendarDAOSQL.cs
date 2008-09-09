using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using rpcwc.bo;
using rpcwc.dao;
using rpcwc.vo;
using Spring.Data.Common;
using Spring.Data.Objects;
using rpcwc.web;

/// <summary>
/// Summary description for CalendarDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class CalendarDAOSQL : RPCWCDAO, CalendarDAO
    {
        private static int SPECIAL_EVENT_CALENDAR_CHANNEL_ID = 3;
        private static int REGULAR_EVENT_CALENDAR_CHANNEL_ID = 8;
        private string _eventCalendarCommandString;
        private string _eventCalendarDatesCommandString;
        private string _eventFindDetailsPkSql;
        private string _eventFindFutureByChannelSql;
        private EventCalendarFindQuery _eventCalendarFindQuery;
        private EventFindQuery _eventFindQuery;
        private DateFindQuery _dateFindQuery;
        private EventPKFindQuery _eventPKFindQuery;
        private EventFindFutureByChannelQuery _eventFindFutureByChannelQuery;

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
                oneEvent.id = getInt16(reader, 0);
                oneEvent.date = getDateTime(reader, 1);
                oneEvent.title = getString(reader, 2);
                oneEvent.description = getString(reader, 3);
                oneEvent.allDayEvent = getBoolean(reader, 4);
                oneEvent.endDate = getDateTime(reader, 5);

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
                oneEvent.id = getInt16(reader, 0);
                oneEvent.date = getDateTime(reader, 1);
                oneEvent.title = getString(reader, 2);
                oneEvent.description = getString(reader, 3);

                return oneEvent;
            }
        }

        public class EventPKFindQuery : MappingAdoQuery
        {
            public EventPKFindQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("itemId", SqlDbType.SmallInt);
                Compile();
            }

            protected override object MapRow(IDataReader reader, int num)
            {
                Event oneEvent = new Event();
                oneEvent.id = getInt16(reader, 0);
                oneEvent.date = getDateTime(reader, 1);
                oneEvent.title = getString(reader, 2);
                oneEvent.allDayEvent = getBoolean(reader, 3);
                byte channel = getByte(reader, 4);
                oneEvent.specialEvent = channel == SPECIAL_EVENT_CALENDAR_CHANNEL_ID;
                oneEvent.author = getString(reader, 5);
                oneEvent.description = getString(reader, 6);

                return oneEvent;
            }
        }

        public class DateFindQuery : MappingAdoQuery
        {
            public DateFindQuery(IDbProvider dbProvider, String sql)
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
                IList titles = new ArrayList();
                titles.Add(new ArrayList());
                return new KeyValuePair<DateTime, IList>(getDateTime(reader, 1).Date, titles);
            }
        }

        public class EventFindFutureByChannelQuery : MappingAdoQuery
        {
            public EventFindFutureByChannelQuery(IDbProvider dbProvider, String sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("channelId", SqlDbType.TinyInt);
                Compile();
            }

            protected override object MapRow(IDataReader reader, int num)
            {
                Event oneEvent = new Event();
                oneEvent.id = getInt16(reader, 0);
                oneEvent.date = getDateTime(reader, 1);
                oneEvent.title = getString(reader, 2);
                oneEvent.allDayEvent = getBoolean(reader, 3);
                byte channel = getByte(reader, 4);
                oneEvent.specialEvent = channel == SPECIAL_EVENT_CALENDAR_CHANNEL_ID;
                oneEvent.author = getString(reader, 5);
                oneEvent.description = getString(reader, 6);

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

            IList events = eventCalendarFindQuery.QueryByNamedParam(parameterMap);

            foreach (Event oneEvent in events)
            {
                addToDate(eventCalendar, oneEvent.date.Date, CalendarUtil.createEventControl(oneEvent));
            }

            return eventCalendar;
        }

        public IList findEventsForDay(DateTime date)
        {
            IDictionary parameterMap = new Hashtable(4);
            parameterMap.Add("@startDate", date.Date);
            parameterMap.Add("@endDate", date.Date.AddDays(1).AddMinutes(-1));
            parameterMap.Add("@channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
            parameterMap.Add("@channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

            return eventFindQuery.QueryByNamedParam(parameterMap);
        }

        public IList findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            IDictionary parameterMap = new Hashtable(4);
            parameterMap.Add("@startDate", startDate.Date);
            parameterMap.Add("@endDate", endDate.Date);
            parameterMap.Add("@channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
            parameterMap.Add("@channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

            return eventFindQuery.QueryByNamedParam(parameterMap);
        }

        public Event findEventDetails(int itemId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@itemId", itemId);

            return (Event)eventPKFindQuery.QueryForObject(parameterMap);
        }

        public IDictionary findDatesByMonth(int year, int month)
        {
            IDictionary parameterMap = new Hashtable(4);
            parameterMap.Add("@startDate", new DateTime(year, month, 1).AddDays(-7));
            parameterMap.Add("@endDate", new DateTime(year, month, 1).AddMonths(1).AddDays(7));
            parameterMap.Add("@channelIdSpecial", SPECIAL_EVENT_CALENDAR_CHANNEL_ID);
            parameterMap.Add("@channelIdRegular", REGULAR_EVENT_CALENDAR_CHANNEL_ID);

            IDictionary<DateTime, IList> dates = new Dictionary<DateTime, IList>();

            IList dateMapList = dateFindQuery.QueryByNamedParam(parameterMap);

            foreach (KeyValuePair<DateTime, IList> pair in dateMapList)
            {
                if (!dates.ContainsKey(pair.Key))
                    dates.Add(pair.Key, pair.Value);
                else
                    dates[pair.Key].Add(pair.Value);
            }

            return (IDictionary)dates;
        }

        public IList findSpecialEventsFuture()
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", RPCConstants.Channels.SPECIAL_EVENT);

            return eventFindFutureByChannelQuery.QueryByNamedParam(parameterMap);
        }

        private EventCalendarFindQuery eventCalendarFindQuery
        {
            get
            {
                if (_eventCalendarFindQuery == null)
                    _eventCalendarFindQuery = new EventCalendarFindQuery(dbProvider, eventCalendarCommandString);
                return _eventCalendarFindQuery;
            }
        }

        private EventFindQuery eventFindQuery
        {
            get
            {
                if (_eventFindQuery == null)
                    _eventFindQuery = new EventFindQuery(dbProvider, eventCalendarCommandString);
                return _eventFindQuery;
            }
        }

        private EventPKFindQuery eventPKFindQuery
        {
            get
            {
                if (_eventPKFindQuery == null)
                    _eventPKFindQuery = new EventPKFindQuery(dbProvider, eventFindDetailsPkSql);
                return _eventPKFindQuery;
            }
        }
        private DateFindQuery dateFindQuery
        {
            get
            {
                if (_dateFindQuery == null)
                    _dateFindQuery = new DateFindQuery(dbProvider, eventCalendarDatesCommandString);
                return _dateFindQuery;
            }
        }

        private EventFindFutureByChannelQuery eventFindFutureByChannelQuery
        {
            get
            {
                if (_eventFindFutureByChannelQuery == null)
                    _eventFindFutureByChannelQuery = new EventFindFutureByChannelQuery(dbProvider, eventFindFutureByChannelSql);
                return _eventFindFutureByChannelQuery;
            }
        }

        private static void addToDate(EventCalendar eventCalendar, DateTime date, EventControl scheduledEvent)
        {
            if (eventCalendar.events[date] == null)
                eventCalendar.events[date] = new ArrayList();

            ((ArrayList)eventCalendar.events[date]).Add(scheduledEvent);
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

        public string eventFindDetailsPkSql
        {
            get
            {
                return _eventFindDetailsPkSql;
            }
            set
            {
                _eventFindDetailsPkSql = value;
            }
        }

        public string eventFindFutureByChannelSql
        {
            get
            {
                return _eventFindFutureByChannelSql;
            }
            set
            {
                _eventFindFutureByChannelSql = value;
            }
        }
    }
}
