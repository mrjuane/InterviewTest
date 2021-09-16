USE [Inventory]
GO

/****** Object:  Table [Instances].[Products]    Script Date: 9/15/2021 9:13:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Instances].[Products](
	[InstanceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[ProductImageUris] [varchar](max) NOT NULL,
	[ValidSkus] [varchar](max) NOT NULL,
	[CreatedTimestamp] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Instances].[Products] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedTimestamp]
GO


