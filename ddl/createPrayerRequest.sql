CREATE PROCEDURE createPrayerRequest
@channelId tinyint,
@pubDate smalldatetime,
@author varchar(2000),
@description text,
@active bit,
@new bit
AS
INSERT INTO ITEM (channel_id, pubDate, author, title, active, new)
VALUES (@channelId, @pubDate, @author, ' ', @active, @new)
DECLARE @item_id smallint;
SELECT @item_id = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;
INSERT INTO ITEM_DESCRIPTION
(item_id, DESCRIPTION)
VALUES (@item_id, @description)