SELECT COUNT(*)
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT DepartmentID FROM Departments
	 WHERE Name = 'Sales')