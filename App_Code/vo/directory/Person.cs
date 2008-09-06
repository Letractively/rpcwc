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
/// Summary description for Person
/// </summary>
namespace rpcwc.vo.directory
{
    public class Person : RPCVO
    {
        private String _firstName;
        private String _lastName;
        private DateTime _birthDate;
        private bool _isMember;
        private IList _emails;
        private IList _phones;

        public Person()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public String firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public String lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public bool isMember
        {
            get { return _isMember; }
            set { _isMember = value; }
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
    }
}
