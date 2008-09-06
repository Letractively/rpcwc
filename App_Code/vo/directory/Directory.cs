using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for Directory
/// </summary>
namespace rpcwc.vo.directory
{
    public class Directory : RPCVO
    {
        private String _lastName;
        private String _address1;
        private String _address2;
        private String _city;
        private String _state;
        private String _zip;
        private IList _emails;
        private IList _phones;
        private IList _persons;

        public Directory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public String lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public String address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        public String address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        public String city
        {
            get { return _city; }
            set { _city = value; }
        }
        public String state
        {
            get { return _state; }
            set { _state = value; }
        }
        public String zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public IList emails
        {
            get { return _emails; }
            set { _emails = value; }
        }
        public IList phones
        {
            get { return _phones; }
            set { _phones = value; }
        }
        public IList persons
        {
            get { return _persons; }
            set { _persons = value; }
        }
    }
}
