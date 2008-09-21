using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;

/// <summary>
/// Summary description for AbstractCache
/// </summary>
namespace rpcwc.bo.cache
{
    public abstract class AbstractCache
    {
        private DateTime _lastRefresh;
        private bool _upToDate;
        private TimeSpan _refreshInterval;
        private int _refreshCount;
        private int _hitCount;
        private TimeSpan _refreshTime;
        private TimeSpan _cacheTime;
        private bool _refresherRunning;

        public abstract void Refresh(bool visitorRefresh);
        
        public void RefreshAndSleep()
        {
            do
            {
                Refresh(false);
                Thread.Sleep(RefreshInterval - new TimeSpan(0,5,0));
            } while (true);
        }

        public int RefreshCount
        {
            get { return _refreshCount; }
            set { _refreshCount = value; }
        }

        public TimeSpan RefreshTime
        {
            get { return _refreshTime; }
            set { _refreshTime = value; }
        }

        public TimeSpan CacheTime
        {
            get { return _cacheTime; }
            set { _cacheTime = value; }
        }

        public int HitCount
        {
            get { return _hitCount; }
            set { _hitCount = value; }
        }

        public TimeSpan AverageRefreshTime
        {
            get {
                if (_refreshCount == 0)
                    return TimeSpan.Zero;

                return new TimeSpan(_refreshTime.Ticks / _refreshCount);
            }
        }

        public TimeSpan AverageCacheTime
        {
            get
            {
                if (_hitCount == 0)
                    return TimeSpan.Zero;

                return new TimeSpan(_cacheTime.Ticks / _hitCount);
            }
        }

        public TimeSpan TimeSaved
        {
            get
            {
                if (_refreshCount == 0)
                    return TimeSpan.Zero;

                return new TimeSpan(AverageRefreshTime.Ticks * _hitCount) - (RefreshTime + CacheTime);
                //return new TimeSpan((AverageRefreshTime - AverageCacheTime).Ticks * (_hitCount - _refreshCount)) - CacheTime;
            }
        }

        public DateTime LastRefresh
        {
            get { return _lastRefresh; }
            set { _lastRefresh = value; }
        }

        public TimeSpan RefreshInterval
        {
            get { return _refreshInterval; }
            set { _refreshInterval = value; }
        }

        public bool UpToDate
        {
            get { return !_upToDate && LastRefresh.Add(RefreshInterval).CompareTo(DateTime.Now) > 0; }
            set { _upToDate = value; }
        }

        public bool RefresherRunning
        {
            get { return _refresherRunning; }
            set { _refresherRunning = value; }
        }
    }
}
