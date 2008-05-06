CREATE PROCEDURE updatePrayerRequest
@item_id smallint,
@pubDate smalldatetime,
@author varchar(2000),
@description text,
@active bit,
@new bit
AS
UPDATE ITEM
SET pubDate = @pubDate,
author = @author,
active = @active,
new = @new
WHERE ITEM_ID = @item_id
UPDATE ITEM_DESCRIPTION
SET DESCRIPTION = @description
WHERE ITEM_ID = @item_id