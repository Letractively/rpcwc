using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for DirectoryServiceController
/// </summary>
public abstract class IDirectoryServiceController
{
    delegate IList Operation(String key, String value);
    IDictionary<String, Operation> map = new Dictionary<String, Operation>();

    public void Handle(String operation, String key, String value)
    {
        map[operation](key, value);
    }

    protected abstract IList Delete(String key, String value);

    protected abstract IList Add(String key, String value);

    protected abstract IList Update(String key, String value);

    protected abstract IList Read(String key, String value);
}