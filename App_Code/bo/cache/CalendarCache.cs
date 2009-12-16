using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.util;
using rpcwc.vo;

/// <summary>
/// Summary description for CalendarCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class CalendarCache : AbstractCache
    {
        private IDictionary<DateTime, IList<Event>> _eventsMappedByMonth = new Dictionary<DateTime, IList<Event>>();
        private IDictionary<DateTime, IList<Event>> _eventsMappedByDate = new Dictionary<DateTime, IList<Event>>();
        private CalendarDAO _calendarDAO;
        private static Object LOCK = new Object();

        public override void Refresh(bool visitorRefresh)
        {
            refreshing = true;

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            IDictionary<DateTime, IList<Event>> dateMapList = new Dictionary<DateTime, IList<Event>>(5);

            DateTime startTime = DateTime.Now;

            dateMapList.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today), DateUtils.getEndOfMonth(DateTime.Today)));
            dateMapList.Add(new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today.AddMonths(-1)), DateUtils.getEndOfMonth(DateTime.Today.AddMonths(-1))));
            dateMapList.Add(new DateTime(DateTime.Today.AddMonths(1).Year, DateTime.Today.AddMonths(1).Month, 1), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today.AddMonths(1)), DateUtils.getEndOfMonth(DateTime.Today.AddMonths(1))));

            IDictionary<DateTime, IList<Event>> eventsMappedByDate = CollectionUtils.MapAsLists(CollectionUtils.ConcatenateLists(dateMapList.Values), new CalendarUtil.EventByDateMapKeyCreator());

            lock (LOCK)
            {
                EventsMappedByMonth.Clear();

                foreach (KeyValuePair<DateTime, IList<Event>> events in dateMapList)
                {
                    EventsMappedByMonth[events.Key] = events.Value;
                }

                EventsMappedByDate.Clear();

                foreach (KeyValuePair<DateTime, IList<Event>> events in eventsMappedByDate)
                {
                    EventsMappedByDate[events.Key] = events.Value;
                }
            }

            LastRefresh = DateTime.Now;

            RefreshTime += LastRefresh - startTime;

            refreshing = false;
        }

        public IList<Event> findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            List<Event> dates = new List<Event>();

            for (DateTime date = startDate; date.CompareTo(endDate) < 0; date = date.AddDays(1))
            {
                if (EventsMappedByDate.ContainsKey(date))
                {
                    lock (LOCK)
                    {
                        dates.AddRange(EventsMappedByDate[date]);
                    }
                }
            }

            CacheTime += DateTime.Now - startTime;

            return dates;
        }

        public IList<Event> findEventsByDate(DateTime date)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            HitCount++;

            if (!EventsMappedByDate.ContainsKey(date))
                return null;

            IList<Event> dates = null;

            lock (LOCK)
            {
                dates = EventsMappedByDate[date];
            }

            return dates;
        }

        public IList<Event> findEventsByMonth(int year, int month)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            IList<Event> dateMap = null;

            lock (LOCK)
            {
                dateMap = EventsMappedByMonth[new DateTime(year, month, 1)];
            }

            CacheTime += DateTime.Now - startTime;

            return dateMap;
        }

        public IDictionary<DateTime, IList<Event>> EventsMappedByMonth
        {
            get { return _eventsMappedByMonth; }
            set { _eventsMappedByMonth = value; }
        }

        public IDictionary<DateTime, IList<Event>> EventsMappedByDate
        {
            get { return _eventsMappedByDate; }
            set { _eventsMappedByDate = value; }
        }

        public CalendarDAO calendarDAO
        {
            get { return _calendarDAO; }
            set { _calendarDAO = value; }
        }
    }
}