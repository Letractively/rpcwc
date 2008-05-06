CREATE PROCEDURE findAlerts
@channelId tinyint AS
SELECT i.item_id, author, pubDate, description, CAST(COALESCE(alert,0) as bit) alert, CAST(COALESCE(active,0) as bit) active from item i inner join item_alert ia on i.item_id = ia.item_id inner join item_description id on i.item_id = id.item_id where i.channel_id = @channelId