CREATE PROCEDURE updateEvent
@item_id smallint,
@title varchar(2000),
@pubDate smalldatetime,
@description text
AS
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate
WHERE ITEM_ID = @item_id

UPDATE ITEM_DESCRIPTION
SET DESCRIPTION = @description
WHERE ITEM_ID = @item_id