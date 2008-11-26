using System;

/// <summary>
/// Summary description for Phone
/// </summary>
namespace rpcwc.vo.directory
{
    public class Phone : RPCVO
    {
        private String _phoneNumber;
        private String _phoneType;

        public Phone()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public String phoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public String phoneType
        {
            get { return _phoneType; }
            set { _phoneType = value; }
        }
    }
}
