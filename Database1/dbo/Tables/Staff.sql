CREATE TABLE [dbo].[Staff] (
    [ssn]  INT           NOT NULL,
    [role] NVARCHAR (50) NULL,
    FOREIGN KEY ([ssn]) REFERENCES [dbo].[Person] ([ssn]),
    UNIQUE NONCLUSTERED ([ssn] ASC)
);

