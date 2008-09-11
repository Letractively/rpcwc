using System;
using Google.GData.Client;

/// <summary>
/// Summary description for Link
/// </summary>
namespace rpcwc.vo.Blog
{
    public class Link : RPCVO
    {
        private String _rel;

        public String Rel
        {
            get { return _rel; }
            set { _rel = value; }
        }

        private String _title;

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _type;

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private String _uri;

        public String Uri
        {
            get { return  _uri; }
            set {  _uri = value; }
        }
    }
}