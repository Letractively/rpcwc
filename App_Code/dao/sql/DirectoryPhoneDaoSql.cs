using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;
using Spring.Data.Objects.Generic;
using Spring.Data.Common;
using System.Data;

/// <summary>
/// Summary description for DirectoryPhoneDaoSql
/// </summary>
namespace rpcwc.dao.sql
{
    public class DirectoryPhoneDaoSql : RPCWCDAO, IDirectoryPhoneDao
    {
        private FindDirPhoneQuery _findDirPhoneQuery;
        private FindPersonPhoneQuery _findPersonPhoneQuery;

        private static string phonesForDirCommandString = "findPhoneForDir";
        private static string phonesForPersonCommandString = "findPhoneForPerson";

        public class FindDirPhoneQuery : MappingAdoQuery
        {
            public FindDirPhoneQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("entryId", SqlDbType.TinyInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Phone phone = new Phone();
                phone.phoneNumber = getString(dataReader, 0);
                phone.phoneType = getString(dataReader, 1);
                phone.id = getByte(dataReader, 2).ToString();

                return (T)(object)phone;
            }
        }

        public class FindPersonPhoneQuery : MappingAdoQuery
        {
            public FindPersonPhoneQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("personEntryId", SqlDbType.SmallInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Phone phone = new Phone();
                phone.phoneNumber = getString(dataReader, 0);
                phone.phoneType = getString(dataReader, 1);
                phone.id = getByte(dataReader, 2).ToString();

                return (T)(object)phone;
            }
        }

        #region DirectoryPhoneDao Members

        public IList<Phone> findDirectoryLevelPhone(string directoryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directoryId);
            return findDirPhoneQuery.QueryByNamedParam<Phone>(parameterMap);
        }

        public IList<Phone> findPersonLevelPhone(string personEntryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@personEntryId", personEntryId);
            return findPersonPhoneQuery.QueryByNamedParam<Phone>(parameterMap);
        }

        #endregion

        public FindDirPhoneQuery findDirPhoneQuery
        {
            get
            {
                if (_findDirPhoneQuery == null)
                    _findDirPhoneQuery = new FindDirPhoneQuery(dbProvider, phonesForDirCommandString);
                return _findDirPhoneQuery;
            }
            set { _findDirPhoneQuery = value; }
        }

        public FindPersonPhoneQuery findPersonPhoneQuery
        {
            get
            {
                if (_findPersonPhoneQuery == null)
                    _findPersonPhoneQuery = new FindPersonPhoneQuery(dbProvider, phonesForPersonCommandString);
                return _findPersonPhoneQuery;
            }
            set { _findPersonPhoneQuery = value; }
        }
    }
}