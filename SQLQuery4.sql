
CREATE TABLE [dbo].[loans] (
    [id]           BIGINT   IDENTITY (1719, 1) NOT NULL,
    [created_at]   DATETIME DEFAULT (NULL) NULL,
    [updated_at]   DATETIME DEFAULT (NULL) NULL,
    [user_id]  BIGINT   NOT NULL,
    [document_id] BIGINT   NOT NULL,
    [duration_day] TINYINT NOT NULL
    CONSTRAINT [PK_loan_id] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [loans$loans_document_id_foreign] FOREIGN KEY ([document_id]) REFERENCES [dbo].[documents] ([id]),
    CONSTRAINT [loans$loans_user_id_foreign] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

CREATE TABLE [dbo].[users] (
    [id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (255) NOT NULL,
    [surname]   VARCHAR (255) NOT NULL,
    [email]     VARCHAR (200) NOT NULL,
    [telephone] VARCHAR (13)  NOT NULL,
    [password]  VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[documents] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [code]          VARCHAR (255) NOT NULL,
    [title]         VARCHAR (255) NOT NULL,
    [year]          INT           NOT NULL,
    [sector]        INT           NOT NULL,
    [available]     TINYINT       NOT NULL,
    [position]      VARCHAR (1)   NOT NULL,
    [author]        VARCHAR (1)   NOT NULL,
    [type]          VARCHAR (100) NOT NULL,
    [page_number]   INT           NULL,
    [duration_time] INT           NULL,
    [created_at]    DATETIME      DEFAULT (NULL) NULL,
    [updated_at]    DATETIME      DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
