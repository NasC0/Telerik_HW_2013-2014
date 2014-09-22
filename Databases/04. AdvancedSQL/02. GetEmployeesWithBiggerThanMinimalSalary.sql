SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary <= 
	(SELECT MIN(Salary) * 1.10 FROM Employees)
ORDER BY Salary