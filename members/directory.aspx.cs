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

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildCellDelegate buildCellDelegate = DirectoryHelper.makeCell;
            BuildLetterPanelDelegate buildLetterPanelDelegate = buildPanelForLetterAndTable;
            IList<Directory> directory = DirectoryCache.FindDirectoryEntries();

            IList<IAsyncResult> results = new List<IAsyncResult>();

            DirectoryFirstLetterMapKeyCreator mapKeyCreator = new DirectoryFirstLetterMapKeyCreator();
            IDictionary<Char, IList<Directory>> map = CollectionUtils.MapAsLists<Char, Directory>(directory, mapKeyCreator);

            tableholder.Controls.Add(buildAlphabetPanel<IList<Directory>>(map));

            foreach (KeyValuePair<Char, IList<Directory>> keyValuePair in map)
            {
                IAsyncResult result = buildLetterPanelDelegate.BeginInvoke(keyValuePair.Key, keyValuePair.Value, buildCellDelegate, delegate (IAsyncResult res) {}, null);
                results.Add(result);
            }

            foreach (IAsyncResult result in results)
            {
                Control control = buildLetterPanelDelegate.EndInvoke(result);
                tableholder.Controls.Add(control);                
            }
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

            for (int i = 0; i < results.Count; i ++)
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

        public DirectoryCache DirectoryCache
        {
            get { return _directoryCache; }
            set { _directoryCache = value; }
        }
    }
}
