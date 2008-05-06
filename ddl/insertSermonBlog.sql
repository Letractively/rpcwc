
CREATE PROCEDURE insertSermonBlog
@channelId tinyint,
@author varchar(2000),
@title varchar(2000),
@pubDate smalldatetime,
@description TEXT,
@sermonTextReference varchar(2000),
@link varchar(2000),
@type varchar(30),
@size int
AS
 INSERT INTO ITEM (CHANNEL_ID, TITLE, AUTHOR, PUBDATE) VALUES (@channelId, @title, @author, @pubDate); DECLARE @id smallint;
SELECT @id = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;
INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@id, @description); INSERT INTO SERMON_TEXT_REFERENCE (ITEM_ID, text_reference) values(@id, @sermonTextReference);
INSERT INTO ITEM_ENCLOSURE
(ITEM_ID, URL, SIZE, TYPE)
VALUES (@id, @link, @size, @type)
