USE [CardGameExample]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 24-3-2023 12:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerNumber] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [varchar](50) NOT NULL,
	[Wins] [int] NOT NULL,
	[Games] [int] NOT NULL,
	[PlayerType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Player] ON 
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (1, N'Piet', 0, 0, N'War.Model.Player')
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (2, N'Jan', 0, 0, N'War.Model.Player')
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (3, N'Klaas', 0, 0, N'War.Model.Player')
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (4, N'Maria', 0, 0, N'War.Model.Player')
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (5, N'Eline', 0, 0, N'War.Model.Player')
GO
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games], [PlayerType]) VALUES (1006, N'Test', 0, 0, N'War.Model.Player')
GO
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
