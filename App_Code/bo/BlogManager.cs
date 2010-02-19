using System;
using System.Collections.Generic;
using rpcwc.bo.cache;
using rpcwc.vo;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BlogManager
/// </summary>
namespace rpcwc.bo
{
    public class BlogManager
    {
        private BlogCache _blogCache;

        public BlogCache BlogCache
        {
            get { return _blogCache; }
            set { _blogCache = value; }
        }

        /// <summary>
        /// Retrieves all blog posts from the sermon series marked by the given label
        /// </summary>
        /// <param name="label">This is a tag associated with blog posts, representing a sermon series</param>
        /// <returns>A list of blog posts in the sermon series</returns>
        public IList<BlogEntry> GetSermonPosts(String label)
        {
            return BlogCache.GetSermonPosts(label);
        }

        /// <summary>
        /// Retrieves blog post marked by the given id
        /// </summary>
        /// <param name="label">This is a unique identifier for the sermon blog post</param>
        /// <returns>A single blog posts for the sermon</returns>
        public BlogEntry GetSermonPost(String sermonid)
        {
            return BlogCache.GetSermonPost(sermonid);
        }
    
        public IList<Item> getBlogEntries()
        {
            return BlogCache.BlogEntries;
        }

        public IList<BlogEntry> GetSermonPosts()
        {
            return BlogCache.GetSermonPosts();
        }
        
        /*

        private ItemDAO _itemDAO;
        private IBloggerDao _bloggerDao;

        public BlogManager()
        {
        }

        public class BlogEntryComparer : IComparer
        {

            #region IComparer Members

            int IComparer.Compare(object item1, object item2)
            {
                return ((Item)item1).pubDate.CompareTo(((Item)item2).pubDate);
            }

            #endregion
        }

        public IList getBlogEntries()
        {
            ArrayList blogEntries = new ArrayList();
            //IList sermonBlogEntries = itemDAO.findItemsRSS(RPCConstants.Channels.SERMON_BLOG);
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

            //blogEntries.AddRange(sermonBlogEntries);

            blogEntries.Sort(new BlogEntryComparer());

            return blogEntries;
        }

        public IList<BlogEntry> GetSermonPosts()
        {
            return BloggerDao.GetEntriesByLabel(DaoConstants.SERMON);
        }

        /// <summary>
        /// Retrieves all blog posts from the sermon series marked by the given label
        /// </summary>
        /// <param name="label">This is a tag associated with blog posts, representing a sermon series</param>
        /// <returns>A list of blog posts in the sermon series</returns>
        public IList<BlogEntry> GetSermonPosts(String label)
        {
            IList<BlogEntry> blogEntryList = BloggerDao.GetEntriesByLabel(DaoConstants.SERMON, label);

            ArrayList.Adapter((IList)blogEntryList).Sort();

            return blogEntryList;
        }

        public ItemDAO itemDAO
        {
            get
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
            get { return _bloggerDao; }
            set { _bloggerDao = value; }
        }
         */
    }
}