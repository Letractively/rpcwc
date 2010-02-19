using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.vo.directory;
using rpcwc.bo;
using System.Collections.Generic;
using rpcwc.bo.cache;

namespace rpcwc.web.members
{
    public partial class directory : Page
    {
        private DirectoryCache _directoryCache;

        protected void Page_Load(object sender, EventArgs e)
        {
            tableholder.Controls.Add(DirectoryCache.Directory);
        }

        public DirectoryCache DirectoryCache
        {
            get { return _directoryCache; }
            set { _directoryCache = value; }
        }
    }
}
