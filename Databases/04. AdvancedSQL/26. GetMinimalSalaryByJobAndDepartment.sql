SELECT MIN(e.Salary) AS [Salary], MIN(e.FirstName + ' ' + e.LastName) AS [Employee Name],
	e.JobTitle, d.Name
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
ORDER BY MIN(e.Salary)