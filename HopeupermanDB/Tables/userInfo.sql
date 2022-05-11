CREATE TABLE [dbo].[userInfo]
(
	[Id] INT NOT NULL , 
    [username] NCHAR(20) NOT NULL, 
    [password] NCHAR(64) NOT NULL, 
    PRIMARY KEY ([username])
)
