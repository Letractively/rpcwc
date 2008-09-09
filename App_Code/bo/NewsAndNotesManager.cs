using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.dao;

/// <summary>
/// Summary description for NewsAndNotesManager
/// </summary>
namespace rpcwc.bo
{
    public class NewsAndNotesManager
    {
        private ItemDAO _itemDAO;

        public IList findAllNewsAndNotesActive()
        {
            return itemDAO.findAllActive(RPCConstants.Channels.NEWS_AND_NOTES);
        }

        public ItemDAO itemDAO
        {
            get { return _itemDAO; }
            set { _itemDAO = value; }
        }
    }
}
