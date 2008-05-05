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
using System.Collections;
using System.Globalization;

/// <summary>
/// Summary description for ItemDAO
/// </summary>
public class ItemDAO
{
    private ESVServiceDAO esvServiceDAO;
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RPC"].ConnectionString);
    private static String basefindSql = "SELECT TITLE, LINK, AUTHOR, DESCRIPTION, PUBDATE, TEXT_REFERENCE, URL, SIZE, TYPE FROM item INNER JOIN ITEM_ENCLOSURE on item.item_id = ITEM_ENCLOSURE.item_id LEFT OUTER JOIN ITEM_DESCRIPTION on item.item_id = item_description.item_id LEFT OUTER JOIN SERMON_TEXT_REFERENCE on item.item_id = SERMON_TEXT_REFERENCE.item_id ";
    private static String basefindRSSSql = "SELECT TITLE, LINK, AUTHOR, DESCRIPTION, PUBDATE FROM item LEFT OUTER JOIN ITEM_DESCRIPTION on item.item_id = item_description.item_id ";
    private static String wherePKSql = "WHERE item.channel_id = @channelId ";
    private static String whereActiveSql = "AND ACTIVE = 1 ";
    private static String orderByPrayerSql = "ORDER BY NEW DESC, LAST_UPD_TMS DESC ";
    public static DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
    private static String baseUrl = "http://www.rpcwc.org/";

    public IList findItemsRSS(int channelId)
    {
        if (channelId == 6)
            return findItemsPrayerRSS(channelId);

        connection.Open();
        SqlCommand itemCommand = new SqlCommand(basefindRSSSql + wherePKSql, connection);
        itemCommand.Parameters.AddWithValue("channelId", channelId);

        SqlDataReader dataReader = itemCommand.ExecuteReader();
        IList items = new ArrayList();
        while (dataReader.Read())
        {
            Item item = new Item();

            item.title = getString(dataReader, 0);
            item.url = getString(dataReader, 1);
            item.author = getString(dataReader, 2);
            item.summary = getString(dataReader, 3);
            item.pubDate = getDate(dataReader, 4);
            items.Add(item);
        }

        dataReader.Close();

        connection.Close();
        return items;
    }

    public IList findItemsPrayerRSS(int channelId)
    {
        connection.Open();
        SqlCommand itemCommand = new SqlCommand(basefindRSSSql + wherePKSql + whereActiveSql + orderByPrayerSql, connection);
        itemCommand.Parameters.AddWithValue("channelId", channelId);

        SqlDataReader dataReader = itemCommand.ExecuteReader();
        IList items = new ArrayList();
        while (dataReader.Read())
        {
            Item item = new Item();

            item.title = getString(dataReader, 0);
            item.url = getString(dataReader, 1);
            item.author = getString(dataReader, 2);
            item.summary = getString(dataReader, 3);
            item.pubDate = getDate(dataReader, 4);
            items.Add(item);
        }

        dataReader.Close();

        connection.Close();
        return items;
    }
    
    public IList findItemsPodcast(int channelId)
    {
        connection.Open();
        SqlCommand itemCommand = new SqlCommand(basefindSql + wherePKSql, connection);
        itemCommand.Parameters.AddWithValue("channelId", channelId);

        SqlDataReader dataReader = itemCommand.ExecuteReader();
        IList items = new ArrayList();
        if (dataReader.Read())
        {
            Item item = new Item();

            item.title = getString(dataReader, 0);
            item.url = baseUrl + getString(dataReader, 6);
            item.author = getString(dataReader, 2);
            item.summary = esvServiceDAO.fetchSermonText( getString(dataReader, 5) );
            item.pubDate = getDate(dataReader, 4);
            items.Add(item);
        }

        dataReader.Close();

        connection.Close();
        return items;
    }

    private DateTime getDate(SqlDataReader dataReader, int column)
    {
        return dataReader.GetDateTime(column);
    }

    private string getString(SqlDataReader dataReader, int column)
    {
        if (!dataReader.IsDBNull(column))
            return dataReader.GetString(column);

        return null;
    }

	public ItemDAO()
	{
        esvServiceDAO = new ESVServiceDAO();
		//
		// TODO: Add constructor logic here
		//
	}
}
