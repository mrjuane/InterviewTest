USE [Inventory]
GO

/****** Object:  Table [Instances].[ProductCategories]    Script Date: 9/15/2021 9:13:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Instances].[ProductCategories](
	[InstanceId] [int] NOT NULL,
	[CategoryInstanceId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[InstanceId] ASC,
	[CategoryInstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Instances].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY([CategoryInstanceId])
REFERENCES [Instances].[Categories] ([InstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [Instances].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Categories]
GO

ALTER TABLE [Instances].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY([InstanceId])
REFERENCES [Instances].[Products] ([InstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [Instances].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Products]
GO


