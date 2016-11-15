/*
Component :                             Database script that is used for creating our project's database and necessary tables
Author:                                 Sreedevi Koppula
Use of the component in system design:  Specifies the structure of the database that stores our project's data
Written and revised:                    11/9/2016
Reason for component existence:         To create project's database and necessary tables 
Component usage of data structures, algorithms and control(if any): 
    Contains the SQL queries for performing the below actions:
		Create Database - 'DSE' 
		Create tables - User, Group, User_Group, User_Request, Activity, Question, Answer
*/

/* Creating our project's database. Name of the database - DSE */
CREATE DATABASE [DSE]
GO 

/*Uses the database 'DSE' to perform the below SQL operations*/
USE [DSE]
GO

/* Object:  Table [dbo].[User] */
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[name] [ntext] NOT NULL,
	[role] [ntext] NULL,
	[emailId] [ntext] NOT NULL,
	[pwd] [ntext] NOT NULL,
	[status] [ntext] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


/* Object:  Table [dbo].[Group] */
CREATE TABLE [dbo].[Group](
	[id] [int] NOT NULL,
	[name] [ntext] NOT NULL,
	[user_ids] [ntext] NULL,
	[createdby] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_User] FOREIGN KEY([createdby])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_User]
GO


/* Object:  Table [dbo].[User_Group] */
CREATE TABLE [dbo].[User_Group](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[group_ids] [ntext] NULL,
 CONSTRAINT [PK_User_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_User]
GO



/* Object:  Table [dbo].[User_Request] */
CREATE TABLE [dbo].[User_Request](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[description] [ntext] NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_User_Request] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Request]  WITH CHECK ADD  CONSTRAINT [FK_User_Request_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Request] CHECK CONSTRAINT [FK_User_Request_User]
GO




/* Object:  Table [dbo].[Activity] */
CREATE TABLE [dbo].[Activity](
	[id] [int] NOT NULL,
	[heading] [ntext] NOT NULL,
	[description] [ntext] NULL,
	[type] [ntext] NOT NULL,
	[category] [ntext] NOT NULL,
	[group_ids] [ntext] NULL,
	[createdby] [int] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_User] FOREIGN KEY([createdby])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_User]
GO


/* Object:  Table [dbo].[Question] */
CREATE TABLE [dbo].[Question](
	[id] [int] NOT NULL,
	[description] [ntext] NOT NULL,
	[activity_id] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Activity]
GO

/* Object:  Table [dbo].[Answer] */
CREATE TABLE [dbo].[Answer](
	[id] [int] NOT NULL,
	[description] [ntext] NOT NULL,
	[question_id] [int] NOT NULL,
	[activity_id] [int] NOT NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Activity]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
