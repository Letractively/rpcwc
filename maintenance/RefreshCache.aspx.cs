using System;
using rpcwc.bo;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.util;

namespace rpcwc.web.Maintenance
{
    public partial class RefreshCache : System.Web.UI.Page
    {
        private CacheManager _cacheManager;

        delegate void RefreshCacheDelegate(String cacheName);

        protected void Page_Load(object sender, EventArgs e)
        {
            String cacheName = Request.Params["cacheName"];
            RefreshCacheDelegate refreshCacheDelegate = DoRefresh;
            AsyncHelper.FireAndForget(refreshCacheDelegate, cacheName);
        }

        private void DoRefresh(String cacheName)
        {
            CacheManager.CacheMap[cacheName].Refresh(false);
        }

        public CacheManager CacheManager
        {
            get
            {
                if (_cacheManager == null)
                {
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    _cacheManager = (CacheManager)ctx.GetObject("CacheManager");
                }
                return _cacheManager;
            }
            set { _cacheManager = value; }
        }
    }
}
