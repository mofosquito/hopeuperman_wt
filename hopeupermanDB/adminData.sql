CREATE TABLE [dbo].[adminData]
(
	[adminId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [adminUsername] VARCHAR(50) NOT NULL, 
    [adminPassword] VARCHAR(50) NOT NULL, 
    [adminEmail] VARCHAR(50) NOT NULL, 
    [addedDate] DATE NOT NULL
)
