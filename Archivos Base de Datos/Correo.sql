USE [BBDDTaller]
GO

/****** Object:  Table [dbo].[Correo]    Script Date: 02/19/2015 19:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Correo](
	[correoId] [int] IDENTITY(1,1) NOT NULL,
	[tipocorreo] [varchar](20) NOT NULL,
	[fecha] [date] NOT NULL,
	[texto] [text] NOT NULL,
	[cuentaOrigen] [varchar](50) NOT NULL,
	[cuentaDestino] [varchar](max) NOT NULL,
	[asunto] [varchar](max) NOT NULL,
	[leido] [bit] NULL,
	[correoServicioId] [varchar](200) NOT NULL,
	[eliminado] [bit] NULL,
 CONSTRAINT [PK_Correo] PRIMARY KEY CLUSTERED 
(
	[correoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Correo]  WITH CHECK ADD  CONSTRAINT [CK_Correo] CHECK  (([tipocorreo]='Recibido' OR [tipocorreo]='Enviado'))
GO

ALTER TABLE [dbo].[Correo] CHECK CONSTRAINT [CK_Correo]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verifica el campo tipocorreo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Correo', @level2type=N'CONSTRAINT',@level2name=N'CK_Correo'
GO

