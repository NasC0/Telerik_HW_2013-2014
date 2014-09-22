USE BankSystemDB
GO

CREATE PROCEDURE usp_AddMonthlyInterest(
	@accountID int, @interestRate real)
AS
BEGIN
	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateInterest(Balance, @interestRate, 1)
	WHERE AccountID = @accountID
END
GO 