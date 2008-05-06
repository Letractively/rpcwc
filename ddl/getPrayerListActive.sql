CREATE PROCEDURE getPrayerListActive
@channelId tinyint AS
SELECT     item.item_id, item.author, item.pubDate, item_description.description, item.ACTIVE, item.NEW
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id
WHERE     (item.channel_id = @channelId) AND (item.ACTIVE = 1)