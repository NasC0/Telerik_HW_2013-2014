USE [TelerikAcademy]

DECLARE townCursor CURSOR READ_ONLY FOR
	SELECT TownID, Name
	FROM Towns
OPEN townCursor
DECLARE @townID int,
		@townName varchar(50);
FETCH NEXT FROM townCursor INTO @townID, @townName

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @emplList varchar(max);
	DECLARE emplCursor CURSOR READ_ONLY FOR
		SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
		FROM Employees e
			JOIN Addresses a
				ON e.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID
		WHERE t.TownID = @townID

	OPEN emplCursor
	DECLARE @employeeName varchar(100);
	FETCH NEXT FROM emplCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @emplList = CONCAT(@emplList + ', ', @employeeName)
		FETCH NEXT FROM emplCursor INTO @employeeName
	END

	PRINT @townName + ' -> ' + COALESCE(@emplList, '')
	SET @emplList = NULL

	CLOSE emplCursor
	DEALLOCATE emplCursor

	FETCH NEXT FROM townCursor INTO @townID, @townName
END

CLOSE townCursor
DEALLOCATE townCursor