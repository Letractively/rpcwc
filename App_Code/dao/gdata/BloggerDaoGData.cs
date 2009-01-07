using System;
using System.Web;
using Google.GData.Client;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BloggerDaoGData
/// </summary>
namespace rpcwc.dao.GData
{
    public class BloggerDaoGData : IBloggerDao
    {
        private String _blogid;
        private GDataDaoHelper _gdataDaoHelper;
        private Service _service;
        private Regex _permalinkRegex;
        private Regex _commentIdRegex;

        #region IBloggerDao Members

        public IList<BlogEntry> GetAllEntries()
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri("http://www.blogger.com/feeds/" + BlogId + "/posts/default");
            query.NumberToRetrieve = 200;

            return MapEntries(Service.Query(query).Entries);
        }

        public IList<BlogEntry> GetEntriesByLabel(params String[] labels)
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri("http://www.blogger.com/feeds/" + BlogId + "/posts/default");
            foreach (String label in labels)
            {
                if (label != null && !label.Equals(""))
                    query.Categories.Add(new QueryCategory(new AtomCategory(label)));
            }
            query.CategoryQueriesAsParameter = true;

            return MapEntries(Service.Query(query).Entries);
        }

        public delegate AtomEntry GetPostDelegate(string postId);
        public delegate AtomFeed GetCommentsDelegate(string postId);


        public BlogEntry GetEntry(string postId)
        {
            GetPostDelegate getPostDelegate = GetPostAtomEntry;
            GetCommentsDelegate getCommentsDelegate = GetComments;
            
            IAsyncResult postAsyncResult = getPostDelegate.BeginInvoke(postId, delegate(IAsyncResult result) { }, null);
            IAsyncResult commentsAsyncResult = getCommentsDelegate.BeginInvoke(postId, delegate(IAsyncResult result) { }, null);

            return MapEntry(getPostDelegate.EndInvoke(postAsyncResult), getCommentsDelegate.EndInvoke(commentsAsyncResult));
        }

        private AtomEntry GetPostAtomEntry(string postId)
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri("http://www.blogger.com/feeds/" + BlogId + "/posts/default/" + postId);

            return Service.Query(query).Entries[0];
        }

        private AtomFeed GetComments(string postId)
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri("http://www.blogger.com/feeds/" + BlogId + "/" + postId + "/comments/default");

            return Service.Query(query);
        }

        #endregion

        private delegate BlogEntry MapEntryDelegate(AtomEntry entry);

        private IList<BlogEntry> MapEntries(AtomEntryCollection entries)
        {
            // Perform mapping asynchronously

            IList<BlogEntry> entryList = new List<BlogEntry>();
            IList<IAsyncResult> entryAsyncResultList = new List<IAsyncResult>();
            MapEntryDelegate mapEntryDelegate = MapEntry;

            // Invoke all calls to mapping method
            foreach (AtomEntry entry in entries)
            {
                entryAsyncResultList.Add(mapEntryDelegate.BeginInvoke(entry, delegate(IAsyncResult result) { }, null));
            }

            // Collect all results
            foreach (IAsyncResult result in entryAsyncResultList)
            {
                entryList.Add(mapEntryDelegate.EndInvoke(result));
            }

            return entryList;
        }

        private BlogEntry MapEntry(AtomEntry entry)
        {
            DateTime pubDate = entry.Published.ToLocalTime();
            if (pubDate.CompareTo(DateTime.Now) <= 0 && entry.IsDraft)
                return null;

            BlogEntry blogEntry = new BlogEntry();

            blogEntry.Scheduled = pubDate.CompareTo(DateTime.Now) > 0;
            blogEntry.Content = entry.Content.Content;
            blogEntry.Title = entry.Title.Text;
            blogEntry.PubDate = pubDate;
            blogEntry.Author = entry.Authors[0].Name;
            blogEntry.Summary = entry.Summary.Text;
            //blogEntry.MediaUri = entry.MediaUri != null ? entry.MediaUri.Content : null;
            //blogEntry.Links = new List<Link>();
            foreach (AtomLink link in entry.Links)
            {
                if (link.Type.Equals("audio/mpeg"))
                    blogEntry.Enclosure = mapLink(link);
                else if (link.Rel.Equals("replies") && link.Type.Equals("text/html"))
                    blogEntry.CommentsLink = mapLink(link);
                //blogEntry.Links.Add(mapLink(link));
            }
            blogEntry.Permalink = entry.SelfUri.Content;
            blogEntry.id = PermalinkRegex.Match(blogEntry.Permalink).Groups["postid"].Value;
            blogEntry.Categories = new List<String>();
            foreach (AtomCategory category in entry.Categories)
            {
                blogEntry.Categories.Add(category.Term);
            }

            return blogEntry;
        }

        private Link mapLink(AtomLink link)
        {
            Link linkObj = new Link();
            linkObj.Rel = link.Rel;
            linkObj.Title = link.Title;
            linkObj.Type = link.Type;
            linkObj.Uri = link.AbsoluteUri;

            return linkObj;
        }

        private BlogEntry MapEntry(AtomEntry entry, AtomFeed comments)
        {
            BlogEntry blogEntry = MapEntry(entry);

            blogEntry.Comments = new List<Comment>();

            foreach (AtomEntry atomComment in comments.Entries)
            {
                Comment comment = new Comment();
                comment.Content = atomComment.Content.Content;
                comment.PubDate = atomComment.Published;
                comment.Author = atomComment.Authors[0].Name;
                comment.id = CommentIdRegex.Match(atomComment.SelfUri.Content).Groups["commentid"].Value;
                blogEntry.Comments.Add(comment);
            }

            return blogEntry;
        }

        public Service Service
        {
            get
            {
                if (_service == null)
                    _service = GDataDaoHelper.service;
                return _service;
            }
        }

        public String BlogId
        {
            get { return _blogid; }
            set { _blogid = value; }
        }

        public GDataDaoHelper GDataDaoHelper
        {
            get { return _gdataDaoHelper; }
            set { _gdataDaoHelper = value; }
        }

        public Regex PermalinkRegex
        {
            get { return _permalinkRegex; }
            set { _permalinkRegex = value; }
        }

        public Regex CommentIdRegex
        {
            get { return _commentIdRegex; }
            set { _commentIdRegex = value; }
        }
    }
}