USE BankSystemDB
GO

CREATE TRIGGER trg_AfterUpdate ON Accounts 
	FOR UPDATE
AS
	DECLARE @accountID int,
			@oldSum money,
			@newSum money;

	SELECT @accountID = AccountID FROM deleted
	SELECT @oldSum = Balance FROM deleted
	SELECT @newSum = Balance FROM inserted

	INSERT INTO Logs
	(AccountID, OldSum, NewSum)
	VALUES(@accountID, @oldSum, @newSum)
GO


