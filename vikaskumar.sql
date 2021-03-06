USE [mygps]
GO
/****** Object:  Table [dbo].[vehicletracking]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicletracking](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[driverid] [nvarchar](50) NULL,
	[vno] [nvarchar](50) NULL,
	[permitno] [nvarchar](50) NULL,
	[permittype] [nvarchar](50) NULL,
	[company] [nvarchar](50) NULL,
	[avgspeed] [nvarchar](50) NULL,
	[fueltank] [nvarchar](50) NULL,
	[currenttankstatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_vehicletracking] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persontracking]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persontracking](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[pid] [nvarchar](50) NULL,
	[pname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[repassword] [nvarchar](50) NULL,
	[contact] [nvarchar](50) NULL,
	[rcontact1] [nvarchar](50) NULL,
	[rcontact2] [nvarchar](50) NULL,
	[rcontact3] [nvarchar](50) NULL,
	[rcontact4] [nvarchar](50) NULL,
	[pimg] [nvarchar](50) NULL,
 CONSTRAINT [PK_persontracking_1] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_email_persontracking] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personallonglat]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personallonglat](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[pid] [varchar](50) NULL,
	[pdate] [date] NULL,
	[ptime] [varchar](50) NULL,
	[longitude] [varchar](50) NULL,
	[lattitude] [varchar](50) NULL,
 CONSTRAINT [PK_personallonglat] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ownertracking]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ownertracking](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[ownerid] [nvarchar](50) NULL,
	[ownername] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[confirmpassword] [nvarchar](50) NULL,
	[contactno] [nvarchar](50) NULL,
	[vehicleno] [nvarchar](50) NULL,
	[ownerpic] [nvarchar](50) NULL,
 CONSTRAINT [PK_ownertracking] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[activation] [nvarchar](50) NULL,
 CONSTRAINT [PK_login] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[comment] [nvarchar](50) NULL,
 CONSTRAINT [PK_feedback] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[driver]    Script Date: 05/22/2017 03:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[driver](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[driverid] [nvarchar](50) NULL,
	[drivername] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[cpassword] [nvarchar](50) NULL,
	[vehicleno] [nvarchar](50) NULL,
	[driverimg] [nvarchar](50) NULL,
 CONSTRAINT [PK_driver] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
