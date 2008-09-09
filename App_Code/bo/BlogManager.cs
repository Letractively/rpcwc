using System;
using System.Collections.Generic;
using System.Web;
using Spring.Context;
using Spring.Context.Support;
using System.Collections;
using rpcwc.vo;
using rpcwc.dao;

/// <summary>
/// Summary description for BlogManager
/// </summary>
namespace rpcwc.bo
{
    public class BlogManager
    {
        private ItemDAO _itemDAO;

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
            blogEntries.AddRange(itemDAO.findItemsRSS(RPCConstants.Channels.SERMON_BLOG));

            blogEntries.Sort(new BlogEntryComparer());

            return blogEntries;
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
    }
}