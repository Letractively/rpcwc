using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using rpcwc.bo;
using rpcwc.vo.Blog;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for sermon
/// </summary>
namespace rpcwc.web
{
    public partial class SermonPage : Page
    {
        private BlogManager _blogManager;
        private ArrayList _sermonSeriesList;
	
        delegate Control BuildBlogPostControlDelegate(BlogEntry blogEntry);

        protected void Page_Load(Object source, EventArgs eventArgs)
        {
            String label = Request.Params["label"];
            String sermonid = Request.Params["sermonid"];

            if (label != null && !label.Equals(""))
            {
                DisplayPostsInSeries(label);
            }
            else if (sermonid != null && !sermonid.Equals(""))
            {
                DisplayPost(sermonid);
            }
            else
            {
                DisplaySermonSeriesList();
            }
        }

        private void DisplaySermonSeriesList()
        {
            BlogHolder.Style.Add(HtmlTextWriterStyle.TextAlign, "center");

            for (int i = 0; i < SermonSeriesList.Count; i += 2)
            {
                for (int j = i; j <= i + 1 && j < SermonSeriesList.Count; j++)
                    BlogHolder.Controls.Add(BuildSermonSeriesLabel((SermonSeries)SermonSeriesList[j]));

                BlogHolder.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            }

            Panel specialSeriesPanel = new Panel();
            HyperLink specialSeriesLink = new HyperLink();
            specialSeriesLink.Text = "Click here";
            specialSeriesLink.NavigateUrl = ResolveClientUrl("sermon.aspx?label=special");
            specialSeriesPanel.Controls.Add(specialSeriesLink);
            specialSeriesPanel.Controls.Add(new LiteralControl(" to view all special sermons"));

            BlogHolder.Controls.Add(specialSeriesPanel);

            BlogHolder.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        }

        private Control BuildSermonSeriesLabel(SermonSeries sermonSeries)
        {
            HyperLink seriesLink = new HyperLink();
            Image seriesImage = new Image();
            seriesImage.Height = sermonSeries.Height;
            seriesImage.Width = sermonSeries.Width;
            seriesImage.ImageUrl = sermonSeries.ImageUrl;
            //seriesLink.ImageUrl = sermonSeries.ImageUrl;
            //seriesLink.Width = sermonSeries.Width;
            //seriesLink.Height = sermonSeries.Height;// new Unit("150px");
            seriesImage.Style.Add(HtmlTextWriterStyle.Padding, "1em");
            seriesImage.AlternateText = sermonSeries.Caption;
            seriesImage.BorderWidth = 0;
            seriesLink.Controls.Add(seriesImage);
            
            seriesLink.NavigateUrl = ResolveClientUrl(String.Format("sermon.aspx?label={0}", sermonSeries.Label));
            
            WebControl image = new WebControl(HtmlTextWriterTag.Img);
            image.Attributes.Add("src", sermonSeries.ImageUrl);
            image.Height = new Unit("150px");
            image.Style.Add(HtmlTextWriterStyle.Padding, "1em");
            return seriesLink;
        }

        private void DisplayPostsInSeries(String label)
        {
            AddPostsToPage(BlogManager.GetSermonPosts(label));
        }

        private void DisplayPost(String sermonid)
        {
            IList<BlogEntry> posts = new List<BlogEntry>();
            posts.Add(BlogManager.GetSermonPost(sermonid));
            AddPostsToPage(posts);
        }

        private void AddPostsToPage(IList<BlogEntry> blogEntries)
        {
            // Want to build controls asynchronously

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

        public ArrayList SermonSeriesList
        {
            get { return _sermonSeriesList; }
            set { _sermonSeriesList = value; }
        }
    }
}