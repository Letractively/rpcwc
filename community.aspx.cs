using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.bo;

namespace rpcwc.web
{
    public partial class NewsAndNotes : Page
    {
        private NewsAndNotesManager _newsAndNotesManager;

        public void SetObjectDataSourceInstance(Object source, ObjectDataSourceEventArgs eventArgs)
        {
            eventArgs.ObjectInstance = newsAndNotesManager;
        }

        public NewsAndNotesManager newsAndNotesManager
        {
            get { return _newsAndNotesManager; }
            set { _newsAndNotesManager = value; }
        }
    }
}
