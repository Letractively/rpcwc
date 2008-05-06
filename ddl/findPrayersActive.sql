create procedure findPrayersActive
@channelId tinyint
as
SELECT     item.item_id, item.pubDate, item.author, item.NEW, item_description.description
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id
WHERE     (item.ACTIVE = 1) AND (item.channel_id = @channelId)
ORDER BY item.NEW DESC, item.last_upd_tms DESC