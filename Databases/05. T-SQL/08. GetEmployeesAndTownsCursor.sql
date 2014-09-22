DECLARE empCursor CURSOR READ_ONLY FOR
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

OPEN empCursor
DECLARE @firstEmployee varchar(100),
		@secondEmployee varchar(100),
		@townName varchar(50);
FETCH NEXT FROM empCursor INTO @firstEmployee, @secondEmployee, @townName

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @firstEmployee + ' - ' + @secondEmployee + ' - ' + @townName
	FETCH NEXT FROM empCursor INTO @firstEmployee, @secondEmployee, @townName
END

CLOSE empCursor
DEALLOCATE empCursor
