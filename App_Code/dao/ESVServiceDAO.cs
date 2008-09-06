using System;
using System.Net;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// Summary description for ESVServiceDAO
/// </summary>
namespace rpcwc.dao
{
    public class ESVServiceDAO
    {
        //public bool includeContentType = false;
        //public static int lineLength { get; set; }
        //public bool includePassageReferences = true;
        //public bool includeFirstverseNumbers = false;
        //public bool includeVerseNumbers = false;
        //public bool includeFootnotes = false;
        //public bool includeFootnoteLinks = false;
        //public bool includeHeadings = false;
        //public bool includeSubheadings = false;
        //public bool includePassageHorizontalLines = false;
        //public bool includeHeadingHorizontalLines = false;
        //public String outputFormat = "plain-text";

        private bool _includeContentType;
        private int _lineLength;
        private bool _includePassageReferences;
        private bool _includeFirstverseNumbers;
        private bool _includeVerseNumbers;
        private bool _includeFootnotes;
        private bool _includeFootnoteLinks;
        private bool _includeHeadings;
        private bool _includeSubheadings;
        private bool _includePassageHorizontalLines;
        private bool _includeHeadingHorizontalLines;
        private String _outputFormat;
        private String _key;

        public String fetchSermonText(String reference)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(getQueryInfo(reference));
            if (xmlDocument.SelectNodes("//warnings").Count > 0)
                return reference;
            else
                return getText(reference);
        }


        public String getText(String passage)
        {
            StringBuilder sUrl = new StringBuilder();
            sUrl.Append("http://www.esvapi.org/v2/rest/passageQuery");
            sUrl.Append("?key=" + key);
            sUrl.Append("&passage=" + passage);
            sUrl.Append("&include-passage-references=" + includePassageReferences.ToString().ToLower());
            sUrl.Append("&include-first-verse-numbers=" + includeFirstverseNumbers.ToString().ToLower());
            sUrl.Append("&include-verse-numbers=" + includeVerseNumbers.ToString().ToLower());
            sUrl.Append("&include-footnotes=" + includeFootnotes.ToString().ToLower());
            sUrl.Append("&include-footnote-links=" + includeFootnoteLinks.ToString().ToLower());
            sUrl.Append("&include-headings=" + includeHeadings.ToString().ToLower());
            sUrl.Append("&include-subheadings=" + includeSubheadings.ToString().ToLower());
            sUrl.Append("&include-passage-horizontal-lines=" + includePassageHorizontalLines.ToString().ToLower());
            sUrl.Append("&include-heading-horizontal-lines=" + includeHeadingHorizontalLines.ToString().ToLower());
            //  sUrl.Append("&include-content-type=" + includeContentType.ToString().ToLower());
            //  sUrl.Append("&line-length=" + lineLength.ToString().ToLower());
            sUrl.Append("&output-format=" + outputFormat);

            Console.Out.WriteLine(sUrl.ToString());

            WebRequest oReq = WebRequest.Create(sUrl.ToString());
            StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

            StringBuilder sOut = new StringBuilder();
            sOut.Append(sStream.ReadToEnd());
            sStream.Close();

            Regex regex = new Regex("\n([^ ])");
            return regex.Replace(sOut.ToString(), "$1");
        }

        public String getQueryInfo(String passage)
        {
            StringBuilder sUrl = new StringBuilder();
            sUrl.Append("http://www.esvapi.org/v2/rest/queryInfo");
            sUrl.Append("?key=IP");
            sUrl.Append("&q=" + passage);

            Console.Out.WriteLine(sUrl.ToString());

            WebRequest oReq = WebRequest.Create(sUrl.ToString());
            StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

            StringBuilder sOut = new StringBuilder();
            sOut.Append(sStream.ReadToEnd());
            sStream.Close();

            return sOut.ToString();
        }



        public bool includeContentType
        {
            get
            {
                return _includeContentType;
            }
            set
            {
                _includeContentType = value;
            }
        }
        public int lineLength
        {
            get
            {
                return _lineLength;
            }
            set
            {
                _lineLength = value;
            }
        }
        public bool includePassageReferences
        {
            get
            {
                return _includePassageReferences;
            }
            set
            {
                _includePassageReferences = value;
            }
        }
        public bool includeFirstverseNumbers
        {
            get
            {
                return _includeFirstverseNumbers;
            }
            set
            {
                _includeFirstverseNumbers = value;
            }
        }
        public bool includeVerseNumbers
        {
            get
            {
                return _includeVerseNumbers;
            }
            set
            {
                _includeVerseNumbers = value;
            }
        }
        public bool includeFootnotes
        {
            get
            {
                return _includeFootnotes;
            }
            set
            {
                _includeFootnotes = value;
            }
        }
        public bool includeFootnoteLinks
        {
            get
            {
                return _includeFootnoteLinks;
            }
            set
            {
                _includeFootnoteLinks = value;
            }
        }
        public bool includeHeadings
        {
            get
            {
                return _includeHeadings;
            }
            set
            {
                _includeHeadings = value;
            }
        }
        public bool includeSubheadings
        {
            get
            {
                return _includeSubheadings;
            }
            set
            {
                _includeSubheadings = value;
            }
        }
        public bool includePassageHorizontalLines
        {
            get
            {
                return _includePassageHorizontalLines;
            }
            set
            {
                _includePassageHorizontalLines = value;
            }
        }
        public bool includeHeadingHorizontalLines
        {
            get
            {
                return _includeHeadingHorizontalLines;
            }
            set
            {
                _includeHeadingHorizontalLines = value;
            }
        }
        public String outputFormat
        {
            get
            {
                return _outputFormat;
            }
            set
            {
                _outputFormat = value;
            }
        }
        public String key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }
    }
}
