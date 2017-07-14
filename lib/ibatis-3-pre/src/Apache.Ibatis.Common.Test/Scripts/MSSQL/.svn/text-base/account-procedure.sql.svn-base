CREATE PROCEDURE dbo.[sp_InsertAccount]
@Account_ID  [int], 
@Account_FirstName [nvarchar] (40),
@Account_LastName [varchar] (32),
@Account_Email [varchar] (128)
AS
insert into Accounts  
			(Account_ID, Account_FirstName, Account_LastName, Account_Email) 
values 
			(@Account_ID, @Account_FirstName, @Account_LastName, @Account_Email)

