using System;
using System.Xml;

/// <summary>
/// Summary description for Item
/// </summary>
namespace rpcwc.vo
{
    public class Item : IComparable
    {
        private String _url;
        private String _author;
        private String _title;
        private String _summary;
        private String _subtitle;
        private DateTime _pubDate;
        static String _formatProvider = System.Globalization.DateTimeFormatInfo.CurrentInfo.RFC1123Pattern;

        public void toItunesXML(XmlTextWriter w)
        {
            if (url == null || url.Equals(""))
                return;

            w.WriteStartElement("item");
            w.WriteElementString("title", title);
            w.WriteElementString("itunes", "author", null, author);
            w.WriteElementString("itunes", "subtitle", null, subtitle);
            w.WriteElementString("itunes", "summary", null, summary);
            w.WriteElementString("pubDate", pubDate.ToString(formatProvider));
            w.WriteStartElement("enclosure");
            w.WriteAttributeString("url", url);
            w.WriteAttributeString("type", getType(url));
            w.WriteEndElement();
            w.WriteElementString("guid", url);
            w.WriteEndElement();
        }

        public void toRSSXML(XmlTextWriter w)
        {
            /*
            if (url == null || url.Equals(""))
                return;
             */

            w.WriteStartElement("item");
            w.WriteElementString("title", title);
            w.WriteElementString("author", null, author);
            w.WriteElementString("description", null, summary);
            w.WriteElementString("pubDate", pubDate.ToString(formatProvider));
            w.WriteElementString("link", url);
            w.WriteElementString("guid", url);
            w.WriteEndElement();
        }

        static public String getType(String filename)
        {
            String[] filePartArray = filename.Split((".").ToCharArray());
            String ext = (String)filePartArray.GetValue(filePartArray.Length - 1);
            switch (ext)
            {
                case "mp3":
                    return "audio/mpeg";
                case "wma":
                    return "audio/x-ms-wma";
            }

            return "";
        }

        public String url
        {
            get { return _url; }
            set { _url = value; }
        }

        public String author
        {
            get { return _author; }
            set { _author = value; }
        }

        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public String subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }

        public DateTime pubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

        public String formatProvider
        {
            get { return _formatProvider; }
            set { _formatProvider = value; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return pubDate.CompareTo(((Item)obj).pubDate);
        }

        #endregion
    }
}
