using System;
using System.Configuration;
using System.Data.SqlClient;
using Spring.Data.Objects;
using Spring.Data.Common;
using System.Data;
using System.Collections;
using rpcwc.dao;
using rpcwc.vo;

/// <summary>
/// Summary description for ChannelDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class ChannelDAOSQL : RPCWCDAO, ChannelDAO
    {
        private FindChannelQuery _findChannelQuery;
        private static String basefindSql = "findChannel";

        public class FindChannelQuery : MappingAdoQuery
        {
            public FindChannelQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("channelId", SqlDbType.TinyInt);
                Compile();
            }

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Channel channel = new Channel();

                channel.title = getString(dataReader, 0);
                channel.link = getString(dataReader, 1);
                channel.summary = getString(dataReader, 2);
                channel.language = getString(dataReader, 3);
                channel.copyright = getString(dataReader, 4);

                return channel;
            }
        }

        public Channel findChannel(int channelId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@channelId", channelId);

            return (Channel)findChannelQuery.QueryForObject(parameterMap);
        }


        public FindChannelQuery findChannelQuery
        {
            get
            {
                if (_findChannelQuery == null)
                    _findChannelQuery = new FindChannelQuery(dbProvider, basefindSql);
                return _findChannelQuery;
            }
            set
            {
                _findChannelQuery = value;
            }
        }
    }
}
