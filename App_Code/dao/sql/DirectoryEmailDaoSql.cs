﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;
using Spring.Data.Common;
using System.Data;
using Spring.Data.Objects;

/// <summary>
/// Summary description for DirectoryEmailDaoSql
/// </summary>
namespace rpcwc.dao.sql
{
    public class DirectoryEmailDaoSql : RPCWCDAO, DirectoryEmailDao
    {
        private FindDirEmailQuery _findDirEmailQuery;
        private FindPersonEmailQuery _findPersonEmailQuery;
        private static string emailForDirCommandString = "findEmailForDir";
        private static string emailForPersonCommandString = "findEmailForPerson";
        public class FindDirEmailQuery : MappingAdoQuery
        {
            public FindDirEmailQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("entryId", SqlDbType.TinyInt);
                Compile();
            }

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Email email = new Email();
                email.emailAddress = getString(dataReader, 0);
                email.emailType = getString(dataReader, 1);
                email.id = getByte(dataReader, 2).ToString();

                return email;
            }
        }

        public class FindPersonEmailQuery : MappingAdoQuery
        {
            public FindPersonEmailQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("personEntryId", SqlDbType.SmallInt);
                Compile();
            }

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Email email = new Email();
                email.emailAddress = getString(dataReader, 0);
                email.emailType = getString(dataReader, 1);
                email.id = getByte(dataReader, 2).ToString();

                return email;
            }
        }

        #region DirectoryEmailDao Members

        public System.Collections.IList findDirectoryLevelEmail(string directoryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directoryId);
            return findDirEmailQuery.QueryByNamedParam(parameterMap);
        }

        public System.Collections.IList findPersonLevelEmail(string personEntryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@personEntryId", personEntryId);
            return findPersonEmailQuery.QueryByNamedParam(parameterMap);
        }

        #endregion

        public FindDirEmailQuery findDirEmailQuery
        {
            get
            {
                if (_findDirEmailQuery == null)
                    _findDirEmailQuery = new FindDirEmailQuery(dbProvider, emailForDirCommandString);
                return _findDirEmailQuery;
            }
            set { _findDirEmailQuery = value; }
        }

        public FindPersonEmailQuery findPersonEmailQuery
        {
            get
            {
                if (_findPersonEmailQuery == null)
                    _findPersonEmailQuery = new FindPersonEmailQuery(dbProvider, emailForPersonCommandString);
                return _findPersonEmailQuery;
            }
            set { _findPersonEmailQuery = value; }
        }

    }
}