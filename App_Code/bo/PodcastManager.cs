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

            IList items = itemDAO.findItemsPodcast(channelId);

            foreach (Item item in items)
            {
                item.toItunesXML(w);
            }

            w.WriteEndElement(); //channel

            w.WriteEndElement(); //rss
            w.WriteEndDocument();
            w.Flush();

            ms.Position = 0;

            StreamReader sr = new StreamReader(ms);

            return sr.ReadToEnd();
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
    }
}
