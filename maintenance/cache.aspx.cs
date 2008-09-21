using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.bo;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.bo.cache;
using System.Reflection;

namespace rpcwc.web.Maintenance
{
    public partial class CacheMaintenance : System.Web.UI.Page
    {
        private CacheManager _cacheManager;

        public void RefreshCache(Object source, CommandEventArgs eventArgs)
        {
            CacheManager.CacheMap[eventArgs.CommandArgument.ToString()].Refresh(false);
        }

        public void Page_Load(Object source, EventArgs eventArgs)
        {
            foreach (AbstractCache cache in CacheManager.CacheList)
            {
                Panel panel = new Panel();
                WebControl cacheName = new WebControl(HtmlTextWriterTag.H3);
                cacheName.Controls.Add(new LiteralControl(cache.GetType().ToString()));
                panel.Controls.Add(cacheName);

                Table table = new Table();
                foreach (PropertyInfo propertyInfo in cache.GetType().GetProperties())
                {
                    if (!propertyInfo.PropertyType.IsSerializable)
                        continue;
                    TableRow tableRow = new TableRow();
                    TableCell tableCellName = new TableCell();
                    TableCell tableCellValue = new TableCell();
                    tableCellName.Controls.Add(new LiteralControl(propertyInfo.Name));
                    tableCellValue.Controls.Add(new LiteralControl(propertyInfo.GetValue(cache, null).ToString()));
                    tableRow.Controls.Add(tableCellName);
                    tableRow.Controls.Add(tableCellValue);
                    table.Controls.Add(tableRow);
                }

                LinkButton refreshLink = new LinkButton();
                refreshLink.Command += RefreshCache;
                refreshLink.CommandArgument = cache.GetType().ToString();
                refreshLink.Text = "Refresh";

                panel.Controls.Add(table);
                panel.Controls.Add(refreshLink);


                //IDictionary<String, Object> attributes = CacheManager.GetAttributes(cache);

                //foreach (KeyValuePair<String, Object> attribute in attributes)
                //{
                //panel.Controls.Add(new LiteralControl(attribute.Key + ": " + attribute.Value));
                //}

                CacheInfo.Controls.Add(panel);
            }
        }

        public void BeginRefresherJob(Object source, CommandEventArgs eventArgs)
        {
            CacheManager.BeginRefreshers();
        }

        public CacheManager CacheManager
        {
            get
            {
                if (_cacheManager == null)
                {
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    _cacheManager = (CacheManager)ctx.GetObject("CacheManager");
                }
                return _cacheManager;
            }
            set { _cacheManager = value; }
        }
    }
}