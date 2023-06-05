CREATE TABLE [dbo].[News] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [UrlToImage]  NVARCHAR (MAX) NULL,
    [PublishedAt] DATETIME       NULL,
    [Content]     VARCHAR (MAX)  NULL,
    [Author]      NVARCHAR (200) NULL,
    [SourceID]    NVARCHAR (MAX) NULL,
    [Category]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

