using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using rpcwc.bo;
using rpcwc.vo.Blog;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for sermon
/// </summary>
namespace rpcwc.web
{
    public partial class SermonPage : Page
    {
        private BlogManager _blogManager;

        protected void Page_Load(Object source, EventArgs eventArgs)
        {
            IList<BlogEntry> blogEntries = BlogManager.GetSermonPosts();

            foreach (BlogEntry blogEntry in blogEntries)
            {
                BlogHolder.Controls.Add(BlogHelper.buildBlogPostControl(blogEntry));
            }
        }

        public BlogManager BlogManager
        {
            get { return _blogManager; }
            set { _blogManager = value; }
        }
	
    }
}