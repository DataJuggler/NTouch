Use [NTouch]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
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
    ([Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode])

    -- Begin Values List
    Values(@Address, @City, @CreatedDate, @EmailAddress, @FirstName, @FollowUpDate, @ImagePath, @LastContactDate, @LastName, @Notes, @PhoneNumber, @StateId, @ZipCode)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Contact_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
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
Go
-- =========================================================
-- Procure Name: Contact_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
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
    Select [Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode]

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
-- Create Date:   5/13/2024
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
-- Create Date:   5/13/2024
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
    Select [Address],[City],[CreatedDate],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[Notes],[PhoneNumber],[StateId],[ZipCode]

    -- From tableName
    From [Contact]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ContactPreference_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Insert a new ContactPreference
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_Insert >>>'

    End

GO

Create PROCEDURE ContactPreference_Insert

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
Go
-- =========================================================
-- Procure Name: ContactPreference_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Update an existing ContactPreference
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_Update >>>'

    End

GO

Create PROCEDURE ContactPreference_Update

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
Go
-- =========================================================
-- Procure Name: ContactPreference_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Find an existing ContactPreference
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_Find >>>'

    End

GO

Create PROCEDURE ContactPreference_Find

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
Go
-- =========================================================
-- Procure Name: ContactPreference_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Delete an existing ContactPreference
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_Delete >>>'

    End

GO

Create PROCEDURE ContactPreference_Delete

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
Go
-- =========================================================
-- Procure Name: ContactPreference_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Returns all ContactPreference objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_FetchAll >>>'

    End

GO

Create PROCEDURE ContactPreference_FetchAll

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
Go
-- =========================================================
-- Procure Name: ContactView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Returns all ContactView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactView_FetchAll >>>'

    End

GO

Create PROCEDURE ContactView_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[EmailAddress],[FirstName],[FollowUpDate],[Id],[ImagePath],[LastContactDate],[LastName],[PhoneNumber],[StateCode],[StateId],[StateName],[ZipCode]

    -- From tableName
    From [ContactView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: State_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
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
-- Create Date:   5/13/2024
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
-- Create Date:   5/13/2024
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
-- Create Date:   5/13/2024
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
-- Create Date:   5/13/2024
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

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: State_FindByName
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Find an existing State for the Name given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('State_FindByName'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure State_FindByName

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.State_FindByName') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure State_FindByName >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure State_FindByName >>>'

    End

GO

Create PROCEDURE State_FindByName

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
Go
-- =========================================================
-- Procure Name: ContactPreference_FetchAllForContactId
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/13/2024
-- Description:    Returns all ContactPreference objects for the ContactId given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ContactPreference_FetchAllForContactId'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ContactPreference_FetchAllForContactId

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ContactPreference_FetchAllForContactId') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ContactPreference_FetchAllForContactId >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ContactPreference_FetchAllForContactId >>>'

    End

GO

Create PROCEDURE ContactPreference_FetchAllForContactId

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

