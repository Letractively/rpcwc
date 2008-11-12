CREATE PROCEDURE findChannel
@channelId tinyint
AS
SELECT     title, link, description, language, copyright, pubDate
FROM         channel
WHERE     (channel_id = @channelId)