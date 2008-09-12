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

        delegate Control BuildBlogPostControlDelegate(BlogEntry blogEntry);

        protected void Page_Load(Object source, EventArgs eventArgs)
        {
            IList<BlogEntry> blogEntries = BlogManager.GetSermonPosts();
            BuildBlogPostControlDelegate buildBlogPostControlDelegate = BlogHelper.buildBlogPostControl;

            IList<IAsyncResult> delegateResults = new List<IAsyncResult>();

            foreach (BlogEntry blogEntry in blogEntries)
            {
                delegateResults.Add(buildBlogPostControlDelegate.BeginInvoke(blogEntry, delegate(IAsyncResult result) { }, null));
            }

            foreach (IAsyncResult result in delegateResults)
            {
                BlogHolder.Controls.Add(buildBlogPostControlDelegate.EndInvoke(result));
            }
        }

        public BlogManager BlogManager
        {
            get { return _blogManager; }
            set { _blogManager = value; }
        }
	
    }
}