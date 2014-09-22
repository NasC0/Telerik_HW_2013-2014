ALTER TABLE Users
ADD GroupID int
GO

INSERT INTO Groups
	VALUES
	('Users'),
	('Admins'),
	('Moderators')
GO

INSERT INTO Users
(Username, Password, FullName, LastLogin, GroupID)
	VALUES
	('Pesho', 'Mishev', 'Pesho Mishev', GETDATE(), 1),
	('Misho', 'Peshev', 'Misho Peshev', GETDATE(), 2),
	('Tisho', 'Wadsad', 'Tisho Mishev', '2014-08-15', 3),
	('Hwkajh', 'Llkjsdf', 'Hwkajh Llkjsdf', '2014-08-22', 1),
	('Wadsf', 'Ljlkjsdf', 'Wadsf Ljlkjsdf', '2014-08-11', 1),
	('Khkjhwa', 'Sdasd', 'Khkjhwa Sdasd', '2014-08-01', 2)
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups_GroupID FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
GO