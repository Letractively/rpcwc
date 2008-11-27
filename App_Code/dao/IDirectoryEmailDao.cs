using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryEmailDao
/// </summary>
namespace rpcwc.dao
{
    public interface IDirectoryEmailDao
    {
        IList<Email> findDirectoryLevelEmail(String directoryId);
        IList<Email> findPersonLevelEmail(String personEntryId);
    }
}
