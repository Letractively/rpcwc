CREATE PROCEDURE findSpecialEventsFuture
@channelId tinyint
AS
SELECT     i.item_id, i.pubDate, i.title, i.all_day_event allDayEvent, i.channel_id channelId, i.author, id.description
        FROM         item AS i INNER JOIN
                              item_description AS id ON i.item_id = id.item_id
        WHERE     (i.channel_id = @channelId) AND (i.pubDate > GETDATE())
        ORDER BY i.pubDate