using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using Spring.Collections;
using rpcwc.bo.cache;
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
        private IDictionary _eventsMappedByMonth = new Hashtable();
        private IDictionary _eventsMappedByDate = new Hashtable();
        private CalendarDAO _calendarDAO;
        private static Object LOCK = new Object();

        delegate void RefresherDelegate();

        public override void Refresh(bool visitorRefresh)
        {
            refreshing = true;

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            if (!RefresherRunning)
            {
                RefresherDelegate refresherDelegate = RefreshAndSleep;
                refresherDelegate.BeginInvoke(delegate(IAsyncResult result) { }, null);
                RefresherRunning = true;
            }

            IDictionary dateMapList = new Hashtable(5);

            DateTime startTime = DateTime.Now;

            dateMapList.Add(new DateTime( DateTime.Today.Year, DateTime.Today.Month, 1), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today), DateUtils.getEndOfMonth(DateTime.Today)));
            dateMapList.Add(new DateTime( DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1 ), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today.AddMonths(-1)), DateUtils.getEndOfMonth(DateTime.Today.AddMonths(-1))));
            dateMapList.Add(new DateTime( DateTime.Today.AddMonths(1).Year, DateTime.Today.AddMonths(1).Month, 1 ), calendarDAO.findEventsByDateRange(DateUtils.getStartOfMonth(DateTime.Today.AddMonths(1)), DateUtils.getEndOfMonth(DateTime.Today.AddMonths(1))));

            EventsMappedByDate.Clear();
            foreach (IList events in dateMapList.Values)
            {
                foreach (Event eventObj in events)
                {
                    Object key = eventObj.date.Date;
                    if (!EventsMappedByDate.Contains(key))
                        EventsMappedByDate[key] = new ArrayList();

                    ((IList)EventsMappedByDate[key]).Add(eventObj);
                }
            }

            lock (LOCK)
            {
                EventsMappedByMonth = dateMapList;
            }

            LastRefresh = DateTime.Now;

            RefreshTime += LastRefresh - startTime;

            refreshing = false;
        }

        public IList findEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            ArrayList dates = new ArrayList();

            for (DateTime date = startDate; date.CompareTo(endDate) < 0; date = date.AddDays(1))
            {
                if (EventsMappedByDate.Contains(date))
                {
                    lock (LOCK)
                    {
                        dates.AddRange((IList)EventsMappedByDate[date]);
                    }
                }
            }

            CacheTime += DateTime.Now - startTime;

            return dates;
        }


        public IList findEventsByDate(DateTime date)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            HitCount++;

            if (!EventsMappedByDate.Contains(date))
                return null;
       
            IList dates = null;

            lock (LOCK)
            {
                dates = (IList)EventsMappedByDate[date];
            }

            return dates;
        }

        public IList findEventsByMonth(int year, int month)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            IList dateMap = null;

            lock (LOCK)
            {
                dateMap = (IList)EventsMappedByMonth[new DateTime(year, month, 1)];
            }

            CacheTime += DateTime.Now - startTime;

            return dateMap;
        }

        public IDictionary EventsMappedByMonth
        {
            get
            {
                return _eventsMappedByMonth;
            }
            set
            {
                _eventsMappedByMonth = value;
            }
        }

        public IDictionary EventsMappedByDate
        {
            get
            {
                return _eventsMappedByDate;
            }
            set
            {
                _eventsMappedByDate = value;
            }
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
}