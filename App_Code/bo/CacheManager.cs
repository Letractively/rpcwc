using System;
using System.Collections.Generic;
using System.Web;
using rpcwc.bo.cache;
using System.Reflection;
using System.Threading;

/// <summary>
/// Summary description for CacheManager
/// </summary>
namespace rpcwc.bo
{
    public class CacheManager
    {
        private IList<AbstractCache> _cacheList;
        private IDictionary<String, AbstractCache> _cacheMap;
        private bool _refreshersBegun = false;

        public IDictionary<String, Object> GetAttributes(AbstractCache cache)
        {
            IDictionary<String, Object> attributes = new Dictionary<String, Object>();
            foreach (PropertyInfo propertyInfo in cache.GetType().GetProperties())
            {
                attributes.Add(propertyInfo.Name, propertyInfo.GetValue(cache, null));
            }

            return attributes;
        }

        private IDictionary<String, AbstractCache> MapCacheList(IList<AbstractCache> cacheList)
        {
            IDictionary<String, AbstractCache> cacheMap = new Dictionary<String, AbstractCache>();

            foreach (AbstractCache cache in cacheList)
            {
                cacheMap.Add(cache.GetType().ToString(), cache);
            }

            return cacheMap;
        }

        delegate void RefresherDelegate(AbstractCache cache);

        public void BeginRefreshers()
        {
            if (RefreshersBegun)
                return;

            RefresherDelegate refresherDelegate = RefreshAndSleep;

            foreach(AbstractCache cache in CacheList)
                refresherDelegate.BeginInvoke(cache, delegate(IAsyncResult result) { }, null);

            RefreshersBegun = true;
        }

        private void RefreshAndSleep(AbstractCache cache)
        {
            do
            {
                cache.Refresh();
                Thread.Sleep(cache.RefreshInterval - new TimeSpan(0,5,0));
            } while (true);
        }

        public IList<AbstractCache> CacheList
        {
            get { return _cacheList;}
            set { _cacheList = value; }
        }

        public IDictionary<String, AbstractCache> CacheMap
        {
            get {
                if (_cacheMap == null)
                    _cacheMap = MapCacheList(CacheList);
                return _cacheMap;
            }
        }

        public bool RefreshersBegun
        {
            get { return _refreshersBegun; }
            set { _refreshersBegun = value; }
        }
    }
}