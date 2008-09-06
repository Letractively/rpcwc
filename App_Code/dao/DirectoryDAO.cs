using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections;
using Spring.Data.Objects;
using Spring.Data.Common;

/// <summary>
/// Summary description for DirectoryDAO
/// </summary>
namespace rpcwc.dao
{
    public interface DirectoryDAO
    {
        IList getDirectory();
    }
}
