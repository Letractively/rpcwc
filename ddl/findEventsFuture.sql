CREATE PROCEDURE findEventsFuture
@channelIdSpecial tinyint,
@channelIdRegular tinyint
AS
SELECT     i.item_id, i.pubDate, i.title, id.description, i.author, i.channel_id channelId
FROM         item AS i INNER JOIN
                      item_description AS id ON i.item_id = id.item_id
WHERE     (i.channel_id = @channelIdSpecial) OR (i.channel_id = @channelIdRegular) AND (i.pubDate >= GETDATE())