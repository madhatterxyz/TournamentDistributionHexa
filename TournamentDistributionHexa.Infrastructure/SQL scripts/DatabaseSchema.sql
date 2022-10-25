﻿USE [RepartitionTournoi]
GO
/****** Object:  Table [dbo].[Composition]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Composition](
	[MatchId] [bigint] NOT NULL,
	[JeuId] [bigint] NOT NULL,
	[TournoiId] [bigint] NOT NULL,
 CONSTRAINT [PK_MatchTournoiJeu] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC,
	[JeuId] ASC,
	[TournoiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jeu]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jeu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](100) NOT NULL,
	[NbJoueursMin] [int] NOT NULL,
	[NbJoueursMax] [int] NOT NULL,
	[MecaniqueId] [bigint] NULL,
 CONSTRAINT [PK_Jeu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Joueur]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Joueur](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prénom] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Joueur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[DateFin] [datetime] NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mecanique]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mecanique](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Mecanique] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Score]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[MatchId] [bigint] NOT NULL,
	[JoueurId] [bigint] NOT NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC,
	[JoueurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournoi]    Script Date: 25/10/2022 16:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournoi](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tournoi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD FOREIGN KEY([JeuId])
REFERENCES [dbo].[Jeu] ([Id])
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK__MatchTour__Match__619B8048] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK__MatchTour__Match__619B8048]
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK__MatchTour__Tourn__6383C8BA] FOREIGN KEY([TournoiId])
REFERENCES [dbo].[Tournoi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK__MatchTour__Tourn__6383C8BA]
GO
ALTER TABLE [dbo].[Jeu]  WITH CHECK ADD FOREIGN KEY([MecaniqueId])
REFERENCES [dbo].[Mecanique] ([Id])
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD FOREIGN KEY([JoueurId])
REFERENCES [dbo].[Joueur] ([Id])
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK__Score__MatchId__534D60F1] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK__Score__MatchId__534D60F1]
GO

