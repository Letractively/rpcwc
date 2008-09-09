using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.bo;

namespace rpcwc.web
{
    public partial class Bulletin : Page
    {
        private BulletinManager _bulletinManager;

        public void SetObjectDataSourceInstance(Object source, ObjectDataSourceEventArgs eventArgs)
        {
            eventArgs.ObjectInstance = bulletinManager;
        }

        public BulletinManager bulletinManager
        {
            get { return _bulletinManager; }
            set { _bulletinManager = value; }
        }
    }
}