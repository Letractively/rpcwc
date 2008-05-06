CREATE PROCEDURE
findEmailForDir
@entryId smallint
AS
SELECT     EMAIL, EMAIL_TYPE, ENTRY_ID
FROM         EMAIL
WHERE     (PERSON_ENTRY_ID IS NULL)
AND ENTRY_ID = @entryId