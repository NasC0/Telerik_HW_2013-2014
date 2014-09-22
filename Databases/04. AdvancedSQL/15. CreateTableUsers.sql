CREATE TABLE Users(
	UserID int IDENTITY PRIMARY KEY,
	Username varchar(50) NOT NULL UNIQUE,
	Password varchar(50),
	FullName varchar(100) NOT NULL,
	LastLogin datetime,
	CHECK (LEN(Password) >= 5)
)