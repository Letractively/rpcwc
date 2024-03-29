CREATE PROCEDURE createEvent
@channelId tinyint,
@title varchar(2000),
@pubDate smalldatetime,
@description text,
@allDayEvent bit
AS
INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE, ALL_DAY_EVENT) VALUES (@channelId, @title, '', @pubDate, @allDayEvent)

DECLARE @itemid smallint;

SELECT @itemid = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;

INSERT INTO ITEM_DESCRIPTION
(ITEM_ID, DESCRIPTION) VALUES (@itemid, @description)