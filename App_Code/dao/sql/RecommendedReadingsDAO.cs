using System;
using System.Configuration;
using System.Data.SqlClient;
using Spring.Data.Common;
using Spring.Data.Core;
using System.Data;
using Spring.Data;
using rpcwc.dao;
using rpcwc.vo.Blog;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for RecommendedReadingsDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class RecommendedReadingsDAOSQL : RPCWCDAO, RecommendedReadingsDAO
    {
        private static string markReadingAsReadCommandString = "markAsRead";
        private static string findAllActiveRecommendedReadingsCommandString = "findAllActiveRecommendedReadings";
        private AdoTemplate _adoTemplate;

        class RecommendedReadingsRowMapper : IRowMapper
        {
            #region IRowMapper Members

            public object MapRow(IDataReader reader, int rowNum)
            {
                HyperLink link = new HyperLink();
                link.NavigateUrl = reader.GetString(2);
                link.ImageUrl = reader.GetString(4);
                link.Text = reader.GetString(1);
                return link;
            }

            #endregion
        }

        #region RecommendedReadingsDAO Members

        public void MarkAsRead(Int16 itemId)
        {
            IDbParameters parameters = adoTemplate.CreateDbParameters();
            parameters.AddWithValue("itemId", itemId);
            adoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, markReadingAsReadCommandString, parameters);
        }

        public IList FindAllActiveRecommendedReadings()
        {
            IDbParameters parameters = adoTemplate.CreateDbParameters();
            parameters.AddWithValue("channelId", DaoConstants.CHANNEL_RECOMMENDED_READINGS);
            return adoTemplate.QueryWithRowMapper(CommandType.StoredProcedure, findAllActiveRecommendedReadingsCommandString, new RecommendedReadingsRowMapper(), parameters);
        }

        #endregion

        public AdoTemplate adoTemplate
        {
            get
            {
                if (_adoTemplate == null)
                    _adoTemplate = new AdoTemplate(dbProvider);
                return _adoTemplate;
            }
            set
            {
                _adoTemplate = value;
            }
        }
    }
}
