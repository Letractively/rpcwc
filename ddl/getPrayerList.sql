CREATE procedure getPrayerList
@channelId tinyint,
@startDate smalldatetime
as
SELECT     item.item_id, item.author, item.pubDate, item_description.description
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id
WHERE     (item.channel_id = @channelId) AND (item.pubDate > @startDate)