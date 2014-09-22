SELECT AVG(e.Salary), e.JobTitle, d.Name
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle