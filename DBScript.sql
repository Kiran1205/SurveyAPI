use master
go
drop database SurveyDB
go
create database  SurveyDB
go
use SurveyDB
go
CREATE TABLE [dbo].[AnswerSubmissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OptionDetail] [nvarchar](max) NULL,
	[SelectedValue] [nvarchar](max) NULL,
	[AnonymouseUserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AnonymousUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyID] int not null,
	[CreatedOn] Datetime not null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionOptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OptionDetail] [nvarchar](max) NULL,
	[QuestionId] [int]  NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 12-10-2019 15:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ques] [nvarchar](max) NULL,
	[SurveyId] [int] NOT NULL,
	[QuestionType] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 12-10-2019 15:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[Id] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 12-10-2019 15:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyName] [nvarchar](50) NULL,
	[SurveyDesc] [nvarchar](max) NULL,	
	[OwnerId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ExpDate] datetime null,
	[SurveyGuid] UNIQUEIDENTIFIER  default NEWID(),
	[Deleted] bit null,
	[IsLive] bit null,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12-10-2019 15:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [binary](64) NOT NULL,
	[PasswordSalt] [binary](128) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK__Users__3214EC0753BE69BF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnswerSubmissions] ADD  CONSTRAINT [DF_AnswerSubmissions_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[QuestionOptions] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Questions] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[QuestionType] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Survey] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreatedOn__5535A963]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[AnswerSubmissions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswered_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[AnswerSubmissions] CHECK CONSTRAINT [FK_QuestionAnswered_Question]
GO
ALTER TABLE [dbo].[QuestionOptions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionOptions_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[QuestionOptions] CHECK CONSTRAINT [FK_QuestionOptions_Questions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Survey] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Survey]
GO
ALTER TABLE [dbo].[Survey]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Users] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Survey] CHECK CONSTRAINT [FK_Survey_Users]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getcountodisplay](@userid int)
as 
begin
	
	declare @opensurvey int,@closedsurvey int,@draft int,@totalresponse int
	select @opensurvey = count(0) from Survey where OwnerId = @userid and ExpDate >=getdate() and Deleted =0 and IsLive = 1
	select @closedsurvey= count(0) from Survey where OwnerId = @userid and ExpDate <getdate() and Deleted =0 and IsLive = 1
	select @draft= count(0) from Survey where OwnerId = @userid  and Deleted =0 and IsLive = 0
	select @totalresponse = count(0) from dbo.AnonymousUser u
	inner join dbo.Survey s on  s.Id = u.SurveyID and OwnerId = @userid  
	
	select @opensurvey as opensurvey, @closedsurvey as closedsurvey,@draft as draft,@totalresponse as totalresponse
	
	
end
go
