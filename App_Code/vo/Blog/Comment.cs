using System;

/// <summary>
/// Summary description for Comment
/// </summary>
namespace rpcwc.vo.Blog
{
    public class Comment : RPCVO
    {
        private String _content;

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private DateTime _pubDate;

        public DateTime PubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

        private String _author;

        public String Author
        {
            get { return _author; }
            set { _author = value; }
        }	
    }
}