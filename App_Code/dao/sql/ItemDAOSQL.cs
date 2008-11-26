using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using Spring.Context.Support;
using Spring.Context;
using Spring.Data.Common;
using Spring.Data.Objects.Generic;
using rpcwc.dao;
using rpcwc.vo;
using System.Collections.Generic;

/// <summary>
/// Summary description for ItemDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class ItemDAOSQL : RPCWCDAO, ItemDAO
    {
        private FindItemRSSQuery _findItemRSSQuery;
        private FindItemRSSQuery _findItemPrayerRSSQuery;
        private FindItemPodcastQuery _findItemPodcastQuery;
        private FindAllActiveQuery _findAllActiveQuery;
        private ESVServiceDAO _esvServiceDAO;
        private static String basefindSql = "SELECT TITLE, LINK, AUTHOR, DESCRIPTION, PUBDATE, TEXT_REFERENCE, URL, SIZE, TYPE FROM item INNER JOIN ITEM_ENCLOSURE on item.item_id = ITEM_ENCLOSURE.item_id LEFT OUTER JOIN ITEM_DESCRIPTION on item.item_id = item_description.item_id LEFT OUTER JOIN SERMON_TEXT_REFERENCE on item.item_id = SERMON_TEXT_REFERENCE.item_id ";
        private static String basefindRSSSql = "SELECT TITLE, LINK, AUTHOR, DESCRIPTION, PUBDATE FROM item LEFT OUTER JOIN ITEM_DESCRIPTION on item.item_id = item_description.item_id ";
        private static String wherePKSql = "WHERE item.channel_id = @channelId ";
        private static String whereActiveSql = "AND ACTIVE = 1 ";
        private static String orderByPrayerSql = "ORDER BY NEW DESC, LAST_UPD_TMS DESC ";
        public static DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
        private static String baseUrl = "http://www.rpcwc.org/";

        public class FindItemRSSQuery : MappingAdoQuery
        {
            public FindItemRSSQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("channelId", SqlDbType.TinyInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Item item = new Item();

                item.title = getString(dataReader, 0);
                item.url = getString(dataReader, 1);
                item.author = getString(dataReader, 2);
                item.summary = getString(dataReader, 3);
                item.pubDate = getDateTime(dataReader, 4);

                return (T)(object)item;
            }
        }

        public class FindItemPodcastQuery : MappingAdoQuery
        {
            public FindItemPodcastQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("channelId", SqlDbType.TinyInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Item item = new Item();

                item.title = getString(dataReader, 0);
                item.url = baseUrl + getString(dataReader, 6);
                item.author = getString(dataReader, 2);
                item.summary = getString(dataReader, 5);
                item.pubDate = getDateTime(dataReader, 4);

                return (T)(object)item;
            }
        }

        public class FindAllActiveQuery : MappingAdoQuery
        {
            public FindAllActiveQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("channelId", SqlDbType.TinyInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Item item = new Item();

                item.title = getString(dataReader, 0);
                item.url = getString(dataReader, 1);
                item.author = getString(dataReader, 2);
                item.summary = getString(dataReader, 3);
                item.pubDate = getDateTime(dataReader, 4);

                return (T)(object)item;
            }
        }

        public IList<Item> findItemsRSS(int channelId)
        {
            if (channelId == 6)
                return findItemsPrayerRSS(channelId);

            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", channelId);

            return findItemRSSQuery.QueryByNamedParam<Item>(parameterMap);
        }

        public IList<Item> findItemsPrayerRSS(int channelId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", channelId);

            return findItemPrayerRSSQuery.QueryByNamedParam<Item>(parameterMap);
        }

        public IList<Item> findAllActive(int channelId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", channelId);

            return findAllActiveQuery.QueryByNamedParam<Item>(parameterMap);
        }

        public IList<Item> findItemsPodcast(int channelId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", channelId);
            IList<Item> episodes = findItemPodcastQuery.QueryByNamedParam<Item>(parameterMap);

            foreach (Item episode in episodes)
            {
                episode.summary = esvServiceDAO.fetchSermonText(episode.summary);
            }

            return episodes;
        }

        public ESVServiceDAO esvServiceDAO
        {
            get { return _esvServiceDAO; }
            set { _esvServiceDAO = value; }
        }

        public FindItemRSSQuery findItemRSSQuery
        {
            get
            {
                if (_findItemRSSQuery == null)
                    _findItemRSSQuery = new FindItemRSSQuery(dbProvider, basefindRSSSql + wherePKSql);
                return _findItemRSSQuery;
            }
            set
            {
                _findItemRSSQuery = value;
            }
        }

        public FindAllActiveQuery findAllActiveQuery
        {
            get
            {
                if (_findAllActiveQuery == null)
                    _findAllActiveQuery = new FindAllActiveQuery(dbProvider, basefindRSSSql + wherePKSql + whereActiveSql);
                return _findAllActiveQuery;
            }
            set
            {
                _findAllActiveQuery = value;
            }
        }

        public FindItemRSSQuery findItemPrayerRSSQuery
        {
            get
            {
                if (_findItemPrayerRSSQuery == null)
                    _findItemPrayerRSSQuery = new FindItemRSSQuery(dbProvider, basefindRSSSql + wherePKSql + whereActiveSql + orderByPrayerSql);
                return _findItemPrayerRSSQuery;
            }
            set
            {
                _findItemPrayerRSSQuery = value;
            }
        }

        public FindItemPodcastQuery findItemPodcastQuery
        {
            get
            {
                if (_findItemPodcastQuery == null)
                    _findItemPodcastQuery = new FindItemPodcastQuery(dbProvider, basefindSql + wherePKSql);
                return _findItemPodcastQuery;
            }
            set
            {
                _findItemPodcastQuery = value;
            }
        }
    }
}
