USE [DSE]
GO

/****** Object:  Table [dbo].[User]    Script Date: 11/8/2016 11:30:51 PM ******/
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


CREATE TABLE [dbo].[User_Group](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[group_ids] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_User]
GO



CREATE TABLE [dbo].[User_Request](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[description] [ntext] NULL,
	[status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Request]  WITH CHECK ADD  CONSTRAINT [FK_User_Request_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Request] CHECK CONSTRAINT [FK_User_Request_User]
GO




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

CREATE TABLE [dbo].[Answer](
	[id] [int] NOT NULL,
	[description] [ntext] NOT NULL,
	[question_id] [int] NOT NULL,
	[activity_id] [int] NOT NULL,
	[count] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Activity]
GO


