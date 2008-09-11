using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BlogHelper
/// </summary>
namespace rpcwc.web
{
    public class BlogHelper
    {
        /// <summary>
        /// Builds a web control for a blog post
        /// </summary>
        /// <param name="entry">Blog post to be built into a web control</param>
        /// <returns>A web control presentation of the given blog post</returns>
        public static Control buildBlogPostControl(BlogEntry entry)
        {
            Control blogPostControl = new Control();
            if (entry == null)
                return blogPostControl;

            WebControl titleContentsSeparator = new WebControl(HtmlTextWriterTag.Br);
            titleContentsSeparator.Attributes.Add("clear", "all");
            
            WebControl contentsFootSeparator = new WebControl(HtmlTextWriterTag.Br);
            contentsFootSeparator.Attributes.Add("clear", "all");
            
            blogPostControl.Controls.Add(BuildTitleControl(entry));
            blogPostControl.Controls.Add(titleContentsSeparator);
            blogPostControl.Controls.Add(BuildContentsControl(entry));
            blogPostControl.Controls.Add(contentsFootSeparator);
            blogPostControl.Controls.Add(PostFootControl(entry));
            blogPostControl.Controls.Add(BuildCategoryPanel(entry));

            return blogPostControl;
        }

        private static WebControl BuildContentsControl(BlogEntry entry)
        {
            WebControl contentsControl = new WebControl(HtmlTextWriterTag.P);
            contentsControl.Controls.Add(new LiteralControl(entry.Content));

            return contentsControl;
        }

        private static WebControl PostFootControl(BlogEntry entry)
        {
            Panel postFootControl = new Panel();
            postFootControl.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            postFootControl.Width = new Unit("100%");

            Panel authorAndDate = new Panel();
            authorAndDate.Style.Add("float", "left");
            WebControl postedBy = new WebControl(HtmlTextWriterTag.I);
            postedBy.Controls.Add(new LiteralControl("posted by "));
            authorAndDate.Controls.Add(postedBy);
            StringBuilder authorAndDateString = new StringBuilder();
            authorAndDateString.Append(entry.Author);
            authorAndDateString.Append(" @ ");
            authorAndDateString.Append(entry.PubDate.ToString("%h:mm tt"));
            authorAndDateString.Append(".");
            authorAndDate.Controls.Add(new LiteralControl(authorAndDateString.ToString()));

            HyperLink commentsControl = new HyperLink();
            Link commentsLink = entry.Links[1];
            commentsControl.NavigateUrl = commentsLink.Uri;
            commentsControl.Text = commentsLink.Title;
            
            postFootControl.Controls.Add(authorAndDate);
            postFootControl.Controls.Add(commentsControl);

            return postFootControl;
        }

        private static WebControl BuildTitleControl(BlogEntry entry)
        {
            Panel titleControl = new Panel();
            titleControl.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            titleControl.Style.Add("border-bottom", "solid 1px #666");
            WebControl dateHeader = new WebControl(HtmlTextWriterTag.H2);
            dateHeader.CssClass = "date-header";
            dateHeader.Controls.Add(new LiteralControl(entry.PubDate.ToString("MMMM d, yyyy")));
            WebControl postTitleHeader = new WebControl(HtmlTextWriterTag.H3);
            postTitleHeader.CssClass = "post-title";
            if (entry.MediaUri != null && !entry.MediaUri.Equals(""))
            {
                HyperLink postTitle = new HyperLink();
                postTitle.Text = entry.Title;
                postTitle.NavigateUrl = entry.MediaUri;
                postTitleHeader.Controls.Add(postTitle);
            } else
                postTitleHeader.Controls.Add(new LiteralControl(entry.Title));
            titleControl.Controls.Add(dateHeader);
            titleControl.Controls.Add(postTitleHeader);

            return titleControl;
        }

        public static Panel BuildCategoryPanel(BlogEntry entry)
        {
            Panel categoriesPanel = new Panel();
            categoriesPanel.CssClass = "blogPostLabel";
            categoriesPanel.Style.Add(HtmlTextWriterStyle.TextAlign, "right");

            if (entry.Categories.Count > 0)
            {
                String category = entry.Categories[0];
                HyperLink hyperLink = new HyperLink();
                hyperLink.NavigateUrl = "blog.aspx?label=" + category;
                hyperLink.Text = category;
                categoriesPanel.Controls.Add(hyperLink);
            }

            for (int i = 1; i < entry.Categories.Count; i++)
            {
                String category = entry.Categories[i];
                Literal labelSeparator = new Literal();
                labelSeparator.Text = ", ";
                categoriesPanel.Controls.Add(labelSeparator);

                HyperLink hyperLink = new HyperLink();
                hyperLink.NavigateUrl = "blog.aspx?label=" + category;
                hyperLink.Text = category;
                categoriesPanel.Controls.Add(hyperLink);
            }

            return categoriesPanel;
        }
    }
}