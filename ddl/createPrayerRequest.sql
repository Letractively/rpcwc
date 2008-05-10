CREATE PROCEDURE createPrayerRequest
@channelId tinyint,
@pubDate smalldatetime,
@author varchar(2000),
@description text,
@active bit,
@new bit
AS
INSERT INTO ITEM (channel_id, pubDate, author, title, active, new)
VALUES (@channelId, @pubDate, @author, @author, @active, @new)
DECLARE @item_id smallint;
SELECT @item_id = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;
UPDATE item
SET link = 'http://www.rpcwc.org/members/weeklyprayer.aspx?item_id=' + CAST(item_id AS varchar(3))
WHERE item_id = @item_id;
INSERT INTO ITEM_DESCRIPTION
(item_id, DESCRIPTION)
VALUES (@item_id, @description)