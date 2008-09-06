using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;

/// <summary>
/// Summary description for Channel
/// </summary>
namespace rpcwc.vo
{
    public class Channel
    {
        private String _title;
        private String _link;
        private String _copyright;
        private String _subtitle;
        private String _author;
        private String _summary;
        private String _ownerName;
        private String _ownerEmail;
        private String _imageURL;
        private String _language;
        private String _category0;
        private String _category00;

        public void toItunesXml(XmlWriter w)
        {
            w.WriteElementString("title", title);
            w.WriteElementString("link", link);
            w.WriteElementString("copyright", copyright);
            w.WriteElementString("itunes", "subtitle", null, null);
            w.WriteElementString("itunes", "author", null, author);
            w.WriteElementString("description", summary);
            w.WriteStartElement("itunes", "owner", null);
            w.WriteElementString("itunes", "name", null, ownerName);
            w.WriteElementString("itunes", "email", null, ownerEmail);
            w.WriteEndElement();
            if (imageURL != null && !imageURL.Equals(""))
            {
                w.WriteStartElement("itunes", "image", null);
                w.WriteAttributeString("href", imageURL);
                w.WriteEndElement();
            }
            w.WriteElementString("itunes", "explicit", null, "no");
            w.WriteElementString("language", "en-us");
            w.WriteStartElement("itunes", "category", null);
            w.WriteAttributeString("text", category0);
            w.WriteStartElement("itunes", "category", null);
            w.WriteAttributeString("text", category00);
            w.WriteEndElement();
            w.WriteEndElement();
        }

        internal void toRSSXml(XmlTextWriter w)
        {
            w.WriteElementString("title", title);
            w.WriteElementString("link", link);
            w.WriteElementString("copyright", copyright);
            w.WriteElementString("subtitle", null, null);
            w.WriteElementString("author", null, author);
            w.WriteElementString("description", summary);
            /*
            w.WriteStartElement("itunes", "owner", null);
            w.WriteElementString("itunes", "name", null, ownerName);
            w.WriteElementString("itunes", "email", null, ownerEmail);
            w.WriteEndElement();
             * */
            /*
            if (imageURL != null && !imageURL.Equals(""))
            {
                w.WriteStartElement("image", null);
                w.WriteAttributeString("href", imageURL);
                w.WriteEndElement();
            }
             * */
            w.WriteElementString("language", "en-us");
            /*
            w.WriteStartElement("itunes", "category", null);
            w.WriteAttributeString("text", category0);
            w.WriteStartElement("itunes", "category", null);
            w.WriteAttributeString("text", category00);
            w.WriteEndElement();
            w.WriteEndElement();
             */
        }

        public String title
        {
            get { return _title; }
            set { _title = value; }
        }
        public String link
        {
            get { return _link; }
            set { _link = value; }
        }
        public String copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }
        public String subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }
        public String author
        {
            get { return _author; }
            set { _author = value; }
        }
        public String summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        public String ownerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }
        public String ownerEmail
        {
            get { return _ownerEmail; }
            set { _ownerEmail = value; }
        }
        public String imageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }
        public String language
        {
            get { return _language; }
            set { _language = value; }
        }
        public String category0
        {
            get { return _category0; }
            set { _category0 = value; }
        }
        public String category00
        {
            get { return _category00; }
            set { _category00 = value; }
        }

    }
}
