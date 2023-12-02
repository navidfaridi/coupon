SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CouponHistory](
	[Id] [bigint] NOT NULL,
	[CouponCode] [varchar](10) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[ServiceOrgin] [varchar](50) NOT NULL,
	[Created] [datetime2] NOT NULL,
 CONSTRAINT [PK_CouponHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[CouponHistory]  WITH CHECK ADD  CONSTRAINT [FK_CouponHistory_CouponInfo] FOREIGN KEY([CouponCode])
REFERENCES [dbo].[CouponInfo] ([Code])
GO
ALTER TABLE [dbo].[CouponHistory] CHECK CONSTRAINT [FK_CouponHistory_CouponInfo]
GO
