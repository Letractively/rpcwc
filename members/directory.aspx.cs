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

        delegate WebControl BuildCellDelegate(Directory directoryEntry);

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildCellDelegate buildCellDelegate = DirectoryHelper.makeCell;
            IList<Directory> directory = DirectoryCache.FindDirectoryEntries();
            WebControl table = new WebControl(HtmlTextWriterTag.Table);
            WebControl colgroup = new WebControl(HtmlTextWriterTag.Colgroup);
            WebControl col = new WebControl(HtmlTextWriterTag.Col);
            col.Width = Unit.Percentage(50);
            colgroup.Controls.Add(col);
            colgroup.Controls.Add(col);
            table.Controls.Add(colgroup);
            table.Width = Unit.Percentage(100);

            IList<IAsyncResult> results = new List<IAsyncResult>();

            foreach (Directory directoryEntry in directory)
            {
                results.Add(buildCellDelegate.BeginInvoke(directoryEntry, delegate(IAsyncResult result) { }, null));
            }

            for (int i = 0; i < results.Count; i += 2)
            {
                WebControl tr = new WebControl(HtmlTextWriterTag.Tr);
                tr.Controls.Add(buildCellDelegate.EndInvoke(results[i]));
                if (i + 1 < results.Count)
                    tr.Controls.Add(buildCellDelegate.EndInvoke(results[i + 1]));
                table.Controls.Add(tr);
            }

            tableholder.Controls.Add(table);

        }



        public DirectoryCache DirectoryCache
        {
            get { return _directoryCache; }
            set { _directoryCache = value; }
        }
    }
}
