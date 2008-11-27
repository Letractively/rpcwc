using System;
using System.Collections;
using System.IO;
using System.Xml;
using rpcwc.dao;
using rpcwc.vo;
using System.Collections.Generic;

/// <summary>
/// Summary description for RSSManager
/// </summary>
namespace rpcwc.bo
{
    public class RSSManager
    {
        private ChannelDAO _channelDAO;
        private ItemDAO _itemDAO;

        public String getFeed(int channelId)
        {
            Channel channel = channelDAO.findChannel(channelId);

            MemoryStream ms = new MemoryStream();
            XmlTextWriter w = new XmlTextWriter(ms, System.Text.Encoding.UTF8);
            w.Formatting = Formatting.Indented;

            w.WriteStartDocument();
            w.WriteStartElement("rss");
            //w.WriteAttributeString("xmlns", "itunes", null, itunesXmlns);
            w.WriteAttributeString("version", "2.0");

            w.WriteStartElement("channel");
            channel.toRSSXml(w);

            IList<Item> items = itemDAO.findItemsRSS(channelId);

            foreach (Item item in items)
            {
                item.toRSSXML(w);
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
            get { return _channelDAO; }
            set { _channelDAO = value; }
        }

        public ItemDAO itemDAO
        {
            get { return _itemDAO; }
            set { _itemDAO = value; }
        }
    }
}
