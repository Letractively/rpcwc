CREATE PROCEDURE updateAlert
@item_id smallint,
@author varchar(2000),
@pubDate smalldatetime,
@description text,
@alert bit,
@active bit
AS
UPDATE item
SET
author = @author,
pubDate = @pubDate,
active = @active
WHERE item_id = @item_id
UPDATE item_alert
SET 
alert = @alert
WHERE item_id = @item_id
UPDATE item_description
SET description = @description
WHERE item_id = @item_id