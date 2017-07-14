CREATE PROCEDURE dbo.[ps_SelectAccountViaOuputParam]
@Account_ID  [int] OUTPUT,
@Account_FirstName varchar(32) OUTPUT, 
@Account_LastName  varchar(32) OUTPUT, 
@Account_Email  varchar(128) OUTPUT 
AS
select
	@Account_ID = Account_ID,
	@Account_FirstName = Account_FirstName,
	@Account_LastName = Account_LastName,
	@Account_Email = Account_Email
from Accounts
where Account_ID = @Account_ID