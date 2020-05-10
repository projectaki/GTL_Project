CREATE TABLE [dbo].[Person] (
    [ssn]          INT           NOT NULL,
    [fname]        NVARCHAR (50) NOT NULL,
    [lname]        NVARCHAR (50) NOT NULL,
    [mail_address] NVARCHAR (50) NULL,
    [phone_nr]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ssn] ASC)
);

