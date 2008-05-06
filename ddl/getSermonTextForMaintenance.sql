CREATE PROCEDURE getSermonTextForMaintenance AS
SELECT     i.item_id, i.title, i.author, i.pubDate, id.description, STR.text_reference
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                      sermon_text_reference AS STR ON i.item_id = STR.item_id
WHERE     (i.channel_id = 1)