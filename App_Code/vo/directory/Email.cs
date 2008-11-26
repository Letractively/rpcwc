using System;

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
