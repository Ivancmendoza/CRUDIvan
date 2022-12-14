USE [dbCRUDWebApp]
GO
/****** Object:  Table [dbo].[tblEmpleados]    Script Date: 06/08/2022 04:03:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Puesto] [nvarchar](50) NULL,
	[Salario] [int] NULL,
	[Telefono] [nchar](10) NULL,
	[Correo] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblEmpleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
