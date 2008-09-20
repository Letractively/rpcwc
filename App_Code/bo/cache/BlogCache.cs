﻿using System;
using System.Collections.Generic;
using System.Web;
using rpcwc.dao;
using rpcwc.vo.Blog;
using System.Collections;
using rpcwc.vo;

/// <summary>
/// Summary description for BlogCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class BlogCache : AbstractCache
    {
        private ItemDAO _itemDAO;
        private IBloggerDao _bloggerDao;
        private IList _blogEntries = new ArrayList();
        private IDictionary<String, IList<BlogEntry>> _blogEntriesMappedByLabel = new Dictionary<String, IList<BlogEntry>>();
        private Object blogCacheLock = new Object();

        public class BlogEntryComparer : IComparer
        {
            #region IComparer Members

            int IComparer.Compare(object item1, object item2)
            {
                return ((Item)item1).pubDate.CompareTo(((Item)item2).pubDate);
            }

            #endregion
        }

        public IList BlogEntries
        {
            get
            {
                if (!UpToDate)
                    Refresh();

                HitCount++;
                return _blogEntries;
            }
        }

        public override void Refresh()
        {
            RefreshCount++;

            DateTime startTime = DateTime.Now;

            ArrayList blogEntries = new ArrayList();

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

            lock (blogCacheLock)
            {
                _blogEntries.Clear();
                ((ArrayList)_blogEntries).AddRange(blogEntries);
                _blogEntriesMappedByLabel = blogEntriesMappedByLabel;
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
                    ((IList<BlogEntry>)blogEntriesMappedByLabel[category]).Add(blogEntry);
                }
            }

            return blogEntriesMappedByLabel;
        }

        public IList<BlogEntry> GetSermonPosts()
        {
            if (!UpToDate)
                Refresh();

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
                Refresh();

            HitCount++;

            IList<BlogEntry> blogEntryList = _blogEntriesMappedByLabel[label];

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