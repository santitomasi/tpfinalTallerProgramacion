USE [BBDDTaller]
GO

/****** Object:  Table [dbo].[Adjunto]    Script Date: 02/17/2015 11:48:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Adjunto](
	[adjuntoId] [int] IDENTITY(1,1) NOT NULL,
	[correoId] [int] NOT NULL,
	[ruta] [varchar](200) NOT NULL,
	[descripción] [varchar](300) NULL,
 CONSTRAINT [PK_Adjunto] PRIMARY KEY CLUSTERED 
(
	[adjuntoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Adjunto]  WITH CHECK ADD  CONSTRAINT [FK_Adjunto_CorreoId] FOREIGN KEY([correoId])
REFERENCES [dbo].[Correo] ([correoId])
GO

ALTER TABLE [dbo].[Adjunto] CHECK CONSTRAINT [FK_Adjunto_CorreoId]
GO

