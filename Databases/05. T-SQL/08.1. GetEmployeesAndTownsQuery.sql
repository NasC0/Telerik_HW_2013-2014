SELECT e.FirstName + ' ' + e.LastName AS [First Employee], 
	n.FirstName + ' ' + n.LastName AS [Second Employee],
	t.Name
FROM Employees n, Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
WHERE (SELECT t.Name
       FROM Employees
		JOIN Addresses a
			ON Employees.AddressID = a.AddressID
		JOIN Towns t
			ON a.TownID = t.TownID
		WHERE Employees.EmployeeID = e.EmployeeID)
		=
		(SELECT t.Name
		 FROM Employees
			JOIN Addresses a
				ON Employees.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID
		 WHERE Employees.EmployeeID = n.EmployeeID)
AND e.EmployeeID != n.EmployeeID
ORDER BY [First Employee]