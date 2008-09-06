using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for HtmlRedirectHandler
/// </summary>
namespace rpcwc.web
{
    public class HtmlRedirectHandler : IHttpHandler
    {
        private static string redirectCommandString = "findRedirect";
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RPC"].ConnectionString);

        private static String findNewPage(String oldPage)
        {
            String newPage = "";
            connection.Open();
            SqlCommand redirectCommand = new SqlCommand(redirectCommandString, connection);
            redirectCommand.CommandType = CommandType.StoredProcedure;
            redirectCommand.Parameters.AddWithValue("oldPage", oldPage);

            SqlDataReader dataReader = redirectCommand.ExecuteReader();
            if (dataReader.Read())
            {
                newPage = dataReader.GetString(0);
            }

            dataReader.Close();
            connection.Close();

            return newPage;
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            String oldPage = context.Request.AppRelativeCurrentExecutionFilePath;

            String newPage = findNewPage(oldPage);

            if (!newPage.Equals(""))
            {
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", newPage);
            }
            else
            {
                context.Response.Status = "404 Not Found";
            }
        }

        #endregion
    }
}