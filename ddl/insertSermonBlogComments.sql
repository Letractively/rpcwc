CREATE PROCEDURE insertSermonBlogComments
@id smallint,
@title varchar(2000),
@author varchar(2000),
@comment text

AS

INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE) VALUES (2, @title, @author, GETDATE())

DECLARE @commentId smallint;

SELECT @commentId = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = 2;

INSERT INTO ITEM_COMMENT
(ITEM_ID, COMMENT_ID) VALUES (@id, @commentId)

INSERT INTO ITEM_DESCRIPTION
(ITEM_ID, description) VALUES (@commentId, @comment)