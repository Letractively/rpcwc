CREATE PROCEDURE createEvent
@channelId tinyint,
@title varchar(2000),
@pubDate smalldatetime,
@description text
AS
INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE) VALUES (@channelId, @title, '', @pubDate)

DECLARE @itemid smallint;

SELECT @itemid = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;

INSERT INTO ITEM_DESCRIPTION
(ITEM_ID, DESCRIPTION) VALUES (@itemid, @description)