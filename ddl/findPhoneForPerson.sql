CREATE PROCEDURE
findPhoneForPerson
@personEntryId smallint
AS
SELECT     PHONE, PHONE_TYPE, ENTRY_ID
FROM         PHONE
WHERE     (PERSON_ENTRY_ID = @personEntryId)