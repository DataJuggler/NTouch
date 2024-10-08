/****** Object:  Table [dbo].[Contact]    Script Date: 10/2/2024 7:28:05 PM ******/
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
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  View [dbo].[ContactView]    Script Date: 10/2/2024 7:28:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ContactView]
AS
SELECT dbo.Contact.Id, dbo.Contact.FirstName, dbo.Contact.LastName, dbo.Contact.PhoneNumber, dbo.Contact.EmailAddress, dbo.Contact.Address, dbo.Contact.StateId, dbo.Contact.City, dbo.Contact.ZipCode, dbo.State.Name AS StateName, dbo.Contact.LastContactDate, dbo.Contact.FollowUpDate, dbo.Contact.BirthDate,
        dbo.Contact.ImagePath, dbo.State.Code AS StateCode
FROM  dbo.Contact INNER JOIN
        dbo.State ON dbo.Contact.StateId = dbo.State.Id
GO
/****** Object:  Table [dbo].[ContactPreference]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Contact_Delete]    Script Date: 10/2/2024 7:28:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  StoredProcedure [dbo].[Contact_FetchAll]    Script Date: 10/2/2024 7:28:05 PM ******/
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
    Select [Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode]

    -- From tableName
    From [Contact]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Find]    Script Date: 10/2/2024 7:28:05 PM ******/
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
    Select [Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode]

    -- From tableName
    From [Contact]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Insert]    Script Date: 10/2/2024 7:28:05 PM ******/
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
    @ZipCode nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Contact]
    ([Address],[BirthDate],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode])

    -- Begin Values List
    Values(@Address, @BirthDate, @City, @CreatedDate, @EmailAddress, @FirstName, @FollowUpDate, @ImagePath, @LastContactDate, @LastName, @Notes, @PhoneNumber, @StateId, @ZipCode)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Contact_Update]    Script Date: 10/2/2024 7:28:05 PM ******/
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
    [ZipCode] = @ZipCode

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ContactPreference_Delete]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_DeleteByContactId]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_FetchAll]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_FetchAllForContactId]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_Find]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_Insert]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactPreference_Update]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ContactView_FetchAll]    Script Date: 10/2/2024 7:28:05 PM ******/
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
    Select [Address],[BirthDate],[City],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[PhoneNumber],[StateCode],[StateId],[StateName],[ZipCode]

    -- From tableName
    From [ContactView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[State_Delete]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[State_FetchAll]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[State_Find]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[State_FindByName]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[State_Insert]    Script Date: 10/2/2024 7:28:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[State_Update]    Script Date: 10/2/2024 7:28:05 PM ******/
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
