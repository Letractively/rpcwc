CREATE PROCEDURE createRecommendedReading
@channelId tinyint,
@title varchar(2000),
@link varchar(2000),
@author varchar(2000),
@imageUrl VARCHAR(2000)
AS
INSERT INTO ITEM (
	CHANNEL_ID,
	TITLE,
	LINK,
	AUTHOR,
	PUBDATE,
	ACTIVE
) VALUES (
	@channelId,
	@title,
	@link,
	@author,
	GETDATE(),
	1
)

DECLARE @itemId SMALLINT;

SELECT @itemId = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;

INSERT INTO
	ITEM_ENCLOSURE
(
	ITEM_ID,
	URL,
	TYPE
)
VALUES
(
	@itemId,
	@imageUrl,
	'image/jpeg'
)
