CREATE PROCEDURE getSermonAudioList as
SELECT     item.item_id id, item.title, item_enclosure.url, item_enclosure.size, item_enclosure.type, item.author, item.pubDate, sermon_text_reference.text_reference AS sermonTextReference
FROM         item LEFT OUTER JOIN
                      sermon_text_reference ON item.item_id = sermon_text_reference.item_id
		      LEFT OUTER JOIN item_enclosure on item.item_id = item_enclosure.item_id
WHERE     (item.channel_id = 1)