using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.vo;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BlogCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class BlogCache : AbstractCache
    {
        private ItemDAO _itemDAO;
        private IBloggerDao _bloggerDao;
        private IList<Item> _blogEntries = new List<Item>();
        private IDictionary<String, IList<BlogEntry>> _blogEntriesMappedByLabel = new Dictionary<String, IList<BlogEntry>>();
        private IDictionary<String, IList<BlogEntry>> _newsAndNotesMappedByLabel = new Dictionary<String, IList<BlogEntry>>();
        private Object blogCacheLock = new Object();

        private const String NEWS_AND_NOTES_LABEL = "newsandnotes";

        delegate void RefresherDelegate();

        public class BlogEntryComparer : IComparer<Item>
        {
            #region IComparer<Item> Members

            public int Compare(Item item1, Item item2)
            {
                return item1.pubDate.CompareTo(item2.pubDate);
            }

            #endregion
        }

        public IList<Item> BlogEntries
        {
            get
            {
                if (!UpToDate)
                    Refresh(true);

                HitCount++;
                return _blogEntries;
            }
        }

        public override void Refresh(bool visitorRefresh)
        {
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

            List<Item> blogEntries = new List<Item>();

            IList<BlogEntry> sermonBlogEntries = BloggerDao.GetAllEntries();

            foreach (BlogEntry blogEntry in sermonBlogEntries)
            {
                Item blogItem = new Item();
                blogItem.author = blogEntry.Author;
                blogItem.pubDate = blogEntry.PubDate;
                blogItem.title = blogEntry.Title;
                blogItem.url = blogEntry.MediaUri;
                blogEntries.Add(blogItem);
            }

            blogEntries.Sort(new BlogEntryComparer());

            IDictionary<String, IList<BlogEntry>> blogEntriesMappedByLabel = MapBlogEntriesByLabel(sermonBlogEntries);
            IDictionary<String, IList<BlogEntry>> newsAndNotesMappedByLabel = MapNewsAndNotesByLabel(sermonBlogEntries);

            lock (blogCacheLock)
            {
                _blogEntries.Clear();
                ((List<Item>)_blogEntries).AddRange(blogEntries);
                _blogEntriesMappedByLabel = blogEntriesMappedByLabel;
                _newsAndNotesMappedByLabel = newsAndNotesMappedByLabel;
                LastRefresh = DateTime.Now;
            }

            RefreshTime += LastRefresh - startTime;
        }

        private IDictionary<String, IList<BlogEntry>> MapBlogEntriesByLabel(IList<BlogEntry> blogEntries)
        {
            IDictionary<String, IList<BlogEntry>> blogEntriesMappedByLabel = new Dictionary<String, IList<BlogEntry>>();

            foreach (BlogEntry blogEntry in blogEntries)
            {
                foreach (String category in blogEntry.Categories)
                {
                    if (!blogEntriesMappedByLabel.ContainsKey(category))
                        blogEntriesMappedByLabel.Add(category, new List<BlogEntry>());
                    blogEntriesMappedByLabel[category].Add(blogEntry);
                }
            }

            return blogEntriesMappedByLabel;
        }

        private IDictionary<String, IList<BlogEntry>> MapNewsAndNotesByLabel(IList<BlogEntry> blogEntries)
        {
            IDictionary<String, IList<BlogEntry>> newsAndNotesMappedByLabel = new Dictionary<String, IList<BlogEntry>>();

            foreach (BlogEntry blogEntry in blogEntries)
            {
                if (blogEntry.Categories.Contains(NEWS_AND_NOTES_LABEL))
                {
                    foreach (String category in blogEntry.Categories)
                    {
                        if (!newsAndNotesMappedByLabel.ContainsKey(category))
                            newsAndNotesMappedByLabel.Add(category, new List<BlogEntry>());
                        newsAndNotesMappedByLabel[category].Add(blogEntry);
                    }
                }
            }

            return newsAndNotesMappedByLabel;
        }

        public IList<BlogEntry> GetSermonPosts()
        {
            if (!UpToDate)
                Refresh(true);

            HitCount++;

            return _blogEntriesMappedByLabel[DaoConstants.SERMON];
        }

        /// <summary>
        /// Retrieves all blog posts from the sermon series marked by the given label
        /// </summary>
        /// <param name="label">This is a tag associated with blog posts, representing a sermon series</param>
        /// <returns>A list of blog posts in the sermon series</returns>
        public IList<BlogEntry> GetSermonPosts(String label)
        {
            if (!UpToDate)
                Refresh(true);

            HitCount++;

            if (!_blogEntriesMappedByLabel.ContainsKey(label))
                return new List<BlogEntry>();

            IList<BlogEntry> blogEntryList = _blogEntriesMappedByLabel[label];

            ArrayList.Adapter((IList)blogEntryList).Sort();

            return blogEntryList;
        }

        /// <summary>
        /// Retrieves all news and notes posts marked by the given label
        /// </summary>
        /// <param name="label">This is a tag associated with blog posts, representing a bulletin-week</param>
        /// <returns>A list of news and notes entries in the bulletin for the given week</returns>
        public IList<BlogEntry> GetNewsAndNotesEntries(String label)
        {
            if (!UpToDate)
                Refresh(true);

            HitCount++;

            if (!_newsAndNotesMappedByLabel.ContainsKey(label))
                return new List<BlogEntry>();

            IList<BlogEntry> blogEntryList = _newsAndNotesMappedByLabel[label];

            ArrayList.Adapter((IList)blogEntryList).Sort();

            return blogEntryList;
        }

        public ItemDAO itemDAO
        {
            private get
            {
                return _itemDAO;
            }
            set
            {
                _itemDAO = value;
            }
        }

        public IBloggerDao BloggerDao
        {
            private get { return _bloggerDao; }
            set { _bloggerDao = value; }
        }
    }
}