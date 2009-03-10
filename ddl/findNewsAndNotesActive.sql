CREATE PROCEDURE findNewsAndNotesActive
@channelId tinyint
AS
SELECT     item_description.description
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id
WHERE     (item.channel_id = @channelId) AND (item.ACTIVE = 1)
order by pubDate