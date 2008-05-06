CREATE PROCEDURE updateSermonBlog
@id smallint,
@title varchar(2000),
@pubDate smalldatetime,
@description TEXT,
 @sermonTextReference varchar(2000)
AS
IF (SELECT COUNT(*) FROM ITEM_DESCRIPTION WHERE ITEM_ID = @id) > 0
BEGIN
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate
WHERE item_id = @id;
UPDATE item_description
set description = @description
where item_id = @id;
update sermon_text_reference
set text_reference = @sermonTextReference
where item_id = @id;
END
ELSE
BEGIN
INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@id, @description);
END