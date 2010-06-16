using System;
using System.Net;

namespace rpcwc.util
{
    public class WebUtil
    {
        public static bool IsURLExtant(String url)
        {

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "HEAD";

            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (System.Net.WebException exception)
            {
                return (exception.Status == WebExceptionStatus.Success);
            }
        }
    }
}