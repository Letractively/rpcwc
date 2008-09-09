using System;
using System.Configuration;
using System.Data.SqlClient;
using Spring.Data.Common;
using Spring.Data.Core;
using System.Data;
using Spring.Data;
using rpcwc.dao;

/// <summary>
/// Summary description for RecommendedReadingsDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class RecommendedReadingsDAOSQL : RPCWCDAO, RecommendedReadingsDAO
    {
        private static string markReadingAsReadCommandString = "markAsRead";
        private AdoTemplate _adoTemplate;

        public void MarkAsRead(Int16 itemId)
        {
            IDbParameters parameters = adoTemplate.CreateDbParameters();
            parameters.AddWithValue("itemId", itemId);
            adoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, markReadingAsReadCommandString, parameters);
        }

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
