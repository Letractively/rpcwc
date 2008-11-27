using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryPhoneDao
/// </summary>
namespace rpcwc.dao
{
    public interface IDirectoryPhoneDao
    {
        IList<Phone> findDirectoryLevelPhone(String directoryId);
        IList<Phone> findPersonLevelPhone(String personEntryId);
    }
}