using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using rpcwc.bo;
using System.Web.Script.Serialization;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryServiceController
/// </summary>
public class DirectoryServiceController : IDirectoryServiceController
{
    public DirectoryManager DirectoryManager { get; set; }

    protected override IList Delete(String key, String value)
    {
        DirectoryManager.DeleteEntry(Int16.Parse(key));
        return null;
    }

    protected override IList Add(String key, String value)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        IList<int> list = new List<int>();
        list.Add(DirectoryManager.InsertEntry(key, js.Deserialize<Directory>(value)));

        return (IList) list;
    }

    protected override IList Update(String key, String value)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        IList<int> list = new List<int>();
        list.Add(DirectoryManager.UpdateEntry(key, js.Deserialize<Directory>(value)));

        return (IList)list;
    }

    protected override IList Read(String key, String value)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        IList<Directory> list = new List<Directory>();
        list.Add(DirectoryManager.GetEntry(key));

        return (IList)list;
    }
}
