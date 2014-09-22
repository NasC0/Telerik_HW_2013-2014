USE BankSystemDB
GO

CREATE PROCEDURE dbo.usp_SelectFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM People
END
GO
