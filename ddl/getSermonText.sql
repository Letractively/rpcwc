CREATE PROCEDURE getSermonText AS SELECT     i.item_id, i.title, i.author, i.link, i.pubDate, id.description, ic_1.comment_count
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                          (SELECT     item_id, COUNT(*) AS comment_count
                            FROM          item_comment AS ic
                            GROUP BY item_id) AS ic_1 ON ic_1.item_id = i.item_id
WHERE     (i.channel_id = 1)
ORDER BY i.pubDate DESC