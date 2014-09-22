USE BankSystemDB
GO

CREATE PROCEDURE dbo.usp_CheckCurentBalance(
	@balanceToCheck money)
AS
BEGIN
	SELECT *
	FROM People p
		JOIN Accounts a
			ON a.PersonID = p.PersonID
	WHERE a.Balance >= @balanceToCheck
END
GO	