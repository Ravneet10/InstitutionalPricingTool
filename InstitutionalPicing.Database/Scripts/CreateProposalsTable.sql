
/****** Object:  Table [dbo].Proposals    Script Date: 8/04/2022 10:22:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Proposals(
	[Id] [uniqueidentifier] NOT NULL,
	[ProposalName] [varchar](max) NOT NULL,
	CustomerGrpName [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Status] [varchar](max) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Proposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].Proposals ADD  CONSTRAINT [DF_Proposals_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].Proposals ADD  CONSTRAINT [DF_Proposals_CreatedBy]  DEFAULT ('Test User') FOR [CreatedBy]
GO

ALTER TABLE [dbo].Proposals ADD  CONSTRAINT [DF_Proposals_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO

ALTER TABLE [dbo].Proposals ADD  CONSTRAINT [DF_Proposals_ModifiedBy]  DEFAULT ('Test User') FOR [ModifiedBy]
GO

ALTER TABLE [dbo].Proposals ADD  CONSTRAINT [DF_Proposals_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]


