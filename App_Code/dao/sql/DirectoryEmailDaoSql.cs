using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;
using Spring.Data.Common;
using System.Data;
using Spring.Data.Objects.Generic;

/// <summary>
/// Summary description for DirectoryEmailDaoSql
/// </summary>
namespace rpcwc.dao.sql
{
    public class DirectoryEmailDaoSql : RPCWCDAO, IDirectoryEmailDao
    {
        public String UpdateSql { get; set; }
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

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Email email = new Email();
                email.emailAddress = getString(dataReader, 0);
                email.emailType = getString(dataReader, 1);
                email.id = getByte(dataReader, 2).ToString();

                return (T)(object)email;
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

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Email email = new Email();
                email.emailAddress = getString(dataReader, 0);
                email.emailType = getString(dataReader, 1);
                email.id = getByte(dataReader, 2).ToString();

                return (T)(object)email;
            }
        }

        public class EmailUpdateNonQuery : Spring.Data.Objects.AdoNonQuery
        {
            public EmailUpdateNonQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("oldAddress", SqlDbType.VarChar);
                DeclaredParameters.Add("newAddress", SqlDbType.VarChar);
                Compile();
            }
        }

        #region DirectoryEmailDao Members

        public IList<Email> findDirectoryLevelEmail(string directoryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directoryId);
            return findDirEmailQuery.QueryByNamedParam<Email>(parameterMap);
        }

        public IList<Email> findPersonLevelEmail(string personEntryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@personEntryId", personEntryId);
            return findPersonEmailQuery.QueryByNamedParam<Email>(parameterMap);
        }

        public void UpdateEmail(string oldAddress, string newAddress)
        {
            EmailUpdateNonQuery nonQuery = new EmailUpdateNonQuery(dbProvider, UpdateSql);
            IDictionary paramMap = new Hashtable();
            paramMap.Add("@oldAddress", oldAddress);
            paramMap.Add("@newAddress", newAddress);

            nonQuery.ExecuteNonQueryByNamedParam(paramMap);
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