using System.Web.UI;
using rpcwc.web.email;

namespace rpcwc.web
{
    public partial class Guest : Page
    {
        protected EmailSender _emailSender;

        public EmailSender emailSender
        {
            get { return _emailSender; }
            set { _emailSender = value; }
        }
    }
}
