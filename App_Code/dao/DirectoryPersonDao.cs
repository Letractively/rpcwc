using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for DirectoryPersonDao
/// </summary>
namespace rpcwc.dao
{
    public interface DirectoryPersonDao
    {
        IList findPersonEntries(String directoryId);
    }
}