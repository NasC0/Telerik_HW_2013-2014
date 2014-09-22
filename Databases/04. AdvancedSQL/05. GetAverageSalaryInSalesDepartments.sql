SELECT AVG(e.Salary) AS [Average Salary]
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT DepartmentID FROM Departments
	 WHERE Name = 'Sales')