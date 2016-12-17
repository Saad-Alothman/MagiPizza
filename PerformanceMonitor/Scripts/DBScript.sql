
GO
/****** Object:  Table [dbo].[branch]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branch](
	[branch_id] [int] IDENTITY(1,1) NOT NULL,
	[postcode] [nchar](10) NULL,
	[status] [nchar](12) NULL,
 CONSTRAINT [PK_branch] PRIMARY KEY CLUSTERED 
(
	[branch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customer_id] [int] NOT NULL,
	[customer_firstName] [nchar](100) NULL,
	[customer_lastName] [nchar](100) NULL,
	[addressLine1] [nchar](100) NULL,
	[addressLine2] [nchar](100) NULL,
	[county] [nchar](100) NULL,
	[city] [nchar](100) NULL,
	[postcode] [nchar](100) NULL,
	[email] [nchar](100) NULL,
	[telephone] [nchar](100) NULL,
	[password] [nchar](100) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer_for_performance_test]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_for_performance_test](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_firstName] [nchar](100) NULL,
	[customer_lastName] [nchar](100) NULL,
	[addressLine1] [nchar](100) NULL,
	[addressLine2] [nchar](100) NULL,
	[county] [nchar](100) NULL,
	[city] [nchar](100) NULL,
	[postcode] [nchar](100) NULL,
	[email] [nchar](100) NULL,
	[telephone] [nchar](100) NULL,
	[password] [nchar](100) NULL,
	[xCoordinate] [int] NULL,
	[yCoordinate] [int] NULL,
 CONSTRAINT [PK_customer_for_performance_test] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer_performance_test]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_performance_test](
	[customer_id] [int] NOT NULL,
	[customer_firstName1] [nchar](100) NULL,
	[customer_lastName] [nchar](100) NULL,
	[addressLine1] [nchar](100) NULL,
	[addressLine2] [nchar](100) NULL,
	[county] [nchar](100) NULL,
	[city] [nchar](100) NULL,
	[postcode] [nchar](100) NULL,
	[email] [nchar](100) NULL,
	[telephone] [nchar](100) NULL,
	[password] [nchar](100) NULL,
	[xCoordinate] [int] NULL,
	[yCoordinate] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fleet]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fleet](
	[vehicle_id] [int] IDENTITY(1,1) NOT NULL,
	[branch_id] [int] NULL,
	[capacity] [int] NULL,
	[status] [nchar](10) NULL,
 CONSTRAINT [PK_fleet] PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[journey]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[journey](
	[journey_id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_id] [int] NULL,
	[journey_date] [date] NULL,
	[journey_startTime] [datetime] NULL,
	[journey_finishTime] [datetime] NULL,
	[journey_capacity] [int] NULL,
 CONSTRAINT [PK_journey] PRIMARY KEY CLUSTERED 
(
	[journey_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[journey_destinations]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[journey_destinations](
	[destination_id] [int] IDENTITY(1,1) NOT NULL,
	[destination_sequence] [int] NULL,
	[duration_from_branch] [int] NULL,
	[duration_from_last_stop] [int] NULL,
	[postcode] [nchar](10) NULL,
	[journey_id] [int] NULL,
	[order_id] [int] NULL,
 CONSTRAINT [PK_journey_destinations] PRIMARY KEY CLUSTERED 
(
	[destination_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order_servant]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_servant](
	[order_id] [int] NULL,
	[branch_id] [int] NULL,
	[vehicle_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orderLine]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderLine](
	[orderLine_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_orderLine] PRIMARY KEY CLUSTERED 
(
	[orderLine_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orders]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[order_date] [date] NULL,
	[order_status] [nchar](10) NULL,
	[dispatch_time] [datetime] NULL,
	[order_processing_startTime] [datetime] NULL,
	[order_processing_FinishTime] [datetime] NULL,
	[order_time] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product_raw]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_raw](
	[raw_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nchar](100) NULL,
	[image] [nchar](10) NULL,
	[category] [nchar](100) NULL,
 CONSTRAINT [PK_product_raw] PRIMARY KEY CLUSTERED 
(
	[raw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[products]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[raw_id] [int] NULL,
	[price] [decimal](18, 0) NULL,
	[processing_time] [int] NULL,
	[product_size] [nchar](10) NULL,
	[setup_time] [int] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[raw_stock]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raw_stock](
	[raw_id] [int] NULL,
	[branch_id] [int] NULL,
	[stock_level] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[staff]    Script Date: 2016-12-17 19:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[branch_id] [int] NOT NULL,
	[first_name] [nchar](100) NULL,
	[status] [nchar](100) NULL,
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [nchar](100) NULL,
 CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[branch] ON 

GO
INSERT [dbo].[branch] ([branch_id], [postcode], [status]) VALUES (243, N'14,15     ', N'available   ')
GO
SET IDENTITY_INSERT [dbo].[branch] OFF
GO
SET IDENTITY_INSERT [dbo].[customer_for_performance_test] ON 

GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1573, N'customer                                                                                            ', N'Number1                                                                                             ', N'customerNumber1 Address1                                                                            ', N'customerNumber1 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'11,03                                                                                               ', N'customerNumber1@Number1.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 11, 3)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1574, N'customer                                                                                            ', N'Number2                                                                                             ', N'customerNumber2 Address1                                                                            ', N'customerNumber2 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'11,04                                                                                               ', N'customerNumber2@Number2.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 11, 4)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1575, N'customer                                                                                            ', N'Number3                                                                                             ', N'customerNumber3 Address1                                                                            ', N'customerNumber3 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'10,09                                                                                               ', N'customerNumber3@Number3.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 10, 9)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1576, N'customer                                                                                            ', N'Number4                                                                                             ', N'customerNumber4 Address1                                                                            ', N'customerNumber4 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'07,17                                                                                               ', N'customerNumber4@Number4.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 7, 17)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1577, N'customer                                                                                            ', N'Number5                                                                                             ', N'customerNumber5 Address1                                                                            ', N'customerNumber5 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'14,05                                                                                               ', N'customerNumber5@Number5.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 14, 5)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1578, N'customer                                                                                            ', N'Number6                                                                                             ', N'customerNumber6 Address1                                                                            ', N'customerNumber6 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'06,12                                                                                               ', N'customerNumber6@Number6.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 6, 12)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1579, N'customer                                                                                            ', N'Number7                                                                                             ', N'customerNumber7 Address1                                                                            ', N'customerNumber7 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'19,10                                                                                               ', N'customerNumber7@Number7.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 19, 10)
GO
INSERT [dbo].[customer_for_performance_test] ([customer_id], [customer_firstName], [customer_lastName], [addressLine1], [addressLine2], [county], [city], [postcode], [email], [telephone], [password], [xCoordinate], [yCoordinate]) VALUES (1580, N'customer                                                                                            ', N'Number8                                                                                             ', N'customerNumber8 Address1                                                                            ', N'customerNumber8 Address2                                                                            ', N'london                                                                                              ', N'london                                                                                              ', N'11,11                                                                                               ', N'customerNumber8@Number8.co.uk                                                                       ', N'07595946193                                                                                         ', NULL, 11, 11)
GO
SET IDENTITY_INSERT [dbo].[customer_for_performance_test] OFF
GO
SET IDENTITY_INSERT [dbo].[fleet] ON 

GO
INSERT [dbo].[fleet] ([vehicle_id], [branch_id], [capacity], [status]) VALUES (258, 243, 70, N'available ')
GO
SET IDENTITY_INSERT [dbo].[fleet] OFF
GO
SET IDENTITY_INSERT [dbo].[journey] ON 

GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1007, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 22:54:00.000' AS DateTime), CAST(N'1900-01-01 23:24:00.000' AS DateTime), 17)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1008, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 23:38:00.000' AS DateTime), CAST(N'1900-01-01 23:56:00.000' AS DateTime), 8)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1009, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 23:54:00.000' AS DateTime), CAST(N'1900-01-01 00:12:00.000' AS DateTime), 7)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1010, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 00:20:00.000' AS DateTime), CAST(N'1900-01-01 00:44:00.000' AS DateTime), 8)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1011, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 00:40:00.000' AS DateTime), CAST(N'1900-01-01 01:02:00.000' AS DateTime), 5)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1012, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 01:00:00.000' AS DateTime), CAST(N'1900-01-01 01:18:00.000' AS DateTime), 9)
GO
INSERT [dbo].[journey] ([journey_id], [vehicle_id], [journey_date], [journey_startTime], [journey_finishTime], [journey_capacity]) VALUES (1013, 258, CAST(N'2012-04-20' AS Date), CAST(N'1900-01-01 00:58:00.000' AS DateTime), CAST(N'1900-01-01 01:10:00.000' AS DateTime), 8)
GO
SET IDENTITY_INSERT [dbo].[journey] OFF
GO
SET IDENTITY_INSERT [dbo].[journey_destinations] ON 

GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1009, 1, 15, 15, N'11,03     ', 1007, 1022)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1010, 2, 17, 3, N'11,04     ', 1007, 1023)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1011, 1, 9, 9, N'10,09     ', 1008, 1024)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1012, 1, 9, 9, N'07,17     ', 1009, 1025)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1013, 1, 12, 12, N'14,05     ', 1010, 1026)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1014, 1, 11, 11, N'06,12     ', 1011, 1027)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1015, 1, 9, 9, N'19,10     ', 1012, 1028)
GO
INSERT [dbo].[journey_destinations] ([destination_id], [destination_sequence], [duration_from_branch], [duration_from_last_stop], [postcode], [journey_id], [order_id]) VALUES (1016, 1, 6, 6, N'11,11     ', 1013, 1029)
GO
SET IDENTITY_INSERT [dbo].[journey_destinations] OFF
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1022, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1023, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1024, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1025, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1026, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1027, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1028, 243, 258)
GO
INSERT [dbo].[order_servant] ([order_id], [branch_id], [vehicle_id]) VALUES (1029, 243, 258)
GO
SET IDENTITY_INSERT [dbo].[orderLine] ON 

GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1013, 1022, 2, 9)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1014, 1023, 2, 8)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1015, 1024, 1, 8)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1016, 1025, 2, 7)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1017, 1026, 1, 8)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1018, 1027, 1, 5)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1019, 1028, 2, 9)
GO
INSERT [dbo].[orderLine] ([orderLine_id], [order_id], [product_id], [quantity]) VALUES (1020, 1029, 2, 8)
GO
SET IDENTITY_INSERT [dbo].[orderLine] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1022, 1573, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 21:36:00.000' AS DateTime), CAST(N'1900-01-01 21:56:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1023, 1574, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 21:56:00.000' AS DateTime), CAST(N'1900-01-01 22:14:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1024, 1575, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 22:14:00.000' AS DateTime), CAST(N'1900-01-01 22:40:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1025, 1576, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 22:40:00.000' AS DateTime), CAST(N'1900-01-01 22:56:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1026, 1577, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 22:56:00.000' AS DateTime), CAST(N'1900-01-01 23:22:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1027, 1578, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 23:22:00.000' AS DateTime), CAST(N'1900-01-01 23:42:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1028, 1579, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 23:42:00.000' AS DateTime), CAST(N'1900-01-01 00:02:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
INSERT [dbo].[orders] ([order_id], [customer_id], [order_date], [order_status], [dispatch_time], [order_processing_startTime], [order_processing_FinishTime], [order_time]) VALUES (1029, 1580, CAST(N'2012-04-20' AS Date), N'placed    ', NULL, CAST(N'1900-01-01 23:42:00.000' AS DateTime), CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'1900-01-01 21:36:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[product_raw] ON 

GO
INSERT [dbo].[product_raw] ([raw_id], [description], [image], [category]) VALUES (1, N'bla bla                                                                                             ', N'someimagr ', N'pizza                                                                                               ')
GO
SET IDENTITY_INSERT [dbo].[product_raw] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

GO
INSERT [dbo].[products] ([product_id], [raw_id], [price], [processing_time], [product_size], [setup_time]) VALUES (1, 1, CAST(20 AS Decimal(18, 0)), 10, N'2         ', 2)
GO
INSERT [dbo].[products] ([product_id], [raw_id], [price], [processing_time], [product_size], [setup_time]) VALUES (2, 1, CAST(2 AS Decimal(18, 0)), 2, N'2         ', 2)
GO
INSERT [dbo].[products] ([product_id], [raw_id], [price], [processing_time], [product_size], [setup_time]) VALUES (3, 1, CAST(2 AS Decimal(18, 0)), 2, N'2         ', 2)
GO
SET IDENTITY_INSERT [dbo].[products] OFF
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 1, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 4, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 4, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 10, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 18, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 26, 285)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 27, 71)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 28, 173)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 32, 288)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 33, 18)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 35, 38)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 37, 120)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 38, 109)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 39, 239)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 40, 57)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 41, 30)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 42, 255)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 43, 145)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 44, 270)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 45, 219)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 46, 289)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 47, 270)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 48, 157)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 49, 208)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 50, 248)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 51, 89)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 52, 41)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 53, 163)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 54, 67)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 55, 23)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 56, 212)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 57, 112)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 56, 15)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 57, 72)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 58, 106)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 59, 125)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 60, 244)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 61, 21)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 62, 165)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 63, 211)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 64, 191)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 65, 41)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 66, 33)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 67, 224)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 68, 190)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 69, 76)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 70, 110)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 71, 103)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 72, 60)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 73, 81)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 74, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 75, 99)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 76, 60)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 77, 142)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 78, 206)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 79, 49)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 80, 269)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 81, 96)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 82, 246)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 83, 185)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 84, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 85, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 86, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 87, 179)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 88, 35)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 89, 25)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 90, 3)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 91, 110)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 92, 118)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 93, 75)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 94, 132)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 95, 133)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 96, 223)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 97, 191)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 98, 184)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 99, 114)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 99, 82)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 100, 105)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 101, 63)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 102, 34)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 103, 188)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 104, -40)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 103, 157)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 104, 45)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 105, 102)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 106, 102)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 107, -134)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 107, 61)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 108, 27)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 109, 117)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 110, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 111, 0)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 112, 59)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 113, 79)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 114, 0)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 115, 0)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 116, 195)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 117, 190)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 118, 3)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 119, -155)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 119, 1)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 120, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 121, 0)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 122, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 123, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 124, 88)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 125, 50)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 126, 46)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 127, 219)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 128, 0)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 129, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 130, 1)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 131, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 132, 100)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 132, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 133, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 134, 1)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 135, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 136, 3)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 137, 262)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 138, 198)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 139, 42)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 140, 118)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 141, 133)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 142, 63)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 143, 179)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 144, 79)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 145, 22)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 146, 195)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 147, 200)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 148, 223)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 149, 61)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 150, 148)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 151, 62)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 152, 207)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 153, 172)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 154, 264)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 155, 260)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 156, 55)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 157, 254)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 158, 69)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 159, 151)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 160, 36)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 161, 199)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 162, 261)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 163, 271)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 164, 131)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 165, 49)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 166, 230)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 167, 140)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 168, 239)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 169, 155)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 170, 113)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 171, 41)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 172, 197)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 173, 118)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 174, 92)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 175, 129)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 176, 221)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 177, 240)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 178, 187)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 179, 85)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 180, 46)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 181, 119)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 182, 257)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 183, 166)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 184, 204)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 185, 11)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 186, 61)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 187, 64)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 188, 153)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 189, 156)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 190, 59)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 191, 76)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 192, 187)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 193, 41)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 194, 1)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 195, 211)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 196, 171)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 197, 83)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 198, 47)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 199, 11)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 200, 82)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 201, 39)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 202, 253)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 203, 60)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 204, 248)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 205, 102)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 206, 154)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 207, 82)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 208, 73)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 209, 130)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 210, 33)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 211, 106)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 212, 58)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 213, 263)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 214, 95)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 215, 211)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 216, 237)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 217, 79)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 218, 74)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 219, 108)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 220, 290)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 221, 162)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 222, 285)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 223, 74)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 224, 90)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 225, 23)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 226, 143)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 227, 157)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 228, 113)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 229, 183)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 230, 248)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 231, 125)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 232, 189)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 233, 161)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 234, 11)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 235, 4)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 236, 157)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 237, 32)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 238, 168)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 239, 76)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 240, 126)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 241, 2)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 242, 126)
GO
INSERT [dbo].[raw_stock] ([raw_id], [branch_id], [stock_level]) VALUES (1, 243, 221)
GO
SET IDENTITY_INSERT [dbo].[staff] ON 

GO
INSERT [dbo].[staff] ([branch_id], [first_name], [status], [employee_id], [last_name]) VALUES (243, N'fEmployee0                                                                                          ', N'available                                                                                           ', 233, N'lEmployee0                                                                                          ')
GO
SET IDENTITY_INSERT [dbo].[staff] OFF
GO
