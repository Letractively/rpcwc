using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.bo;
using rpcwc.vo.directory;

namespace rpcwc.web.Maintenance
{
    public partial class maintenance_directory_Default : System.Web.UI.Page
    {
        private DirectoryManager _directoryManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            Table table = new Table();

            foreach (Directory directoryEntry in DirectoryManager.findAllDirectoryEntries())
            {
                TableRow tableRow = new TableRow();
                TableCell tableCell = new TableCell();
                HyperLink hyperLink = new HyperLink();
                hyperLink.Text = directoryEntry.lastName;
                hyperLink.NavigateUrl = String.Format("directoryMaintenance.aspx?id={0}", directoryEntry.id);
                tableCell.Controls.Add(hyperLink);
                tableRow.Controls.Add(tableCell);
                table.Controls.Add(tableRow);
            }

            DirectoryEntries.Controls.Add(table);
        }

        public DirectoryManager DirectoryManager
        {
            get { return _directoryManager; }
            set { _directoryManager = value;  }
        }
    }
}