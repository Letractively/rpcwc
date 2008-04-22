
DROP TABLE channel;

CREATE TABLE channel
(
channel_id tinyint PRIMARY KEY, --pk
title varchar(2000) NOT NULL,
link varchar(2000) NOT NULL,
description text NOT NULL,
language varchar(5) default 'en-us',
copyright varchar (2000),
webMaster varchar (2000),
pubDate smalldatetime,
lastBuildDate smalldatetime
);

DROP TABLE ITEM;

CREATE TABLE item
(
channel_id tinyint REFERENCES channel(channel_id),
item_id smallint IDENTITY (1,1)PRIMARY KEY CLUSTERED ,
title varchar(2000) NOT NULL,
link varchar(2000),
author varchar(2000) NOT NULL,
comments varchar(2000),
pubDate smalldatetime NOT NULL,
source_url varchar(2000),
last_upd_tms timestamp
);

DROP TABLE ITEM_DESCRIPTION;

CREATE TABLE item_description
(
item_id smallint REFERENCES ITEM(item_id),
description text
);

DROP TABLE item_enclosure;

CREATE TABLE item_enclosure
(
item_id smallint REFERENCES ITEM(item_id),
enclosure_id smallint IDENTITY (1,1)PRIMARY KEY CLUSTERED,
url varchar(2000) NOT NULL,
size int,
type varchar(30) NOT NULL
);

DROP TABLE category;

CREATE TABLE category
(
category_id tinyint PRIMARY KEY,
category varchar(2000)
);

DROP TABLE item_category;

CREATE TABLE item_category
(
item_id smallint REFERENCES ITEM(item_id),
category_id tinyint REFERENCES CATEGORY(category_id)
);

DROP TABLE sermon_text_reference;

CREATE TABLE sermon_text_reference
(
item_id smallint REFERENCES ITEM(item_id),
text_reference varchar (2000)
);

DROP TABLE channel_category;

CREATE TABLE channel_category
(
channel_id tinyint REFERENCES CHANNEL(channel_id),
category_id tinyint REFERENCES CATEGORY(category_id)
);

CREATE TABLE item_comment
(
item_id smallint REFERENCES item(item_id),
comment_id smallint PRIMARY KEY REFERENCES ITEM(item_id)
)

CREATE TABLE ITEM_ALERT (
ITEM_ID  smallint NOT NULL REFERENCES ITEM(item_id),
alert bit NOT NULL ,
active_ind bit NOT NULL ,
)

CREATE TABLE DIRECTORY (
ENTRY_ID TINYINT PRIMARY KEY IDENTITY(1,1),
LAST_NAME VARCHAR(100),
DIR_DISP_NAME VARCHAR(200),
ANNIV_NAME VARCHAR(100),
ANNIV_DATE SMALLDATETIME,
ADDRESS_1 VARCHAR(300),
ADDRESS_2 VARCHAR(300),
CITY VARCHAR(100),
STATE VARCHAR(2),
ZIP VARCHAR(10))

CREATE TABLE PERSON_ENTRY (
PERSON_ENTRY_ID SMALLINT PRIMARY KEY IDENTITY(1,1),
ENTRY_ID TINYINT REFERENCES DIRECTORY(ENTRY_ID),
FIRST_NAME VARCHAR(50),
LAST_NAME VARCHAR(50),
BIRTH_DATE SMALLDATETIME
)

CREATE TABLE PHONE (
ENTRY_ID TINYINT REFERENCES DIRECTORY(ENTRY_ID),
PERSON_ENTRY_ID SMALLINT REFERENCES PERSON_ENTRY(PERSON_ENTRY_ID),
PHONE VARCHAR(14),
PHONE_TYPE VARCHAR(50))

CREATE TABLE EMAIL (
ENTRY_ID TINYINT REFERENCES DIRECTORY(ENTRY_ID),
PERSON_ENTRY_ID SMALLINT REFERENCES PERSON_ENTRY(PERSON_ENTRY_ID),
EMAIL VARCHAR(100),
EMAIL_TYPE VARCHAR(50)
)


ALTER PROCEDURE getSermonBlog AS
SELECT     i.item_id id, i.title, i.author, i.link, i.pubDate, id.description, text_reference + ' — ' sermonTextReference, COALESCE (ic_1.comment_count, 0) AS commentCount
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                          (SELECT     item_id, COUNT(*) AS comment_count
                            FROM          item_comment AS ic
                            GROUP BY item_id) AS ic_1 ON ic_1.item_id = i.item_id
LEFT OUTER JOIN sermon_text_reference  str
ON str.item_id = i.item_id
WHERE     (i.channel_id = 1)
ORDER BY i.pubDate DESC

ALTER PROCEDURE getSermonBlogPKWhere
@item_id smallint,
AS
SELECT     i.item_id id, i.title, i.author, i.link, i.pubDate, id.description, text_reference + ' — ' sermonTextReference, COALESCE (ic_1.comment_count, 0) AS commentCount
FROM         item AS i LEFT OUTER JOIN
                      item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN
                          (SELECT     item_id, COUNT(*) AS comment_count
                            FROM          item_comment AS ic
                            GROUP BY item_id) AS ic_1 ON ic_1.item_id = i.item_id
LEFT OUTER JOIN sermon_text_reference  str
ON str.item_id = i.item_id
WHERE     (i.channel_id = 1)
AND
	i.item_id = @item_id
ORDER BY i.pubDate DESC




CREATE PROCEDURE getSermonBlogForMaintenance AS SELECT i.item_id id, i.title title, i.author author, i.pubDate pubDate, id.description description, i.link link, STR.text_reference sermonTextReference FROM item AS i LEFT OUTER JOIN item_description AS id ON i.item_id = id.item_id LEFT OUTER JOIN sermon_text_reference AS STR ON i.item_id = STR.item_id WHERE (i.channel_id = 1) ORDER BY pubDate DESC

CREATE PROCEDURE insertSermonBlog
@title varchar(2000),
@pubDate smalldatetime,
@description TEXT,
 @sermonText varchar(2000)
AS
 INSERT INTO ITEM (CHANNEL_ID, TITLE, AUTHOR, PUBDATE, LAST_UPD_TMS) VALUES (1, @title, 'Dr. Stanley D. Gale', @pubDate, CONVERT( TIMESTAMP, GETDATE())); DECLARE @id smallint;
SELECT @id = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = 1;
INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@id, @description); INSERT INTO SERMON_TEXT_REFERENCE (ITEM_ID, text_reference) values(@id, @sermonText);
INSERT INTO ITEM_ENCLOSURE
(ITEM_ID, URL, SIZE, TYPE)
VALUES (@itemid, @link, @size, @type)

ALTER PROCEDURE updateSermonBlog
@id smallint,
@title varchar(2000),
@pubDate smalldatetime,
@description TEXT,
 @sermonTextReference varchar(2000)
AS
IF (SELECT COUNT(*) FROM ITEM_DESCRIPTION WHERE ITEM_ID = @id) = 0
BEGIN
INSERT INTO ITEM_ENCLOSURE
(ITEM_ID, URL, SIZE, TYPE)
VALUES (@itemid, @link, @size, @type)
END
IF (SELECT COUNT(*) FROM ITEM_DESCRIPTION WHERE ITEM_ID = @id) > 0
BEGIN
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate
WHERE item_id = @id;
UPDATE item_description
set description = @description
where item_id = @id;
update sermon_text_reference
set text_reference = @sermonTextReference
where item_id = @id;
END
ELSE
BEGIN
INSERT INTO ITEM_DESCRIPTION (ITEM_ID, DESCRIPTION) VALUES (@id, @description);
END

ALTER PROCEDURE getSermonBlogComments
@id smallint
AS
SELECT     comment.item_id, comment.title, comment.author, comment.pubDate, item_description.description
FROM         item INNER JOIN
                      item_comment ON item.item_id = item_comment.item_id INNER JOIN
                      item AS comment ON item_comment.comment_id = comment.item_id INNER JOIN
                      item_description ON comment.item_id = item_description.item_id
WHERE     (item.channel_id = 1)
AND item.item_id = @id
ORDER BY comment.pubDate DESC

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

ALTER PROCEDURE deleteSermonBlogComment
@item_id smallint
AS
DELETE FROM ITEM_DESCRIPTION WHERE ITEM_ID = @item_id;
DELETE FROM ITEM_COMMENT WHERE COMMENT_ID = @item_id;
DELETE FROM ITEM_DESCRIPTION WHERE ITEM_ID = @item_id;

ALTER PROCEDURE getSermonBlogAndComments
@item_id smallint
AS
SELECT
i.item_id id,
i.title,
i.author,
i.link,
i.pubDate,
id.description,
text_reference + ' — ' sermonTextReference,
NULL commentTitle,
NULL commentAuthor,
NULL commentPubDate,
NULL comment
FROM    item AS i LEFT OUTER JOIN
	item_description AS id ON i.item_id = id.item_id
LEFT OUTER JOIN
	sermon_text_reference AS str ON str.item_id = i.item_id
WHERE
AND i.item_id = @item_id
ORDER BY i.pubDate DESC
UNION
SELECT
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
i.title commentTitle,
i.author commentAuthor,
i.pubDate commentPubDate,
id.description comment
FROM item_comment
INNER JOIN item ON item.item_id = item_comment.comment_id
INNER JOIN item_description ON item_description.item_id = item.item_id
WHERE item_comment.item_id = @item_id












ALTER PROCEDURE getSermonBlogAndComments
@item_id smallint
AS
SELECT
i.item_id id,
i.title,
i.author,
i.link,
i.pubDate,
id.description,
text_reference + ' — ' sermonTextReference,
NULL commentTitle,
NULL commentAuthor,
NULL commentPubDate,
NULL comment
FROM    item AS i LEFT OUTER JOIN
	item_description AS id ON i.item_id = id.item_id
LEFT OUTER JOIN
	sermon_text_reference AS str ON str.item_id = i.item_id
WHERE
i.item_id = @item_id
UNION ALL
SELECT
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
i.title commentTitle,
i.author commentAuthor,
i.pubDate commentPubDate,
id.description comment
FROM item_comment ic
INNER JOIN item i ON i.item_id = ic.comment_id
INNER JOIN item_description id ON id.item_id = item.item_id
WHERE ic.item_id = @item_id


ALTER PROCEDURE getSermonBlogPKWhere
@item_id smallint
AS
SELECT
i.item_id id,
i.title,
i.author,
i.link,
i.pubDate,
id.description,
text_reference + ' — ' sermonTextReference
FROM    item AS i LEFT OUTER JOIN
	item_description AS id ON i.item_id = id.item_id
LEFT OUTER JOIN
	sermon_text_reference AS str ON str.item_id = i.item_id
WHERE
i.item_id = @item_id

ALTER PROCEDURE getSermonBlogCommentsPKWhere
@item_id smallint
AS
SELECT
i.item_id item_id,
i.title title,
i.author author,
i.pubDate pubDate,
id.description comment
FROM item_comment ic
INNER JOIN item i ON i.item_id = ic.comment_id
INNER JOIN item_description id ON id.item_id = i.item_id
WHERE ic.item_id = @item_id








ALTER PROCEDURE insertSermonAudio
@title varchar(2000),
@author varchar(2000),
@reference varchar(2000),
@link varchar(2000),
@size int,
@type varchar(30),
@date smalldatetime

AS

INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, LINK, PUBDATE) VALUES (4, @title, @author, @link, @date)

DECLARE @itemid smallint;

SELECT @itemid = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = 1;

INSERT INTO SERMON_TEXT_REFERENCE
(ITEM_ID, TEXT_REFERENCE) VALUES (@itemid, @reference)

INSERT INTO ITEM_ENCLOSURE
(ITEM_ID, URL, SIZE, TYPE)
VALUES (@itemid, @link, @size, @type)



ALTER PROCEDURE getSermonAudioList as
SELECT     item.item_id id, item.title, item_enclosure.url, item_enclosure.size, item_enclosure.type, item.author, item.pubDate, sermon_text_reference.text_reference AS sermonTextReference
FROM         item LEFT OUTER JOIN
                      sermon_text_reference ON item.item_id = sermon_text_reference.item_id
		      LEFT OUTER JOIN item_enclosure on item.item_id = item_enclosure.item_id
WHERE     (item.channel_id = 1)



CREATE PROCEDURE findEventsByDateRange
@channelId tinyint,
@startDate smalldatetime,
@endDate smalldatetime
AS
SELECT     i.item_id, i.pubDate, i.title, id.description, i.author
FROM         item AS i INNER JOIN
                      item_description AS id ON i.item_id = id.item_id
WHERE     (i.channel_id = @channelId) AND (i.pubDate BETWEEN @startDate AND @endDate)

CREATE PROCEDURE findEventsFuture
@channelId tinyint
AS
SELECT     i.item_id, i.pubDate, i.title, id.description, i.author
FROM         item AS i INNER JOIN
                      item_description AS id ON i.item_id = id.item_id
WHERE     (i.channel_id = @channelId) AND (i.pubDate >= GETDATE())



CREATE VIEW SERMON_AUDIO AS
SELECT     item.item_id id, item.title, item_enclosure.url, item_enclosure.size, item_enclosure.type, item.author, item.pubDate, sermon_text_reference.text_reference AS sermonTextReference
FROM         item LEFT OUTER JOIN
                      sermon_text_reference ON item.item_id = sermon_text_reference.item_id
		      LEFT OUTER JOIN item_enclosURe on item.item_id = item_enclosure.item_id
WHERE     (item.channel_id = 4)


CREATE PROCEDURE getMarquee
@channelId tinyint
AS
SELECT     item_description.description, ITEM_ALERT.alert
FROM         item INNER JOIN
                      item_description ON item.item_id = item_description.item_id INNER JOIN
                      ITEM_ALERT ON item.item_id = ITEM_ALERT.ITEM_ID
WHERE     (item.channel_id = @channelId) AND (ITEM_ALERT.active_ind = 1)



ALTER PROCEDURE createEvent
@channelId tinyint,
@title varchar(2000),
@pubDate smalldatetime,
@description text
AS
INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE) VALUES (@channelId, @title, '', @pubDate)

DECLARE @itemid smallint;

SELECT @itemid = MAX(ITEM_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;

INSERT INTO ITEM_DESCRIPTION
(ITEM_ID, DESCRIPTION) VALUES (@itemid, @description)


ALTER PROCEDURE updateEvent
@item_id smallint,
@title varchar(2000),
@pubDate smalldatetime,
@description text
AS
UPDATE ITEM
SET TITLE = @title,
pubDate = @pubDate
WHERE ITEM_ID = @item_id

UPDATE ITEM_DESCRIPTION
SET DESCRIPTION = @description
WHERE ITEM_ID = @item_id

CREATE PROCEDURE deleteEvent
@item_id SMALLINT
AS
DELETE FROM ITEM_DESCRIPTION WHERE ITEM_ID = @item_id

DELETE FROM ITEM WHERE ITEM_ID = @item_id

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

ALTER PROCEDURE createPrayerRequest
@channelId tinyint,
@pubDate smalldatetime,
@author varchar(2000),
@description text,
@active bit,
@new bit
AS
INSERT INTO ITEM (channel_id, pubDate, author, title, active, new)
VALUES (@channelId, @pubDate, @author, ' ', @active, @new)
DECLARE @item_id smallint;
SELECT @item_id = MAX(item_ID) FROM ITEM WHERE CHANNEL_ID = @channelId;
INSERT INTO ITEM_DESCRIPTION
(item_id, DESCRIPTION)
VALUES (@item_id, @description)