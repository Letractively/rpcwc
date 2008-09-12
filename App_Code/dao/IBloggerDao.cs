using System;
using System.Collections.Generic;
using System.Web;
using Google.GData.Client;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for BloggerDao
/// </summary>
namespace rpcwc.dao
{
    public interface IBloggerDao
    {
        /// <summary>
        /// Retrieves all blog posts
        /// </summary>
        /// <returns>A collection of BlogEntry objects</returns>
        IList<BlogEntry> GetAllEntries();

        /// <summary>
        /// Retrieves all blog posts with the specified labels
        /// </summary>
        /// <param name="label">A "tag" or "category" associated with blog posts. Posts can have more than one tag.</param>
        /// <returns>A collection of BlogEntry objects</returns>
        IList<BlogEntry> GetEntriesByLabel(params String[] label);

        /// <summary>
        /// Retrieves a specific blog post with comments by id.
        /// </summary>
        /// <param name="id">Unique blog post id</param>
        /// <returns>A BlogEntry object, with comments populated</returns>
        BlogEntry GetEntry(String id);
    }
}