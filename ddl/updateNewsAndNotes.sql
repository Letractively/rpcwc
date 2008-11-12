CREATE PROCEDURE updateNewsAndNotes
@itemId smallint,
@active bit,
@description text
AS
UPDATE ITEM SET ACTIVE=@active WHERE item_id = @itemId;
UPDATE ITEM_DESCRIPTION SET DESCRIPTION=@description WHERE item_id = @itemId