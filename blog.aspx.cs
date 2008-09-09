using System;
using rpcwc.bo;

namespace rpcwc.web
{
    public partial class Blog : System.Web.UI.Page
    {
        private BlogManager _blogManager;

        protected void Page_Load(object sender, EventArgs eventArgs)
        {
        }

        public BlogManager blogManager
        {
            get { return _blogManager; }
            set { _blogManager = value; }
        }
    }
}
