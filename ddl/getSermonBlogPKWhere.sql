CREATE  PROCEDURE getSermonBlogPKWhere
@item_id smallint
AS
SELECT     i.item_id id, i.title, i.author, i.link, i.pubDate, id.description, text_reference + ' — ' sermonTextReference, COALESCE (ic_1.comment_count, 0) AS commentCount
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                          (SELECT     item_id, COUNT(*) AS comment_count
                            FROM          item_comment AS ic
                            GROUP BY item_id) AS ic_1 ON ic_1.item_id = i.item_id
LEFT OUTER JOIN sermon_text_reference  str
ON str.item_id = i.item_id
WHERE     (i.channel_id = 1)
AND
	i.item_id = @item_id
ORDER BY i.pubDate DESC