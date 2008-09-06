using System;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RecommendedReadingsDAO
/// </summary>
namespace rpcwc.dao
{
    public interface RecommendedReadingsDAO
    {
        void MarkAsRead(Int16 itemId);
    }
}
