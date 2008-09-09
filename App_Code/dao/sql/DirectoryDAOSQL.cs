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
        private FindDirEmailQuery _findDirEmailQuery;
        private FindDirPhoneQuery _findDirPhoneQuery;
        private FindPersonQuery _findPersonQuery;
        private FindPersonEmailQuery _findPersonEmailQuery;
        private FindPersonPhoneQuery _findPersonPhoneQuery;
        private static string directoryCommandString = "findDirectory";
        private static string emailForDirCommandString = "findEmailForDir";
        private static string phonesForDirCommandString = "findPhoneForDir";
        private static string personCommandString = "findPersonForDir";
        private static string emailForPersonCommandString = "findEmailForPerson";
        private static string phonesForPersonCommandString = "findPhoneForPerson";

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
                directory.id = getByte(dataReader, 6);

                return directory;
            }
        }

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
                email.id = getByte(dataReader, 2);

                return email;
            }
        }

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

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Phone phone = new Phone();
                phone.phoneNumber = getString(dataReader, 0);
                phone.phoneType = getString(dataReader, 1);
                phone.id = getByte(dataReader, 2);

                return phone;
            }
        }

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

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Person person = new Person();
                person.id = getInt16(dataReader, 0);
                person.firstName = getString(dataReader, 2);
                person.lastName = getString(dataReader, 3);
                person.birthDate = getDateTime(dataReader, 4);
                person.isMember = getBoolean(dataReader, 5);
                return person;
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
                email.id = getByte(dataReader, 2);

                return email;
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

            protected override object MapRow(IDataReader dataReader, int num)
            {
                Phone phone = new Phone();
                phone.phoneNumber = getString(dataReader, 0);
                phone.phoneType = getString(dataReader, 1);
                phone.id = getByte(dataReader, 2);

                return phone;
            }
        }

        public IList getDirectory()
        {

            IList directoryEntries = findDirectoryQuery.Query();

            foreach (Directory directoryEntry in directoryEntries)
            {
                directoryEntry.emails = getEmails(directoryEntry);
                directoryEntry.phones = getPhones(directoryEntry);
                directoryEntry.persons = getPersons(directoryEntry);
            }

            return directoryEntries;
        }

        public IList getPersons(Directory directory)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directory.id);
            IList personList = findPersonQuery.QueryByNamedParam(parameterMap);

            foreach (Person person in personList)
            {
                person.emails = getEmails(person);
                person.phones = getPhones(person);
            }

            return personList;
        }

        public IList getEmails(Directory directory)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directory.id);
            return findDirEmailQuery.QueryByNamedParam(parameterMap);
        }

        public IList getPhones(Directory directory)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@entryId", directory.id);
            return findDirPhoneQuery.QueryByNamedParam(parameterMap);
        }

        public IList getEmails(Person person)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@personEntryId", person.id);
            return findPersonEmailQuery.QueryByNamedParam(parameterMap);
        }

        public IList getPhones(Person person)
        {
            IDictionary parameterMap = new Hashtable(1);
            parameterMap.Add("@personEntryId", person.id);
            return findPersonPhoneQuery.QueryByNamedParam(parameterMap);
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
        public FindDirEmailQuery findDirEmailQuery
        {
            get
            {
                if (_findDirEmailQuery == null)
                    _findDirEmailQuery = new FindDirEmailQuery(dbProvider, emailForDirCommandString);
                return _findDirEmailQuery;
            }
            set
            {
                _findDirEmailQuery = value;
            }
        }
        public FindDirPhoneQuery findDirPhoneQuery
        {
            get
            {
                if (_findDirPhoneQuery == null)
                    _findDirPhoneQuery = new FindDirPhoneQuery(dbProvider, phonesForDirCommandString);
                return _findDirPhoneQuery;
            }
            set
            {
                _findDirPhoneQuery = value;
            }
        }
        public FindPersonQuery findPersonQuery
        {
            get
            {
                if (_findPersonQuery == null)
                    _findPersonQuery = new FindPersonQuery(dbProvider, personCommandString);
                return _findPersonQuery;
            }
            set
            {
                _findPersonQuery = value;
            }
        }
        public FindPersonEmailQuery findPersonEmailQuery
        {
            get
            {
                if (_findPersonEmailQuery == null)
                    _findPersonEmailQuery = new FindPersonEmailQuery(dbProvider, emailForPersonCommandString);
                return _findPersonEmailQuery;
            }
            set
            {
                _findPersonEmailQuery = value;
            }
        }
        public FindPersonPhoneQuery findPersonPhoneQuery
        {
            get
            {
                if (_findPersonPhoneQuery == null)
                    _findPersonPhoneQuery = new FindPersonPhoneQuery(dbProvider, phonesForPersonCommandString);
                return _findPersonPhoneQuery;
            }
            set
            {
                _findPersonPhoneQuery = value;
            }
        }
    }
}
