UPDATE Users
SET Password = NULL
WHERE CONVERT(date, LastLogin) <= '10.03.2010'