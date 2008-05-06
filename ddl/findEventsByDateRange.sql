CREATE PROCEDURE findEventsByDateRange
@channelId tinyint,
@startDate smalldatetime,
@endDate smalldatetime
AS
SELECT     i.item_id, i.pubDate, i.title, id.description, i.author
FROM         item AS i INNER JOIN
                      item_description AS id ON i.item_id = id.item_id
WHERE     (i.channel_id = @channelId) AND (i.pubDate BETWEEN @startDate AND @endDate)