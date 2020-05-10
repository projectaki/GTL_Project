CREATE TABLE [dbo].[Finished_Loans] (
    [isbn]           INT NOT NULL,
    [loan_time_days] INT NOT NULL,
    FOREIGN KEY ([isbn]) REFERENCES [dbo].[Book] ([isbn])
);

