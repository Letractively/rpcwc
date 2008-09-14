using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.IO;
using System.Xml;
using rpcwc.dao;
using rpcwc.vo;
using rpcwc.vo.Blog;
using System.Collections.Generic;

/// <summary>
/// Summary description for PodcastManager
/// </summary>
namespace rpcwc.bo
{
    public class PodcastManager
    {
        private ChannelDAO _channelDAO;
        private ItemDAO _itemDAO;
        private static String itunesXmlns = "http://www.itunes.com/DTDs/Podcast-1.0.dtd";
        private static String FORMAT_PROVIDER = System.Globalization.DateTimeFormatInfo.CurrentInfo.RFC1123Pattern;
        private BlogManager _blogManager;

        public PodcastManager()
        {
            //channelDAO = new ChannelDAO();
            //itemDAO = new ItemDAO();
            //
            // TODO: Add constructor logic here
            //
        }

        public String getFeed(int channelId)
        {
            Channel channel = channelDAO.findChannel(channelId);

            MemoryStream ms = new MemoryStream();
            XmlTextWriter w = new XmlTextWriter(ms, System.Text.Encoding.UTF8);
            w.Formatting = Formatting.Indented;

            w.WriteStartDocument();
            w.WriteStartElement("rss");
            w.WriteAttributeString("xmlns", "itunes", null, itunesXmlns);
            w.WriteAttributeString("version", "2.0");

            w.WriteStartElement("channel");
            channel.toItunesXml(w);

            /*IList items = itemDAO.findItemsPodcast(channelId);

            foreach (Item item in items)
            {
                item.toItunesXML(w);
            }*/

            IList<BlogEntry> items = BlogManager.GetSermonPosts();
            foreach (BlogEntry item in items)
            {
                if (!item.Scheduled)
                    WriteItunesXML(item, w);
            }

            w.WriteEndElement(); //channel

            w.WriteEndElement(); //rss
            w.WriteEndDocument();
            w.Flush();

            ms.Position = 0;

            StreamReader sr = new StreamReader(ms);

            return sr.ReadToEnd();
        }

        public void WriteItunesXML(BlogEntry blogEntry, XmlTextWriter w)
        {
            if (blogEntry.Enclosure == null || blogEntry.Enclosure.Uri == null || blogEntry.Enclosure.Uri.Equals(""))
                return;

            w.WriteStartElement("item");
            w.WriteElementString("title", blogEntry.Title);
            w.WriteElementString("itunes", "author", null, blogEntry.Author);
            //w.WriteElementString("itunes", "subtitle", null, blogEntry.sub);
            w.WriteElementString("itunes", "summary", null, blogEntry.Content);
            w.WriteElementString("pubDate", blogEntry.PubDate.ToString(FORMAT_PROVIDER));
            w.WriteStartElement("enclosure");
            w.WriteAttributeString("url", blogEntry.Enclosure.Uri);
            w.WriteAttributeString("type", blogEntry.Enclosure.Type);
            w.WriteEndElement();
            w.WriteElementString("guid", blogEntry.Enclosure.Uri);
            w.WriteEndElement();
        }

        public ChannelDAO channelDAO
        {
            get
            {
                return _channelDAO;
            }
            set
            {
                _channelDAO = value;
            }
        }

        public ItemDAO itemDAO
        {
            get
            {
                return _itemDAO;
            }
            set
            {
                _itemDAO = value;
            }
        }

        public BlogManager BlogManager
        {
            get { return _blogManager; }
            set { _blogManager = value; }
        }
    }
}
