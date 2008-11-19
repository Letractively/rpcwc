using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using rpcwc.dao;
using System.Collections.Generic;
using rpcwc.vo.directory;
using System.Collections;

/// <summary>
/// Summary description for DirectoryCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class DirectoryCache : AbstractCache {
        private DirectoryDAO _directoryDao;
        private IList<Directory> _directoryEntries;
        private static Object LOCK = new Object();

        public override void Refresh(bool visitorRefresh)
        {
            refreshing = true;

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            DateTime startTime = DateTime.Now;

            IList directoryEntries = DirectoryDao.getDirectory();
            IList<Directory> directoryList = new List<Directory>();
            foreach (Directory directoryEntry in directoryEntries)
            {
                directoryList.Add(directoryEntry);
            }

            lock (LOCK)
            {
                DirectoryEntries.Clear();
                ((List<Directory>)DirectoryEntries).AddRange(directoryList);
            }

            LastRefresh = DateTime.Now;

            RefreshTime += LastRefresh - startTime;

            refreshing = false;
        }

        public IList<Directory> FindDirectoryEntries()
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            List<Directory> directoryList = new List<Directory>();

            lock (LOCK)
            {
                directoryList.Clear();
                directoryList.AddRange(DirectoryEntries);
            }

            CacheTime += DateTime.Now - startTime;

            return directoryList;
        }

        public IList<Directory> DirectoryEntries
        {
            get
            {
                if (_directoryEntries == null)
                    _directoryEntries = new List<Directory>();
                return _directoryEntries;
            }
        }

        public DirectoryDAO DirectoryDao
        {
            get { return _directoryDao; }
            set { _directoryDao = value; }
        }
	
    }
}
