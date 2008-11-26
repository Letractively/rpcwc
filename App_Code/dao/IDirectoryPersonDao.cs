using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryPersonDao
/// </summary>
namespace rpcwc.dao
{
    public interface IDirectoryPersonDao
    {
        IList<Person> findPersonEntries(String directoryId);
    }
}