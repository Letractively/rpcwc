CREATE PROCEDURE getMarquee
@channelId tinyint
AS
SELECT     item_description.description, ITEM_ALERT.alert
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id INNER JOIN
                      ITEM_ALERT ON item.item_id = ITEM_ALERT.ITEM_ID
WHERE     (item.channel_id = @channelId) AND (ITEM.active = 1)