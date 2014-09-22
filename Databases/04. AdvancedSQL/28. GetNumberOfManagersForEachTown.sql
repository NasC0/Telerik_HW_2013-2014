SELECT COUNT(DISTINCT m.EmployeeID) AS [Managers Count], t.Name AS [Town Name]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON m.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name