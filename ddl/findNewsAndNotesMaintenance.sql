CREATE PROCEDURE findNewsAndNotesMaintenance
@channelId tinyint
AS
SELECT     item.item_id AS itemId, item.ACTIVE, item_description.description
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id
WHERE     (item.channel_id = @channelId)