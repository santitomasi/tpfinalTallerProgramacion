USE [BBDDTaller]
GO

/****** Object:  Table [dbo].[Cuenta]    Script Date: 02/17/2015 11:47:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cuenta](
	[cuentaId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[servicio] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[cuentaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Cuenta_Nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [CK_Cuenta_Servicio] CHECK  (([servicio]='Outlook' OR [servicio]='Hotmail' OR [servicio]='Yahoo' OR [servicio]='Gmail'))
GO

ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [CK_Cuenta_Servicio]
GO

