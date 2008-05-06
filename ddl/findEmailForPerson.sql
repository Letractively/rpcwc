CREATE PROCEDURE
findEmailForPerson
@personEntryId smallint
AS
SELECT     EMAIL, EMAIL_TYPE, ENTRY_ID
FROM         EMAIL
WHERE     (PERSON_ENTRY_ID = @personEntryId)