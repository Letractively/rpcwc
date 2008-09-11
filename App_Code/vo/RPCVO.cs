using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for RPCVO
/// </summary>
namespace rpcwc.vo
{
    public class RPCVO
    {
        private String _id;
        private bool _active;

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
