CREATE TABLE [dbo].[Copy] (
    [copyid] INT IDENTITY (1, 1) NOT NULL,
    [isbn]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([copyid] ASC),
    FOREIGN KEY ([isbn]) REFERENCES [dbo].[Book] ([isbn])
);

