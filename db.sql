USE [device_manager]
GO
/****** Object:  Table [dbo].[ElectricMeters]    Script Date: 6/9/2020 10:24:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElectricMeters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serialnumber] [varchar](50) NOT NULL,
	[firmwareversion] [nvarchar](100) NULL,
	[state] [nvarchar](50) NULL,
 CONSTRAINT [PK_ElectricMeters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gateways]    Script Date: 6/9/2020 10:24:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gateways](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serialnumber] [varchar](50) NOT NULL,
	[firmwareversion] [nvarchar](100) NULL,
	[state] [nvarchar](50) NULL,
	[ip] [varchar](50) NULL,
	[port] [int] NULL,
 CONSTRAINT [PK_Gateways] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WaterMeters]    Script Date: 6/9/2020 10:24:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterMeters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serialnumber] [varchar](50) NOT NULL,
	[firmwareversion] [nvarchar](100) NULL,
	[state] [nvarchar](50) NULL,
 CONSTRAINT [PK_WaterMeters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
