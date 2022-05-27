CREATE TABLE [dbo].[mapMarkers]
(
	[markerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [longitude] FLOAT NOT NULL, 
    [latitude] FLOAT NOT NULL, 
    [mainLangauge] VARCHAR(50) NOT NULL, 
    [dialect] VARCHAR(50) NOT NULL, 
    [audioFile] UNIQUEIDENTIFIER NOT NULL, 
    [tag] NCHAR(10) NOT NULL, 
    [adminId] INT NOT NULL, 
    CONSTRAINT [FK_mapMarkers_ToTable] FOREIGN KEY ([adminId]) REFERENCES [adminData]([adminId])
)

GO

CREATE INDEX [IX_mapMarkers_adminId] ON [dbo].[mapMarkers] ([adminId])
