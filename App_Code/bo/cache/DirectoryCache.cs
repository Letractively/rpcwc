using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.vo.directory;
using System.Web.UI.WebControls;
using rpcwc.web;
using System.Web.UI;

/// <summary>
/// Summary description for DirectoryCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class DirectoryCache : AbstractCache {
        //private DirectoryDAO _directoryDao;
        private DirectoryManager _directoryManager;
        private IList<Directory> _directoryEntries;
        private IDictionary<String, Directory> _directoryEntriesMappedById;
        private WebControl _directory;
        private static Object LOCK = new Object();

        public class DirectoryByIdMapKeyCreator : CollectionUtils.MapKeyCreator<String, Directory>
        {
            public String createKey(Directory obj)
            {
                Directory directryEntry = (Directory)obj;
                return directryEntry.id;
            }
        }

        public override void Refresh(bool visitorRefresh)
        {
            refreshing = true;

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            DateTime startTime = DateTime.Now;

            IList<Directory> directoryList = DirectoryManager.getDirectory();
            
            IDictionary<String, Directory> directoryEntriesMappedById =
                CollectionUtils.Map(directoryList, new DirectoryByIdMapKeyCreator());

            lock (LOCK)
            {
                DirectoryEntries.Clear();
                ((List<Directory>)DirectoryEntries).AddRange(directoryList);
                DirectoryEntriesMappedById.Clear();
                foreach (KeyValuePair<String, Directory> directoryEntry in directoryEntriesMappedById)
                {
                    DirectoryEntriesMappedById.Add(directoryEntry);
                }
            }

            WebControl directory = buildDirectory();

            lock (LOCK)
            {
                _directory = directory;
            }

            LastRefresh = DateTime.Now;

            RefreshTime += LastRefresh - startTime;

            refreshing = false;
        }

        public IList<Directory> FindDirectoryEntries()
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            List<Directory> directoryList = new List<Directory>();

            lock (LOCK)
            {
                directoryList.Clear();
                directoryList.AddRange(DirectoryEntries);
            }

            CacheTime += DateTime.Now - startTime;

            return directoryList;
        }

        public Directory FindDirectoryEntryPk(string directoryId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            Directory directoryEntry = null;

            lock (LOCK)
            {
                if (DirectoryEntriesMappedById.ContainsKey(directoryId))
                {
                    directoryEntry = DirectoryEntriesMappedById[directoryId];
                }
            }

            CacheTime += DateTime.Now - startTime;

            return directoryEntry;
        }

        public IList<Directory> DirectoryEntries
        {
            get
            {
                if (_directoryEntries == null)
                    _directoryEntries = new List<Directory>();
                return _directoryEntries;
            }
        }

        public IDictionary<String, Directory> DirectoryEntriesMappedById
        {
            get
            {
                if (_directoryEntriesMappedById == null)
                    _directoryEntriesMappedById = new Dictionary<String, Directory>();
                return _directoryEntriesMappedById;
            }
        }







        delegate WebControl BuildCellDelegate(Directory directoryEntry);
        delegate Control BuildLetterPanelDelegate(Char letter, IList<Directory> directoryEntries, BuildCellDelegate buildCellDelegate);

        class DirectoryFirstLetterMapKeyCreator : CollectionUtils.MapKeyCreator<Char, Directory>
        {
            #region MapKeyCreator<Char,Directory> Members

            public char createKey(Directory obj)
            {
                return obj.lastName.ToCharArray(0, 1)[0];
            }

            #endregion
        }

        private WebControl buildDirectory()
        {
            BuildCellDelegate buildCellDelegate = DirectoryHelper.makeCell;
            BuildLetterPanelDelegate buildLetterPanelDelegate = buildPanelForLetterAndTable;
            IList<Directory> directory = FindDirectoryEntries();

            IList<IAsyncResult> results = new List<IAsyncResult>();

            DirectoryFirstLetterMapKeyCreator mapKeyCreator = new DirectoryFirstLetterMapKeyCreator();
            IDictionary<Char, IList<Directory>> map = CollectionUtils.MapAsLists<Char, Directory>(directory, mapKeyCreator);

            Panel directoryHolder = new Panel();
            directoryHolder.Controls.Add(buildAlphabetPanel<IList<Directory>>(map));

            foreach (KeyValuePair<Char, IList<Directory>> keyValuePair in map)
            {
                IAsyncResult result = buildLetterPanelDelegate.BeginInvoke(keyValuePair.Key, keyValuePair.Value, buildCellDelegate, delegate(IAsyncResult res) { }, null);
                if (result != null)
                {
                    results.Add(result);
                }
            }

            foreach (IAsyncResult result in results)
            {
                Control control = buildLetterPanelDelegate.EndInvoke(result);
                directoryHolder.Controls.Add(control);
            }

            return directoryHolder;
        }

        private static Control buildPanelForLetterAndTable(Char letter, IList<Directory> directory, BuildCellDelegate buildCellDelegate)
        {
            Control control = new Control();
            WebControl table = buildTable(directory, buildCellDelegate);
            control.Controls.Add(buildLetterPanel(letter));
            control.Controls.Add(table);

            return control;
        }

        private Control buildAlphabetPanel<T>(IDictionary<char, T> entriesMappedByFirstLetter)
        {
            Panel alphabet = new Panel();
            alphabet.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            WebControl topAnchor = new WebControl(HtmlTextWriterTag.A);
            topAnchor.Attributes.Add("name", "top");
            alphabet.Controls.Add(topAnchor);

            foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                if (entriesMappedByFirstLetter.ContainsKey(letter))
                {
                    HyperLink link = new HyperLink();
                    link.Text = letter.ToString();
                    link.NavigateUrl = "#" + letter.ToString();
                    alphabet.Controls.Add(link);
                }
                else
                {
                    alphabet.Controls.Add(new LiteralControl(letter.ToString()));
                }

                alphabet.Controls.Add(new LiteralControl(" "));
            }

            return alphabet;
        }

        private static WebControl buildTable(IList<Directory> directory, BuildCellDelegate buildCellDelegate)
        {
            WebControl table = new WebControl(HtmlTextWriterTag.Table);
            WebControl colgroup1 = new WebControl(HtmlTextWriterTag.Colgroup);
            WebControl colgroup2 = new WebControl(HtmlTextWriterTag.Colgroup);
            WebControl col1 = new WebControl(HtmlTextWriterTag.Col);
            WebControl col2 = new WebControl(HtmlTextWriterTag.Col);
            col1.Width = Unit.Percentage(100);
            col2.Width = Unit.Percentage(50);
            colgroup1.Controls.Add(col1);
            colgroup2.Controls.Add(col2);
            table.Controls.Add(colgroup1);
            //table.Controls.Add(colgroup2);
            table.Width = Unit.Percentage(100);

            IList<IAsyncResult> results = new List<IAsyncResult>();

            foreach (Directory directoryEntry in directory)
            {
                results.Add(buildCellDelegate.BeginInvoke(directoryEntry, delegate(IAsyncResult result) { }, null));
            }

            for (int i = 0; i < results.Count; i++)
            {
                WebControl tr = new WebControl(HtmlTextWriterTag.Tr);
                WebControl td = buildCellDelegate.EndInvoke(results[i]);
                td.Style.Add("border-top", "solid 1px gray");
                if (i == 0)
                {
                    td.Style.Add("border-top", "solid 1px black");
                }
                tr.Controls.Add(td);
                table.Controls.Add(tr);
            }

            return table;
        }

        private static Panel buildLetterPanel(Char letter)
        {
            Panel panel = new Panel();
            WebControl anchor = new WebControl(HtmlTextWriterTag.A);
            anchor.Attributes.Add("name", letter.ToString());
            Label header = new Label();
            //header.font
            header.Style.Add(HtmlTextWriterStyle.Color, "6D8A98");
            header.Font.Size = new FontUnit(18, UnitType.Pixel);
            header.Font.Bold = true;
            header.Controls.Add(new LiteralControl(letter.ToString()));
            anchor.Controls.Add(header);
            HyperLink topLink = new HyperLink();
            topLink.Text = "(top)";
            topLink.NavigateUrl = "#top";
            panel.Controls.Add(anchor);
            panel.Controls.Add(new LiteralControl(" "));
            panel.Controls.Add(topLink);
            panel.Style.Add(HtmlTextWriterStyle.PaddingTop, "2em;");

            return panel;
        }


        public WebControl Directory
        {
            get
            {
                if (!UpToDate && !refreshing)
                    Refresh(true);

                DateTime startTime = DateTime.Now;

                HitCount++;

                CacheTime += DateTime.Now - startTime;

                return _directory;
            }
        }

        public DirectoryManager DirectoryManager
        {
            get { return _directoryManager; }
            set { _directoryManager = value; }
        }
    }
}
