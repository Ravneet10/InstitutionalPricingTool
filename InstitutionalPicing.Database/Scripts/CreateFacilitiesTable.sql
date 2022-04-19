
/****** Object:  Table [dbo].Facilities    Script Date: 8/04/2022 10:22:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Facilities(
	[Id] [uniqueidentifier] NOT NULL,
	[ProposalId] [uniqueidentifier] NOT NULL,
	FacilityName [varchar](max) NOT NULL,
	BookingCountry [varchar](max) NOT NULL,
	Currency [varchar](max) NOT NULL,
	StartDate	[datetime] NOT NULL,
	MaturityDate [datetime] NOT NULL,
    Limit [decimal] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Facilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].Facilities ADD  CONSTRAINT [DF_Facilities_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].Facilities ADD  CONSTRAINT [DF_Facilities_CreatedBy]  DEFAULT ('Test User') FOR [CreatedBy]
GO

ALTER TABLE [dbo].Facilities ADD  CONSTRAINT [DF_Facilities_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO

ALTER TABLE [dbo].Facilities ADD  CONSTRAINT [DF_Facilities_ModifiedBy]  DEFAULT ('Test User') FOR [ModifiedBy]
GO

ALTER TABLE [dbo].Facilities ADD  CONSTRAINT [DF_Facilities_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Facilities]  WITH CHECK ADD  CONSTRAINT [FK_Facilities_Proposals] FOREIGN KEY([ProposalId])
REFERENCES [dbo].[Proposals] ([Id])
GO

ALTER TABLE [dbo].[Facilities] CHECK CONSTRAINT [FK_Facilities_Proposals]

