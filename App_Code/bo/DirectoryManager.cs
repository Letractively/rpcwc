using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.dao;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryManager
/// </summary>
namespace rpcwc.bo
{
    public class DirectoryManager
    {
        private DirectoryDAO _directoryDAO;
        private DirectoryEmailDao _directoryEmailDao;
        private DirectoryPersonDao _directoryPersonDao;
        private DirectoryPhoneDao _directoryPhoneDao;

        public IList getDirectory()
        {

            IList directoryEntries = DirectoryDAO.findAllDirectoryEntriesActive();

            foreach (Directory directoryEntry in directoryEntries)
            {
                populateDirectoryDetails(directoryEntry);
            }

            return directoryEntries;
        }

        public Directory findDirectoryEntry(String directoryId)
        {
            return DirectoryDAO.find(directoryId);
        }

        public void populateDirectoryDetails(Directory directoryEntry)
        {
            directoryEntry.emails = DirectoryEmailDao.findDirectoryLevelEmail(directoryEntry.id);
            directoryEntry.phones = DirectoryPhoneDao.findDirectoryLevelPhone(directoryEntry.id);
            directoryEntry.persons = DirectoryPersonDao.findPersonEntries(directoryEntry.id);


            foreach (Person person in directoryEntry.persons)
            {
                person.emails = DirectoryEmailDao.findPersonLevelEmail(person.id);
                person.phones = DirectoryPhoneDao.findPersonLevelPhone(person.id);
            }
        }

        public IList findAllDirectoryEntries()
        {
            return DirectoryDAO.findAllDirectoryEntriesActive();
        }

        public DirectoryDAO DirectoryDAO
        {
            get { return _directoryDAO; }
            set { _directoryDAO = value; }
        }

        public DirectoryEmailDao DirectoryEmailDao
        {
            get { return _directoryEmailDao; }
            set { _directoryEmailDao = value; }
        }

        public DirectoryPersonDao DirectoryPersonDao
        {
            get { return _directoryPersonDao; }
            set { _directoryPersonDao = value; }
        }

        public DirectoryPhoneDao DirectoryPhoneDao
        {
            get { return _directoryPhoneDao; }
            set { _directoryPhoneDao = value; }
        }
    }
}