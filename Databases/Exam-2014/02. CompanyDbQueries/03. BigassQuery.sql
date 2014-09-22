SELECT e.FirstName + ' ' + e.LastName AS [FullName], p.Name AS [ProjectName], 
d.Name AS [DepartmentName], ep.StartDate, ep.EndDate,
	(SELECT COUNT(*)
	 FROM Reports r
	 GROUP BY r.EmployeeID
	 HAVING r.EmployeeID = e.EmployeeID)
FROM Employees e
	JOIN Departments d
		ON e.EmployeeID = d.DepartmentID
	JOIN EmployeesProjects ep
		ON e.EmployeeID = ep.EmployeeID
	JOIN Projects p
		ON ep.ProjectID = p.ProjectID
GROUP BY e.EmployeeID, e.FirstName, e.LastNAme, p.Name, d.Name, ep.StartDate, ep.EndDate, p.ProjectID
ORDER BY e.EmployeeID, p.ProjectID