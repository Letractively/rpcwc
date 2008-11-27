using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using Spring.Data.Objects;
using Spring.Data.Common;
using rpcwc.vo.directory;
using System.Collections.Generic;

/// <summary>
/// Summary description for DirectoryDAO
/// </summary>
namespace rpcwc.dao
{
    public interface IDirectoryDAO
    {
        IList<Directory> findAllDirectoryEntriesActive();
        Directory find(String pkWhere);
    }
}
