CREATE TABLE [dbo].[Member] (
    [ssn]          INT           NOT NULL,
    [campus]       NVARCHAR (50) NULL,
    [sign_up_date] DATETIME      NOT NULL,
    [member_type]  NVARCHAR (50) NOT NULL,
    FOREIGN KEY ([ssn]) REFERENCES [dbo].[Person] ([ssn]),
    UNIQUE NONCLUSTERED ([ssn] ASC)
);

