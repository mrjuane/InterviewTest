USE [Inventory]
GO

/****** Object:  Table [Instances].[CategoryCategories]    Script Date: 9/15/2021 9:13:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Instances].[CategoryCategories](
	[InstanceId] [int] NOT NULL,
	[CategoryInstanceId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryCategories] PRIMARY KEY CLUSTERED 
(
	[InstanceId] ASC,
	[CategoryInstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Instances].[CategoryCategories]  WITH CHECK ADD  CONSTRAINT [FK_CategoryCategories_Categories] FOREIGN KEY([InstanceId])
REFERENCES [Instances].[Categories] ([InstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [Instances].[CategoryCategories] CHECK CONSTRAINT [FK_CategoryCategories_Categories]
GO

ALTER TABLE [Instances].[CategoryCategories]  WITH CHECK ADD  CONSTRAINT [FK_CategoryCategories_Categories_Categories] FOREIGN KEY([CategoryInstanceId])
REFERENCES [Instances].[Categories] ([InstanceId])
GO

ALTER TABLE [Instances].[CategoryCategories] CHECK CONSTRAINT [FK_CategoryCategories_Categories_Categories]
GO


