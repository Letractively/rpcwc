using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class DirectoryCache : AbstractCache {
        //private DirectoryDAO _directoryDao;
        private DirectoryManager _directoryManager;
        private IList<Directory> _directoryEntries;
        private IDictionary<String, Directory> _directoryEntriesMappedById;
        private static Object LOCK = new Object();

        delegate void RefresherDelegate();

        public class DirectoryByIdMapKeyCreator : CollectionUtils.MapKeyCreator<String, Directory>
        {
            public String createKey(Directory obj)
            {
                Directory directryEntry = (Directory)obj;
                return directryEntry.id;
            }
        }

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

            DateTime startTime = DateTime.Now;

            IList<Directory> directoryList = DirectoryManager.getDirectory();
            
            IDictionary<String, Directory> directoryEntriesMappedById =
                CollectionUtils.Map(directoryList, new DirectoryByIdMapKeyCreator());

            lock (LOCK)
            {
                DirectoryEntries.Clear();
                ((List<Directory>)DirectoryEntries).AddRange(directoryList);
                DirectoryEntriesMappedById.Clear();
                foreach (KeyValuePair<String, Directory> directoryEntry in directoryEntriesMappedById)
                {
                    DirectoryEntriesMappedById.Add(directoryEntry);
                }
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

        public Directory FindDirectoryEntryPk(string directoryId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            Directory directoryEntry = null;

            lock (LOCK)
            {
                if (DirectoryEntriesMappedById.ContainsKey(directoryId))
                {
                    directoryEntry = DirectoryEntriesMappedById[directoryId];
                }
            }

            CacheTime += DateTime.Now - startTime;

            return directoryEntry;
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

        public IDictionary<String, Directory> DirectoryEntriesMappedById
        {
            get
            {
                if (_directoryEntriesMappedById == null)
                    _directoryEntriesMappedById = new Dictionary<String, Directory>();
                return _directoryEntriesMappedById;
            }
        }
        /*
        public DirectoryDAO DirectoryDao
        {
            get { return _directoryDao; }
            set { _directoryDao = value; }
        }*/

        public DirectoryManager DirectoryManager
        {
            get { return _directoryManager; }
            set { _directoryManager = value; }
        }
    }
}
