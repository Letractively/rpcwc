using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for DirectoryEmailDao
/// </summary>
namespace rpcwc.dao
{
    public interface DirectoryEmailDao
    {
        IList findDirectoryLevelEmail(String directoryId);
        IList findPersonLevelEmail(String personEntryId);
    }
}
