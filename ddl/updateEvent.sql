CREATE PROCEDURE updateEvent
@item_id smallint,
@channelId tinyint,
@title varchar(2000),
@pubDate smalldatetime,
@description text
AS
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate,
channel_id = @channelId
WHERE ITEM_ID = @item_id

UPDATE ITEM_DESCRIPTION
SET DESCRIPTION = @description
WHERE ITEM_ID = @item_id