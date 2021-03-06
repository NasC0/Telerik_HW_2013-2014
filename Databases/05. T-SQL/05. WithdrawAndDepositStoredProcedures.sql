USE BankSystemDB
GO

CREATE PROCEDURE usp_WithdrawMoney(
	@accountID int, @money money)
AS
BEGIN
	BEGIN TRANSACTION WithdrawMoney
	DECLARE @accountBalance money;

	SELECT @accountBalance = Balance
	FROM Accounts
	WHERE AccountID = @accountID

	IF (@accountBalance >= @money)
	BEGIN
		UPDATE Accounts
		SET Balance = Balance - @money
		WHERE AccountID = @accountID
	END
	COMMIT TRANSACTION WithdrawMoney
END
GO

CREATE PROCEDURE usp_DepositMoney(
	@accountID int, @money money)
AS
BEGIN
	BEGIN TRANSACTION DepositMoney
	
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE AccountID = @accountID

	COMMIT TRANSACTION DepositMoney
END
GO