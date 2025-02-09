Use [NTouch]

/****** Object:  Table [dbo].[Contact]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[EmailAddress] [nvarchar](80) NULL,
	[Address] [nvarchar](64) NULL,
	[StateId] [int] NULL,
	[City] [nvarchar](25) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[ImagePath] [nvarchar](255) NOT NULL,
	[LastContactDate] [datetime] NULL,
	[FollowUpDate] [datetime] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[BirthDate] [datetime] NULL,
	[Subscriber] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ContactView]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ContactView]
AS
SELECT dbo.Contact.Id, dbo.Contact.FirstName, dbo.Contact.LastName, dbo.Contact.PhoneNumber, dbo.Contact.EmailAddress, dbo.Contact.Address, dbo.Contact.StateId, dbo.Contact.City, dbo.Contact.ZipCode, dbo.State.Name AS StateName, dbo.Contact.LastContactDate, dbo.Contact.FollowUpDate, 
        dbo.Contact.BirthDate, dbo.Contact.ImagePath, dbo.State.Code AS StateCode, dbo.Contact.Notes, dbo.Contact.CreatedDate, dbo.Contact.Subscriber
FROM  dbo.Contact INNER JOIN
        dbo.State ON dbo.Contact.StateId = dbo.State.Id
GO
/****** Object:  Table [dbo].[ContactPreference]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactPreference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[ContactMethod] [int] NOT NULL,
 CONSTRAINT [PK_ContactPreference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Contact_Delete]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (1, N'Alaska', N'AK')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (2, N'Alabama', N'AL')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (3, N'Arizona', N'AZ')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (4, N'Arkansas', N'AR')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (5, N'California', N'CA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (6, N'Colorado', N'CO')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (7, N'Connecticut', N'CT')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (8, N'Delaware', N'DE')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (9, N'District of Columbia', N'DC')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (10, N'Florida', N'FL')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (11, N'Georgia', N'GA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (12, N'Hawaii', N'HI')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (13, N'Idaho', N'ID')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (14, N'Illinois', N'IL')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (15, N'Indiana', N'IN')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (16, N'Iowa', N'IA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (17, N'Kansas', N'KS')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (18, N'Kentucky', N'KY')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (19, N'Louisiana', N'LA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (20, N'Maine', N'ME')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (21, N'Maryland', N'MD')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (22, N'Massachusetts', N'MA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (23, N'Michigan', N'MI')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (24, N'Minnesota', N'MN')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (25, N'Mississippi', N'MS')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (26, N'Missouri', N'MO')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (27, N'Montana', N'MT')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (28, N'Nebraska', N'NE')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (29, N'Nevada', N'NV')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (30, N'New Hampshire', N'NH')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (31, N'New Jersey', N'NJ')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (32, N'New Mexico', N'NM')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (33, N'New York', N'NY')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (34, N'North Carolina', N'NC')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (35, N'North Dakota', N'ND')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (36, N'Ohio', N'OH')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (37, N'Oklahoma', N'OK')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (38, N'Oregon', N'OR')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (39, N'Pennsylvania', N'PA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (40, N'Rhode Island', N'RI')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (41, N'South Carolina', N'SC')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (42, N'South Dakota', N'SD')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (43, N'Tennessee', N'TN')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (44, N'Texas', N'TX')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (45, N'Utah', N'UT')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (46, N'Vermont', N'VT')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (47, N'Virginia', N'VA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (48, N'Washington', N'WA')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (49, N'West Virginia', N'WV')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (50, N'Wisconsin', N'WI')
INSERT [dbo].[State] ([Id], [Name], [Code]) VALUES (51, N'Wyoming', N'WY')
SET IDENTITY_INSERT [dbo].[State] OFF
GO

-- Begin Stored Procs

Create PROCEDURE [dbo].[Contact_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Contact]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_FetchAll]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Contact_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[Subscriber],[ZipCode]

    -- From tableName
    From [Contact]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Find]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Contact_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[Subscriber],[ZipCode]

    -- From tableName
    From [Contact]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Insert]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Contact_Insert]

    -- Add the parameters for the stored procedure here
    @Address nvarchar(64),
    @BirthDate datetime,
    @City nvarchar(25),
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @FirstName nvarchar(25),
    @FollowUpDate datetime,
    @ImagePath nvarchar(255),
    @LastContactDate datetime,
    @LastName nvarchar(25),
    @Notes nvarchar(255),
    @PhoneNumber nvarchar(20),
    @StateId int,
    @Subscriber bit,
    @ZipCode nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Contact]
    ([Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[Subscriber],[ZipCode])

    -- Begin Values List
    Values(@Address, @BirthDate, @City, @CreatedDate, @EmailAddress, @FirstName, @FollowUpDate, @ImagePath, @LastContactDate, @LastName, @Notes, @PhoneNumber, @StateId, @Subscriber, @ZipCode)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Update]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Contact_Update]

    -- Add the parameters for the stored procedure here
    @Address nvarchar(64),
    @BirthDate datetime,
    @City nvarchar(25),
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @FirstName nvarchar(25),
    @FollowUpDate datetime,
    @Id int,
    @ImagePath nvarchar(255),
    @LastContactDate datetime,
    @LastName nvarchar(25),
    @Notes nvarchar(255),
    @PhoneNumber nvarchar(20),
    @StateId int,
    @Subscriber bit,
    @ZipCode nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Contact]

    -- Update Each field
    Set [Address] = @Address,
    [BirthDate] = @BirthDate,
    [City] = @City,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [FirstName] = @FirstName,
    [FollowUpDate] = @FollowUpDate,
    [ImagePath] = @ImagePath,
    [LastContactDate] = @LastContactDate,
    [LastName] = @LastName,
    [Notes] = @Notes,
    [PhoneNumber] = @PhoneNumber,
    [StateId] = @StateId,
    [Subscriber] = @Subscriber,
    [ZipCode] = @ZipCode

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_Delete]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ContactPreference]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_DeleteByContactId]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ContactPreference_DeleteByContactId]

    -- Create @ContactId Paramater
    @ContactId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ContactPreference]

    -- Write Where Clause
    Where [ContactId] = @ContactId

END
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_FetchAll]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ContactId],[ContactMethod],[Id]

    -- From tableName
    From [ContactPreference]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_FetchAllForContactId]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_FetchAllForContactId]

    -- Create @ContactId Paramater
    @ContactId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ContactId],[ContactMethod],[Id]

    -- From tableName
    From [ContactPreference]

    -- Load Matching Records
    Where [ContactId] = @ContactId

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_Find]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ContactId],[ContactMethod],[Id]

    -- From tableName
    From [ContactPreference]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_Insert]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_Insert]

    -- Add the parameters for the stored procedure here
    @ContactId int,
    @ContactMethod int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ContactPreference]
    ([ContactId],[ContactMethod])

    -- Begin Values List
    Values(@ContactId, @ContactMethod)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_Update]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactPreference_Update]

    -- Add the parameters for the stored procedure here
    @ContactId int,
    @ContactMethod int,
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ContactPreference]

    -- Update Each field
    Set [ContactId] = @ContactId,
    [ContactMethod] = @ContactMethod

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactView_FetchAll]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ContactView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateCode],[StateId],[StateName],[Subscriber],[ZipCode]

    -- From tableName
    From [ContactView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_Delete]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [State]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_FetchAll]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Code],[Id],[Name]

    -- From tableName
    From [State]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_Find]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Code],[Id],[Name]

    -- From tableName
    From [State]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_FindByName]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_FindByName]

    -- Create @Name Paramater
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Code],[Id],[Name]

    -- From tableName
    From [State]

    -- Find Matching Record
    Where [Name] = @Name

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_Insert]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_Insert]

    -- Add the parameters for the stored procedure here
    @Code nvarchar(10),
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [State]
    ([Code],[Name])

    -- Begin Values List
    Values(@Code, @Name)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_Update]    Script Date: 11/14/2024 10:02:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[State_Update]

    -- Add the parameters for the stored procedure here
    @Code nvarchar(10),
    @Id int,
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [State]

    -- Update Each field
    Set [Code] = @Code,
    [Name] = @Name

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
