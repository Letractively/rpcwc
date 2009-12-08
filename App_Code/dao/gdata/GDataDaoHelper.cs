using System;
using System.Collections.Generic;
using System.Web;
using Google.GData.Client;
using System.Net;
using Google.GData.Photos;
using rpcwc.dao.GData.auth;

/// <summary>
/// Helper class for GData DAOs. Defines and instantiates a Service object.
/// </summary>
namespace rpcwc.dao.GData
{
    public class GDataDaoHelper
    {
        private rpcwc.dao.GData.auth.GDataDaoHelper _gDataDaoHelper;

        public rpcwc.dao.GData.auth.GDataDaoHelper DaoHelper
        {
            get
            {
                if (_gDataDaoHelper == null)
                {
                    _gDataDaoHelper = new auth.GDataDaoHelper();
                }

                return _gDataDaoHelper;
            }
        }

        public Service service
        {
            get { return DaoHelper.service; }
        }

        public PicasaService PicasaService
        {
            get { return DaoHelper.PicasaService; }
        }

        public String Username
        {
            get { return DaoHelper.Username; }
            set { DaoHelper.Username = value; }
        }

        public String PhotoUsername
        {
            get { return DaoHelper.PhotoUsername; }
            set { DaoHelper.PhotoUsername = value; }
        }
    }

}
