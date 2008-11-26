using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Spring.Data.Common;
using Spring.Data.Objects.Generic;
using rpcwc.vo.directory;
using rpcwc.dao;
using System.Collections;

/// <summary>
/// Summary description for DirectoryPersonDaoSql
/// </summary>
namespace rpcwc.dao.sql
{
    public class DirectoryPersonDaoSql : RPCWCDAO, IDirectoryPersonDao
    {
        private FindPersonQuery _findPersonQuery;
        private static string personCommandString = "findPersonForDir";

        public class FindPersonQuery : MappingAdoQuery
        {
            public FindPersonQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.StoredProcedure;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("entryId", SqlDbType.TinyInt);
                Compile();
            }

            protected override T MapRow<T>(IDataReader dataReader, int num)
            {
                Person person = new Person();
                person.id = getInt16(dataReader, 0).ToString();
                person.firstName = getString(dataReader, 2);
                person.lastName = getString(dataReader, 3);
                person.birthDate = getDateTime(dataReader, 4);
                person.isMember = getBoolean(dataReader, 5);
                return (T)(object)person;
            }
        }

        #region DirectoryPersonDao Members

        public IList<Person> findPersonEntries(string directoryId)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directoryId);
            IList<Person> personList = findPersonQuery.QueryByNamedParam<Person>(parameterMap);

            return personList;
        }

        #endregion

        public FindPersonQuery findPersonQuery
        {
            get
            {
                if (_findPersonQuery == null)
                    _findPersonQuery = new FindPersonQuery(dbProvider, personCommandString);
                return _findPersonQuery;
            }
            set
            { _findPersonQuery = value; }
        }
    }
}