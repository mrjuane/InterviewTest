USE [Inventory]
GO

/****** Object:  Table [Instances].[CategoryAttributes]    Script Date: 9/15/2021 9:13:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Instances].[CategoryAttributes](
	[InstanceId] [int] NOT NULL,
	[Key] [varchar](64) NOT NULL,
	[Value] [varchar](512) NOT NULL,
 CONSTRAINT [PK_CategoryAttributes] PRIMARY KEY CLUSTERED 
(
	[InstanceId] ASC,
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Instances].[CategoryAttributes]  WITH CHECK ADD  CONSTRAINT [FK_CategoryAttributes_Categories] FOREIGN KEY([InstanceId])
REFERENCES [Instances].[Categories] ([InstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [Instances].[CategoryAttributes] CHECK CONSTRAINT [FK_CategoryAttributes_Categories]
GO


