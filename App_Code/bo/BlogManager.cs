using System;
using System.Collections.Generic;
using System.Web;
using Spring.Context;
using Spring.Context.Support;
using System.Collections;
using rpcwc.vo;
using rpcwc.dao;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BlogManager
/// </summary>
namespace rpcwc.bo
{
    public class BlogManager
    {
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
    }
}