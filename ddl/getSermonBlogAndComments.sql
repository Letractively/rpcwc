CREATE PROCEDURE getSermonBlogAndComments
@item_id smallint
AS
SELECT     i.item_id AS id, i.title, i.author, i.link, i.pubDate, id.description, str.text_reference + ' — ' AS sermonTextReference, NULL AS commentTitle, NULL 
                      AS commentAuthor, NULL AS commentPubDate, NULL AS comment
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                      sermon_text_reference AS str ON str.item_id = i.item_id
WHERE     (i.item_id = @item_id)
UNION ALL
SELECT     NULL AS Expr1, NULL AS Expr2, NULL AS Expr3, NULL AS Expr4, NULL AS Expr5, NULL AS Expr6, NULL AS Expr7, i.title AS commentTitle, 
                      i.author AS commentAuthor, i.pubDate AS commentPubDate, id.description AS comment
FROM         item_comment AS ic INNER JOIN
                      item AS i ON i.item_id = ic.comment_id INNER JOIN
                      item_description AS id ON id.item_id = i.item_id
WHERE     (ic.item_id = @item_id)