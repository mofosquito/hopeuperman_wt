CREATE TABLE [dbo].[mapMarkers]
(
	[markerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [longitude] FLOAT NOT NULL, 
    [latitude] FLOAT NOT NULL, 
    [locationName] VARCHAR(MAX) NULL, 
    [mainLangauge] VARCHAR(MAX) NULL, 
    [dialect] VARCHAR(MAX) NULL, 
    [audioFile] VARCHAR(MAX) NULL, 
    [translation] VARCHAR(MAX) NULL,
    [tag] VARCHAR(MAX) NULL, 
    [addedbyAdmin] INT NULL, 
    
    CONSTRAINT [FK_mapMarkers_ToadminData] FOREIGN KEY ([addedbyAdmin]) REFERENCES [adminData]([adminId])
)

GO

CREATE INDEX [IX_mapMarkers_adminId] ON [dbo].[mapMarkers] ([addedbyAdmin])
