USE [CardGameExample]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 9-3-2023 14:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerNumber] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [varchar](50) NOT NULL,
	[Wins] [int] NOT NULL,
	[Games] [int] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [IX_PlayerNameUnique]    Script Date: 9-3-2023 14:21:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PlayerNameUnique] ON [dbo].[Player]
(
	[PlayerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (1, N'Piet', 71, 5)
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (2, N'Jan', 3, 6)
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (3, N'Klaas', 2, 3)
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (4, N'Maria', 1, 1)
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (5, N'Eline', 2, 3)
INSERT [dbo].[Player] ([PlayerNumber], [PlayerName], [Wins], [Games]) VALUES (6, N'Rob', 0, 0)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
