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
/// Summary description for Email
/// </summary>
namespace rpcwc.vo.directory
{
    public class Email : RPCVO
    {
        private String _emailAddress;
        private String _emailType;

        public Email()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public String emailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        public String emailType
        {
            get { return _emailType; }
            set { _emailType = value; }
        }
    }
}
