using System;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RecommendedReadingsDAO
/// </summary>
public class RecommendedReadingsDAO
{
    private static string markReadingAsReadCommandString = "UPDATE ITEM SET ALL_DAY_EVENT = NULL WHERE ITEM_ID = @itemId";
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RPC"].ConnectionString);

	public RecommendedReadingsDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void MarkAsRead(Int16 itemId)
    {
        connection.Open();
        SqlCommand markReadingAsReadCommand = new SqlCommand(markReadingAsReadCommandString, connection);
        markReadingAsReadCommand.Parameters.AddWithValue("itemId", itemId);
        markReadingAsReadCommand.ExecuteNonQuery();
        connection.Close();

    }
}
