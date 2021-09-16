USE [Inventory]
GO

/****** Object:  Table [Instances].[ProductAttributes]    Script Date: 9/15/2021 9:13:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Instances].[ProductAttributes](
	[InstanceId] [int] NOT NULL,
	[Key] [varchar](64) NOT NULL,
	[Value] [varchar](512) NOT NULL,
 CONSTRAINT [PK_ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[InstanceId] ASC,
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Instances].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Products] FOREIGN KEY([InstanceId])
REFERENCES [Instances].[Products] ([InstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [Instances].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Products]
GO


