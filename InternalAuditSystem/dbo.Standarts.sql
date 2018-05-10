CREATE TABLE [dbo].[Standarts] (
    [StandartId]          NCHAR(15) NOT NULL,
    [StandartName]        NCHAR (30)      NOT NULL,
    [StandartDescription] NVARCHAR (100)  NOT NULL,
    [StandartFile]        VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Standarts] PRIMARY KEY CLUSTERED ([StandartId] ASC)
);

