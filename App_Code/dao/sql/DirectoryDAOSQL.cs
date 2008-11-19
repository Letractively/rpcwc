using System;
using System.Collections;
using System.Data;
using Spring.Data.Common;
using Spring.Data.Objects;
using rpcwc.dao;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class DirectoryDAOSQL : RPCWCDAO, DirectoryDAO
    {
        private FindDirectoryQuery _findDirectoryQuery;
        private FindDirectoryPkQuery _findDirectoryPkQuery;
        private static string directoryCommandString = "findDirectory";
        private static string directoryPkCommandString = "findDirectoryPk";

        public class FindDirectoryQuery : MappingAdoQuery
        {
            public FindDirectoryQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                Compile();
            }

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Directory directory = new Directory();

                directory.lastName = getString(dataReader, 0);
                directory.address1 = getString(dataReader, 1);
                directory.address2 = getString(dataReader, 2);
                directory.city = getString(dataReader, 3);
                directory.state = getString(dataReader, 4);
                directory.zip = getString(dataReader, 5);
                directory.id = getByte(dataReader, 6).ToString();

                return directory;
            }
        }

        public class FindDirectoryPkQuery : MappingAdoQuery
        {
            public FindDirectoryPkQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("entryId", SqlDbType.SmallInt);
                Compile();
            }

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Directory directory = new Directory();

                directory.lastName = getString(dataReader, 0);
                directory.address1 = getString(dataReader, 1);
                directory.address2 = getString(dataReader, 2);
                directory.city = getString(dataReader, 3);
                directory.state = getString(dataReader, 4);
                directory.zip = getString(dataReader, 5);
                directory.id = getByte(dataReader, 6).ToString();

                return directory;
            }
        }

        public IList findAllDirectoryEntriesActive()
        {
            return findDirectoryQuery.Query();
        }

        public Directory find(String directoryId)
        {
            IDictionary paramMap = new Hashtable();
            paramMap.Add("@entryId", directoryId);
            return (Directory)findDirectoryPkQuery.QueryForObject(paramMap);
        }

        public FindDirectoryQuery findDirectoryQuery
        {
            get
            {
                if (_findDirectoryQuery == null)
                    _findDirectoryQuery = new FindDirectoryQuery(dbProvider, directoryCommandString);
                return _findDirectoryQuery;
            }
            set
            {
                _findDirectoryQuery = value;
            }
        }

        public FindDirectoryPkQuery findDirectoryPkQuery
        {
            get
            {
                if (_findDirectoryPkQuery == null)
                    _findDirectoryPkQuery = new FindDirectoryPkQuery(dbProvider, directoryPkCommandString);
                return _findDirectoryPkQuery;
            }
            set { _findDirectoryPkQuery = value; }
        }

    }
}
