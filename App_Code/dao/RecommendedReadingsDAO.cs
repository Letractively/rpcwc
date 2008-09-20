using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using rpcwc.vo.Blog;

/// <summary>
/// Summary description for RecommendedReadingsDAO
/// </summary>
namespace rpcwc.dao
{
    public interface RecommendedReadingsDAO
    {
        void MarkAsRead(Int16 itemId);

        /// <summary>
        /// Returns the list of all recommended readings
        /// </summary>
        /// <returns>HyperLink controls, populated with image url, link href, and alt-text</returns>
        IList FindAllActiveRecommendedReadings();
    }
}
