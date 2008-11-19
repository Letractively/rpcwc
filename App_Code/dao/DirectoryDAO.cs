using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using Spring.Data.Objects;
using Spring.Data.Common;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryDAO
/// </summary>
namespace rpcwc.dao
{
    public interface DirectoryDAO
    {
        IList findAllDirectoryEntriesActive();
        Directory find(String pkWhere);
    }
}
