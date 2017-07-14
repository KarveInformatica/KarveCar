CREATE PROCEDURE dbo.[ps_SelectAccountWithOutPutParam]
@Account_ID  [int],
@OutPut [int] OUTPUT 
AS
select
	Account_ID as Id,
	Account_FirstName as FirstName,
	Account_LastName as LastName,
	Account_Email as EmailAddress
from Accounts
where Account_ID = @Account_ID

SELECT @OutPut = 987