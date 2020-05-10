CREATE TABLE [dbo].[Book] (
    [isbn]        INT            NOT NULL,
    [author]      NVARCHAR (50)  NOT NULL,
    [title]       NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [in_stock]    INT            NOT NULL,
    [lendable]    INT            NOT NULL,
    [edition]     NVARCHAR (50)  NULL,
    [cover_type]  NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([isbn] ASC)
);

