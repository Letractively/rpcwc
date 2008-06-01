CREATE PROCEDURE findBulletinsActive
@channelId tinyint
AS
SELECT     pubDate
FROM         item
WHERE     (channel_id = @channelId) AND (ACTIVE = 1)
ORDER BY pubDate DESC