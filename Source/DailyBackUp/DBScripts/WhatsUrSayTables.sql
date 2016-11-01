--Creating the DSE Database for the project
Create Database DSE

--Creating tables and Stored Procedures.
USE [DSE]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[id] [int] NOT NULL,
	[heading] [ntext] NOT NULL,
	[description] [ntext] NULL,
	[type] [ntext] NOT NULL,
	[category] [ntext] NOT NULL,
	[group_ids] [ntext] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[Answer](
	[id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[activity_id] [int] NOT NULL,
	[count] [int] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Group](
	[id] [int] NOT NULL,
	[name] [ntext] NOT NULL,
	[user_ids] [ntext] NULL,
	[created_by] [ntext] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[Question](
	[id] [int] NOT NULL,
	[description] [ntext] NOT NULL,
	[activity_id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[name] [ntext] NOT NULL,
	[role] [ntext] NOT NULL,
	[emailId] [ntext] NOT NULL,
	[pwd] [ntext] NOT NULL,
	[status] [ntext] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[User_Group](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[group_ids] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


