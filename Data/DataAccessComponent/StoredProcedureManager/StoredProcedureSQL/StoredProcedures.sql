Use [NTouch]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Insert a new Contact
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Contact_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Contact_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Contact_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Contact_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Contact_Insert >>>'

    End

GO

Create PROCEDURE Contact_Insert

    -- Add the parameters for the stored procedure here
    @Address nvarchar(64),
    @City nvarchar(25),
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @FirstName nvarchar(25),
    @FollowUpDate datetime,
    @ImagePath nvarchar(255),
    @LastName nvarchar(25),
    @Notes nvarchar(255),
    @PhoneNumber nvarchar(20),
    @State nvarchar(20),
    @ZipCode nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Contact]
    ([Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[ImagePath],[LastName],[Notes],[PhoneNumber],[State],[ZipCode])

    -- Begin Values List
    Values(@Address, @City, @CreatedDate, @EmailAddress, @FirstName, @FollowUpDate, @ImagePath, @LastName, @Notes, @PhoneNumber, @State, @ZipCode)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Update an existing Contact
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Contact_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Contact_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Contact_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Contact_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Contact_Update >>>'

    End

GO

Create PROCEDURE Contact_Update

    -- Add the parameters for the stored procedure here
    @Address nvarchar(64),
    @City nvarchar(25),
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @FirstName nvarchar(25),
    @FollowUpDate datetime,
    @Id int,
    @ImagePath nvarchar(255),
    @LastName nvarchar(25),
    @Notes nvarchar(255),
    @PhoneNumber nvarchar(20),
    @State nvarchar(20),
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
    [City] = @City,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [FirstName] = @FirstName,
    [FollowUpDate] = @FollowUpDate,
    [ImagePath] = @ImagePath,
    [LastName] = @LastName,
    [Notes] = @Notes,
    [PhoneNumber] = @PhoneNumber,
    [State] = @State,
    [ZipCode] = @ZipCode

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Find an existing Contact
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Contact_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Contact_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Contact_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Contact_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Contact_Find >>>'

    End

GO

Create PROCEDURE Contact_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastName],[Notes],[PhoneNumber],[State],[ZipCode]

    -- From tableName
    From [Contact]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Delete an existing Contact
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Contact_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Contact_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Contact_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Contact_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Contact_Delete >>>'

    End

GO

Create PROCEDURE Contact_Delete

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
Go
-- =========================================================
-- Procure Name: Contact_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Returns all Contact objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Contact_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Contact_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Contact_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Contact_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Contact_FetchAll >>>'

    End

GO

Create PROCEDURE Contact_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastName],[Notes],[PhoneNumber],[State],[ZipCode]

    -- From tableName
    From [Contact]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: State_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Insert a new State
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_Insert >>>'

    End

GO

Create PROCEDURE State_Insert

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
Go
-- =========================================================
-- Procure Name: State_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Update an existing State
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_Update >>>'

    End

GO

Create PROCEDURE State_Update

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
Go
-- =========================================================
-- Procure Name: State_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Find an existing State
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_Find >>>'

    End

GO

Create PROCEDURE State_Find

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
Go
-- =========================================================
-- Procure Name: State_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Delete an existing State
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_Delete >>>'

    End

GO

Create PROCEDURE State_Delete

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
Go
-- =========================================================
-- Procure Name: State_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/28/2024
-- Description:    Returns all State objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_FetchAll >>>'

    End

GO

Create PROCEDURE State_FetchAll

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

-- Thank you for using DataTier.Net.

