using System;

/// <summary>
/// Summary description for SermonSeries
/// </summary>
namespace rpcwc.vo.Blog
{
    public class SermonSeries
    {
        private String _label;

        public String Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private String _imageUrl;

        public String ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        private String _caption;

        public String Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

    }
}
