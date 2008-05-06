CREATE PROCEDURE insertSermonAudio
@title varchar(2000),
@author varchar(2000),
@reference varchar(2000),
@link varchar(2000),
@size int,
@type varchar(30),
@date smalldatetime

AS

INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, LINK, PUBDATE) VALUES (1, @title, @author, @link, @date)

DECLARE @itemid smallint;

SELECT @itemid = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = 1;

INSERT INTO SERMON_TEXT_REFERENCE
(ITEM_ID, TEXT_REFERENCE) VALUES (@itemid, @reference)

INSERT INTO ITEM_ENCLOSURE
(ITEM_ID, URL, SIZE, TYPE)
VALUES (@itemid, @link, @size, @type)