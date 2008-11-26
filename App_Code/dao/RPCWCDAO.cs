using System;
using System.Data;
using Spring.Data.Common;
using Spring.Data.Objects.Generic;

/// <summary>
/// Summary description for RPCWCDAO
/// </summary>
namespace rpcwc.dao
{
    public class RPCWCDAO
    {
        private IDbProvider _dbProvider;


        protected static string getString(IDataReader dataReader, int column)
        {
            if (!dataReader.IsDBNull(column))
                return dataReader.GetString(column);

            return null;
        }

        protected static DateTime getDateTime(IDataReader dataReader, int column)
        {
            if (!dataReader.IsDBNull(column))
                return dataReader.GetDateTime(column);

            return new DateTime();
        }

        protected static bool getBoolean(IDataReader dataReader, int column)
        {
            if (!dataReader.IsDBNull(column))
                return dataReader.GetBoolean(column);

            return false;
        }

        protected static int getInt16(IDataReader dataReader, int column)
        {
            if (!dataReader.IsDBNull(column))
                return dataReader.GetInt16(column);

            return 0;
        }

        protected static byte getByte(IDataReader dataReader, int column)
        {
            if (!dataReader.IsDBNull(column))
                return (byte)dataReader.GetByte(column);

            return 0;
        }

        public IDbProvider dbProvider
        {
            get { return _dbProvider; }
            set { _dbProvider = value; }
        }
    }
}
