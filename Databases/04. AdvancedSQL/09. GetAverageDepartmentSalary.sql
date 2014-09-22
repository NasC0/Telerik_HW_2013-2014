SELECT d.Name, d.DepartmentID, AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d 
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name