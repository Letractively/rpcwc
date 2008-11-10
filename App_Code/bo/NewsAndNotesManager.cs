using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.dao;
using rpcwc.bo.cache;
using rpcwc.util;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for NewsAndNotesManager
/// </summary>
namespace rpcwc.bo
{
    public class NewsAndNotesManager
    {
        private ItemDAO _itemDAO;

        private BlogCache _blogCache;

        public IList<BlogEntry> findAllNewsAndNotesActive()
        {
            //return itemDAO.findAllActive(RPCConstants.Channels.NEWS_AND_NOTES);
            return BlogCache.GetNewsAndNotesEntries(DateUtils.getSundayBefore(DateTime.Today).ToString("yy-MM-dd"));
        }

        public ItemDAO itemDAO
        {
            get { return _itemDAO; }
            set { _itemDAO = value; }
        }

        public BlogCache BlogCache
        {
            get { return _blogCache; }
            set { _blogCache = value; }
        }
    }
}
