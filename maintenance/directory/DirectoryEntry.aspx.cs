using System;
using System.Collections.Generic;
using rpcwc.bo;
using rpcwc.vo.directory;

namespace rpcwc.web.Maintenance
{
    public partial class maintenance_directory_DirectoryEntry : System.Web.UI.Page
    {
        private DirectoryManager _directoryManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            String directoryId = Request.Params["id"];
            Directory directoryEntry = DirectoryManager.findDirectoryEntry(directoryId);
            DirectoryManager.populateDirectoryDetails(directoryEntry);
        }

        public DirectoryManager DirectoryManager
        {
            get { return _directoryManager; }
            set { _directoryManager = value; }
        }
    }
}
