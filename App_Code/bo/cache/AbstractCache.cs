using System;
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
        private int _totalRefreshCount;
        private int _userRefreshCount;
        private int _hitCount;
        private TimeSpan _refreshTime;
        private TimeSpan _cacheTime;
        protected bool refreshing;

        public abstract void Refresh(bool visitorRefresh);
        
        public int TotalRefreshCount
        {
            get { return _totalRefreshCount; }
            set { _totalRefreshCount = value; }
        }

        public int UserRefreshCount
        {
            get { return _userRefreshCount; }
            set { _userRefreshCount = value; }
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
                if (_totalRefreshCount == 0)
                    return TimeSpan.Zero;

                return new TimeSpan(_refreshTime.Ticks / _totalRefreshCount);
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
                if (_totalRefreshCount == 0)
                    return TimeSpan.Zero;

                return new TimeSpan(AverageRefreshTime.Ticks * (HitCount - UserRefreshCount)) - CacheTime;
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
    }
}
