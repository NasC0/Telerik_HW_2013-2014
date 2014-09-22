CREATE VIEW UsersLoggedToday AS
SELECT *
FROM Users
WHERE CONVERT(date, Users.LastLogin) = CONVERT(date, GETDATE())