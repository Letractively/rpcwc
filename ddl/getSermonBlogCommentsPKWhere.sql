CREATE PROCEDURE getSermonBlogCommentsPKWhere
@item_id smallint
AS
SELECT
i.item_id item_id,
i.title title,
i.author author,
i.pubDate pubDate,
id.description comment
FROM item_comment ic
INNER JOIN item i ON i.item_id = ic.comment_id
INNER JOIN item_description id ON id.item_id = i.item_id
WHERE ic.item_id = @item_id