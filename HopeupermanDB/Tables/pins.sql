CREATE TABLE [dbo].[Marker]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [long] FLOAT NULL, 
    [lat] FLOAT NULL, 
    [title] VARCHAR(50) NULL, 
    [audiofile] UNIQUEIDENTIFIER NULL, 
    [content] VARCHAR(MAX) NULL, 
)
