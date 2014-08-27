using System;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.vo.Blog;
using System.Web.UI.HtmlControls;
using System.IO;

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

            if (entry.Scheduled)
                blogPostControl.Controls.Add(BuildScheduledBlogPostTitle(entry));
            else
            {
                blogPostControl.Controls.Add(BuildTitleControl(entry));
                blogPostControl.Controls.Add(titleContentsSeparator);
                blogPostControl.Controls.Add(BuildContentsControl(entry));
                blogPostControl.Controls.Add(contentsFootSeparator);
                blogPostControl.Controls.Add(PostFootControl(entry));
            }
            //blogPostControl.Controls.Add(BuildCategoryPanel(entry));

            return blogPostControl;
        }

        private static WebControl BuildContentsControl(BlogEntry entry)
        {
            Panel contentsControl = new Panel();
            WebControl textControl = new WebControl(HtmlTextWriterTag.P);
            textControl.Controls.Add(new LiteralControl(entry.Content));
            contentsControl.Controls.Add(textControl);

            if (entry.Enclosure != null && entry.Enclosure.Uri != null)
            {
                HtmlGenericControl audio = new HtmlGenericControl("audio");
                audio.Attributes.Add("controls", "controls");
                audio.Attributes.Add("src", entry.Enclosure.Uri);
                audio.Attributes.Add("type", "audio/mp3");
                
                WebControl musicPlayer = new WebControl(HtmlTextWriterTag.Embed);
                musicPlayer.ID = "musicPlayer_" + entry.id;
                musicPlayer.Style.Add(HtmlTextWriterStyle.Width, "400px");
                musicPlayer.Style.Add(HtmlTextWriterStyle.Height, "27px");
                musicPlayer.Style.Add("border", "1px solid rgb(170, 170, 170)");
                musicPlayer.Attributes.Add("src", "http://www.google.com/reader/ui/3523697345-audio-player.swf");
                musicPlayer.Attributes.Add("flashvars", "audioUrl=" + entry.Enclosure.Uri);
                musicPlayer.Attributes.Add("pluginspage", "http://www.macromedia.com/go/getflashplayer");

                audio.Controls.Add(musicPlayer);

                contentsControl.Controls.Add(audio);
            }


            return contentsControl;
        }

        private static WebControl PostFootControl(BlogEntry entry)
        {
            Panel postFootControl = new Panel();
            postFootControl.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            postFootControl.Width = new Unit("100%");
            postFootControl.Style.Add(HtmlTextWriterStyle.PaddingBottom, "2em");

            Panel authorAndDate = new Panel();
            authorAndDate.Style.Add("float", "left");
            WebControl postedBy = new WebControl(HtmlTextWriterTag.I);
            //postedBy.Controls.Add(new LiteralControl("posted by "));
            postedBy.Controls.Add(new LiteralControl("posted at "));
            authorAndDate.Controls.Add(postedBy);
            StringBuilder authorAndDateString = new StringBuilder();
            //authorAndDateString.Append(entry.Author);
            //authorAndDateString.Append(" @ ");
            authorAndDateString.Append(entry.PubDate.ToString("%h:mm tt"));
            authorAndDateString.Append(".");
            authorAndDate.Controls.Add(new LiteralControl(authorAndDateString.ToString()));

            HyperLink commentsControl = new HyperLink();
            commentsControl.NavigateUrl = entry.CommentsLink.Uri;
            commentsControl.Text = entry.CommentsLink.Title;
            
            postFootControl.Controls.Add(authorAndDate);
            postFootControl.Controls.Add(commentsControl);

            return postFootControl;
        }

        private static WebControl BuildScheduledBlogPostTitle(BlogEntry entry)
        {
            Panel titleControl = new Panel();
            titleControl.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            titleControl.Style.Add("border-bottom", "solid 1px #666");
            WebControl dateHeader = new WebControl(HtmlTextWriterTag.H2);
            dateHeader.CssClass = "date-header";
            dateHeader.Controls.Add(new LiteralControl(entry.PubDate.ToString("MMMM d, yyyy")));
            WebControl postTitleHeader = new WebControl(HtmlTextWriterTag.H3);
            postTitleHeader.CssClass = "post-title";
            postTitleHeader.Style.Add(HtmlTextWriterStyle.Color, "gray");
            postTitleHeader.Controls.Add(new LiteralControl(entry.Title));
            titleControl.Controls.Add(dateHeader);
            titleControl.Controls.Add(postTitleHeader);

            return titleControl;
        }

        private static WebControl BuildTitleControl(BlogEntry entry)
        {
            Panel titleControl = new Panel();
            titleControl.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            titleControl.Style.Add("border-bottom", "solid 1px #666");
            //WebControl dateHeader = new WebControl(HtmlTextWriterTag.H2);
            //dateHeader.CssClass = "date-header";
            //dateHeader.Controls.Add(new LiteralControl(entry.PubDate.ToString("MMMM d, yyyy")));
            HyperLink postTitleHeader = new HyperLink();
            postTitleHeader.Font.Size = FontUnit.Parse("14px");
            postTitleHeader.Font.Bold = true;
            postTitleHeader.ForeColor = Color.FromArgb(183,217,125);
            postTitleHeader.CssClass = "post-title";
            postTitleHeader.Controls.Add(new LiteralControl(entry.PubDate.ToString("MMMM d, yyyy: ")));
            postTitleHeader.NavigateUrl = "sermon.aspx?sermonid=" + entry.id;

            postTitleHeader.Controls.Add(new LiteralControl(entry.Title));

            //titleControl.Controls.Add(dateHeader);
            titleControl.Controls.Add(postTitleHeader);

            if (entry.Enclosure != null && entry.Enclosure.Uri != null)
            {
                HyperLink postTitle = new HyperLink();
                postTitle.Text = "(download)";
                postTitle.NavigateUrl = entry.Enclosure.Uri;
                //postTitle.Font.Size = FontUnit.Smaller;
                titleControl.Controls.Add(new LiteralControl(" "));
                titleControl.Controls.Add(postTitle);
            }

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