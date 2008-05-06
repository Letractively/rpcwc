CREATE PROCEDURE createAlert
@channelId smallint,
@author varchar(2000),
@pubDate smalldatetime,
@description text,
@alert bit,
@active bit
AS
INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE, ACTIVE) VALUES (@channelId, '', @author, @pubDate, @active)
DECLARE @item_id smallint;
SELECT @item_id = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;
INSERT INTO ITEM_ALERT (ITEM_ID, ALERT) VALUES (@item_id, @alert)
INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@item_id, @description)
