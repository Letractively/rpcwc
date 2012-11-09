using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using rpcwc.dao;
using rpcwc.vo;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for PodcastManager
/// </summary>
namespace rpcwc.bo
{
    public class PodcastManager
    {
        private ChannelDAO _channelDAO;
        private static String itunesXmlns = "http://www.itunes.com/DTDs/Podcast-1.0.dtd";
        private static String FORMAT_PROVIDER = System.Globalization.DateTimeFormatInfo.CurrentInfo.RFC1123Pattern;
        private BlogManager _blogManager;

        public String getFeed(RPCConstants.Channel channelId)
        {
            Channel channel = channelDAO.FindChannel(channelId);

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
            get { return _channelDAO; }
            set { _channelDAO = value; }
        }

        public BlogManager BlogManager
        {
            get { return _blogManager; }
            set { _blogManager = value; }
        }
    }
}
