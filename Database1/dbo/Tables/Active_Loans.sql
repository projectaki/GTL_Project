CREATE TABLE [dbo].[Active_Loans] (
    [loan_id]   INT      IDENTITY (1, 1) NOT NULL,
    [ssn]       INT      NOT NULL,
    [copyid]    INT      NOT NULL,
    [loan_date] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([loan_id] ASC),
    FOREIGN KEY ([copyid]) REFERENCES [dbo].[Copy] ([copyid]),
    FOREIGN KEY ([ssn]) REFERENCES [dbo].[Person] ([ssn]),
    UNIQUE NONCLUSTERED ([copyid] ASC)
);

