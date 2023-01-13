CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Street] VARCHAR(128) NULL,
	[City] VARCHAR(128) NULL,
	[State] VARCHAR(128) NULL,
	[PostalCode] VARCHAR(64) NULL,
	[PersonId] INT NOT NULL,
	INDEX IX_Address_PersonId NONCLUSTERED ([PersonId]),
	FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])

)
