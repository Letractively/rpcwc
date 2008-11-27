using System;
using System.Collections.Generic;
using System.Reflection;
using rpcwc.bo.cache;

/// <summary>
/// Summary description for CacheManager
/// </summary>
namespace rpcwc.bo
{
    public class CacheManager
    {
        private IList<AbstractCache> _cacheList;
        private IDictionary<String, AbstractCache> _cacheMap;

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

        public void BeginRefreshers()
        {
            foreach (AbstractCache cache in CacheList)
            {
                if (cache.RefresherRunning)
                    cache.Refresh(false);
            }
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
    }
}