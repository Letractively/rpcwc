CREATE PROCEDURE getSermonBlogComments
@id smallint
AS
SELECT     comment.item_id, comment.title, comment.author, comment.pubDate, item_description.description
FROM         item INNER JOIN
                      item_comment ON item.item_id = item_comment.item_id INNER JOIN
                      item AS comment ON item_comment.comment_id = comment.item_id INNER JOIN
                      item_description ON comment.item_id = item_description.item_id
WHERE     (item.channel_id = 1)
AND item.item_id = @id
ORDER BY comment.pubDate DESC