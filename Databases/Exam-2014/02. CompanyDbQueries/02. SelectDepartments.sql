USE [CompanyDb]

SELECT d.Name, COUNT(e.EmployeeID)
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY (d.Name)