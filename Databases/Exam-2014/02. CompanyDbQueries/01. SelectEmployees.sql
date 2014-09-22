USE [CompanyDb]
GO

SELECT FirstName + ' ' + LastName AS [FullName], Salary
FROM Employees
WHERE Salary BETWEEN 100000 AND 150000
ORDER BY Salary