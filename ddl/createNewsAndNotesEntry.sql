
CREATE  PROCEDURE createNewsAndNotesEntry
@channelId tinyint,
@title varchar(500),
@author varchar(100),
@active bit,
@description text
AS
INSERT INTO ITEM
(
	CHANNEL_ID,
	TITLE,
	AUTHOR,
	PUBDATE,
	ACTIVE
)
VALUES
(
	@channelId,
	@title,
	@author,
	GETDATE(),
	@active	
);

DECLARE @itemId smallint;

SELECT @itemId = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;

INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@itemId, @description);



