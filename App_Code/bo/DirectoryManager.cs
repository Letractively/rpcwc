using System.Collections;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.vo.directory;
using rpcwc.bo.cache;
using Google.GData.Photos;

/// <summary>
/// Summary description for DirectoryManager
/// </summary>
namespace rpcwc.bo
{
    public class DirectoryManager
    {
        private IDirectoryDAO _directoryDAO;
        private IDirectoryEmailDao _directoryEmailDao;
        private IDirectoryPersonDao _directoryPersonDao;
        private IDirectoryPhoneDao _directoryPhoneDao;
        private PhotoCache _photoCache;

        public IList<Directory> getDirectory()
        {
            IList<Directory> directoryEntries = DirectoryDAO.findAllDirectoryEntriesActive();

            foreach (Directory directoryEntry in directoryEntries)
            {
                populateDirectoryDetails(directoryEntry);
            }

            return directoryEntries;
        }

        /*public Directory findDirectoryEntry(String directoryId)
        {
            return DirectoryDAO.find(directoryId);
        }*/

        public void populateDirectoryDetails(Directory directoryEntry)
        {
            directoryEntry.emails = DirectoryEmailDao.findDirectoryLevelEmail(directoryEntry.id);
            directoryEntry.phones = DirectoryPhoneDao.findDirectoryLevelPhone(directoryEntry.id);
            directoryEntry.persons = DirectoryPersonDao.findPersonEntries(directoryEntry.id);
            string photoId = new PhotoAccessor(directoryEntry.photo).Id;
            if (photoId != null)
            {
                directoryEntry.photo = PhotoCache.FindPhoto(photoId);
            }
            else
            {
                directoryEntry.photo = null;
            }

            foreach (Person person in directoryEntry.persons)
            {
                person.emails = DirectoryEmailDao.findPersonLevelEmail(person.id);
                person.phones = DirectoryPhoneDao.findPersonLevelPhone(person.id);
            }
        }

        public IList<Directory> findAllDirectoryEntries()
        {
            return DirectoryDAO.findAllDirectoryEntriesActive();
        }

        public IDirectoryDAO DirectoryDAO
        {
            get { return _directoryDAO; }
            set { _directoryDAO = value; }
        }

        public IDirectoryEmailDao DirectoryEmailDao
        {
            get { return _directoryEmailDao; }
            set { _directoryEmailDao = value; }
        }

        public IDirectoryPersonDao DirectoryPersonDao
        {
            get { return _directoryPersonDao; }
            set { _directoryPersonDao = value; }
        }

        public IDirectoryPhoneDao DirectoryPhoneDao
        {
            get { return _directoryPhoneDao; }
            set { _directoryPhoneDao = value; }
        }

        public PhotoCache PhotoCache
        {
            get { return _photoCache; }
            set { _photoCache = value; }
        }
    }
}