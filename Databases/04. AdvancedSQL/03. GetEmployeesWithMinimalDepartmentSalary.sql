SELECT FirstName + ' ' + LastName AS [Full Name], d.DepartmentID, d.Name, Salary
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees
	 WHERE DepartmentID = e.DepartmentID)