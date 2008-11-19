using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for DirectoryPhoneDao
/// </summary>
namespace rpcwc.dao
{
    public interface DirectoryPhoneDao
    {
        IList findDirectoryLevelPhone(String directoryId);
        IList findPersonLevelPhone(String personEntryId);
    }
}