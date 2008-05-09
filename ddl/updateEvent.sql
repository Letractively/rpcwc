CREATE PROCEDURE updateEvent
@item_id smallint,
@channelId tinyint,
@title varchar(2000),
@pubDate smalldatetime,
@description text,
@allDayEvent bit
AS
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate,
channel_id = @channelId,
all_day_event = @allDayEvent
WHERE ITEM_ID = @item_id

UPDATE ITEM_DESCRIPTION
SET DESCRIPTION = @description
WHERE ITEM_ID = @item_id