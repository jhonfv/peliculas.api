--Tablas--
USE [Peliculas]
GO

/****** Object:  Table [dbo].[ApiKeys]    Script Date: 29/10/2023 19:25:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ApiKeys](
	[ApiKey] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ApiKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ApiKeys] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO


USE [Peliculas]
GO

/****** Object:  Table [dbo].[Peliculas]    Script Date: 29/10/2023 19:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Peliculas](
	[PeliculaId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Genero] [nvarchar](50) NOT NULL,
	[FechaLanzamiento] [datetime] NOT NULL,
	[FechaInserccion] [datetime] NOT NULL,
	[rutaImgPortada] [nvarchar](500) NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Peliculas] ADD  CONSTRAINT [DF_Peliculas_FechaInserccion]  DEFAULT (getdate()) FOR [FechaInserccion]
GO

USE [Peliculas]
GO

/****** Object:  Table [dbo].[PeliculasDetalles]    Script Date: 29/10/2023 19:26:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PeliculasDetalles](
	[PeliculaDetalleId] [int] IDENTITY(1,1) NOT NULL,
	[PeliculaId] [int] NOT NULL,
	[Duracion] [int] NOT NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[Actores] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_PeliculasDetalles] PRIMARY KEY CLUSTERED 
(
	[PeliculaDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

