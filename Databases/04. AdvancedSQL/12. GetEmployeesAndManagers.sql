SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
COALESCE(CONVERT(nvarchar(50), e.ManagerID), 'No Manager') AS [Manager]
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID
ORDER BY e.ManagerID