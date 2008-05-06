CREATE PROCEDURE findRedirect
@oldPage varchar(100)
 AS
SELECT new_page newPage from page_redirect where old_page = @oldPage