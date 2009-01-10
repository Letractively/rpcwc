using System;
using System.Collections.Generic;
using System.Web;
using Google.GData.Client;
using System.Net;
using Google.GData.Photos;

/// <summary>
/// Helper class for GData DAOs. Defines and instantiates a Service object.
/// </summary>
namespace rpcwc.dao.GData
{
    public class GDataDaoHelper
    {
        private Service _service;

        private PicasaService _picasaService;

        private String _username = "raymond.rishty@rpcwc.org";

        public Service service
        {
            get
            {
                if (_service == null)
                {
                    _service = new Service("blogger", "rpcwc-blog-1");

                    // ClientLogin using username/password authentication
                    string username = Username;// "raymond.rishty@rpcwc.org";
                    string password = "gr33ntea";

                    service.Credentials = new GDataCredentials(username, password);
                    GDataGAuthRequestFactory requestFactory = (GDataGAuthRequestFactory)service.RequestFactory;
                    //requestFactory.Proxy = new WebProxy(WebRequest.DefaultWebProxy.GetProxy(new Uri("http://www.blogger.com")));
                    requestFactory.AccountType = "GOOGLE";
                }
                return _service;
            }
        }

        public PicasaService PicasaService
        {
            get
            {
                if (_picasaService == null)
                {
                    _picasaService = new PicasaService("rpcwc-photos-1");

                    // ClientLogin using username/password authentication
                    string username = Username;// "raymond.rishty@rpcwc.org";
                    string password = "gr33ntea";

                    _picasaService.Credentials = new GDataCredentials(username, password);
                    GDataGAuthRequestFactory requestFactory = (GDataGAuthRequestFactory)_picasaService.RequestFactory;
                    //requestFactory.Proxy = new WebProxy(WebRequest.DefaultWebProxy.GetProxy(new Uri("http://www.blogger.com")));
                    requestFactory.AccountType = "GOOGLE";
                }
                return _picasaService;
            }
        }

        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }

}
