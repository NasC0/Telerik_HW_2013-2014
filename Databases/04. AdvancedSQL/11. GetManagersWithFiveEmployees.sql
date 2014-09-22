SELECT m.EmployeeID, m.FirstName, m.LastName
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5