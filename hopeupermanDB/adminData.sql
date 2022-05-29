CREATE TABLE [dbo].[adminData]
(
	[adminId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [adminUsername] VARCHAR(50) NULL, 
    [adminPassword] VARCHAR(50) NULL, 
    [adminEmail] VARCHAR(50) NULL
)
