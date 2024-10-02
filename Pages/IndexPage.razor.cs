

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using Microsoft.AspNetCore.Components;
using NTouch.Shared;
using NTouch.Components;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataAccessComponent.Connection;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using NTouch.Objects;
using DataAccessComponent.DataGateway;

#endregion

namespace NTouch.Pages
{

    #region class Index
    /// <summary>
    /// This class is the main page for this app.
    /// </summary>
    public partial class IndexPage : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string name;
        private List<IBlazorComponent> children;
        private IBlazorComponentParent parent;
        private string title;
        private ContactEditor contactEditor;
        private Grid contactsGrid;
        private Label statusLabel;
        private ScreenTypeEnum screenType;
        private SecretComponent secretControl;
        private List<ContactView> contactsList;
        private int contactIdToSelect;
        private InformationBox infoBox;
        private TimeComponent timeComponent;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Index object
        /// </summary>
        public IndexPage()
        {
            // Create a new collection of 'IBlazorComponentParent' objects.
            Children = new List<IBlazorComponent>();

            // Set the title
            Title = "Manage Contacts";

            // Default
            ScreenType = ScreenTypeEnum.ContactList;
        }
        #endregion
        
        #region Methods
            
            #region AddContact()
            /// <summary>
            /// Add Contact
            /// </summary>
            public void AddContact()
            {
                // erase
                ContactIdToSelect = 0;

                // Set the ScreenType
                ScreenType = ScreenTypeEnum.AddContact;

                // if the value for HasContactEditor is true
                if (HasContactEditor)
                {
                    // Change the Title
                    ContactEditor.Title = "Add Contact";
                }

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region CreateRowsForContactsGrid()
            /// <summary>
            /// returns a list of Rows For Contacts Grid
            /// </summary>
            public List<Row> CreateRowsForContactsGrid()
            {
                // initial value
                List<Row> rows = new List<Row>();

                // If the ContactsList collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(ContactsList))
                {
                    // recreate, in case this is called twice due to a refresh
                    ContactsGrid.Columns = new List<Column>();
                    ContactsGrid.Rows = new List<Row>();

                    // Create Column and set properties
                    Column column = new Column();
                    column.Caption = "First";
                    column.ColumnName = "FirstName";
                    column.Index = 0;
                    column.ColumnNumber = 1;                        
                    column.ColumnText = column.Caption;
                    column.Width = 64;
                    column.Height = 16;                    
                    column.ClassName = "displayinlineblock textdonotwrap width64 colorwhite textalignleft right16 down4 fontsize12";  

                    // Add this column
                    ContactsGrid.Columns.Add(column);

                    // Create Column and set properties
                    Column column2 = new Column();
                    column2.Caption = "Last";
                    column2.ColumnName = "LastName";
                    column2.Index = 1;
                    column2.ColumnNumber = 2;                        
                    column2.ColumnText = column2.Caption;
                    column2.Width = 64;
                    column2.Height = 16;
                    column2.ClassName = "displayinlineblock textdonotwrap width64 colorwhite textalignleft down4 right16 fontsize12";  

                    // Add Column 2 to the header row
                    ContactsGrid.Columns.Add(column2);

                    // Create Column and set properties
                    Column column3 = new Column();
                    column3.Caption = "Phone #";
                    column3.ColumnName = "PhoneNumber";
                    column3.Index = 2;
                    column3.ColumnNumber = 3;                        
                    column3.ColumnText = column3.Caption;
                    column3.Width = 96;
                    column3.Height = 16;
                    column3.ClassName = "displayinlineblock textdonotwrap width96 colorwhite textalignleft down4 right20 fontsize12";  

                    // Add this column
                    ContactsGrid.Columns.Add(column3);

                    // Create Column and set properties
                    Column column4 = new Column();
                    column4.Caption = "Email";
                    column4.ColumnName = "EmailAddress";
                    column4.Index = 3;
                    column4.ColumnNumber = 4;                        
                    column4.ColumnText = column4.Caption;
                    column4.Width = 132;
                    column4.Height = 16;
                    column4.ClassName = "displayinlineblock textdonotwrap width132 colorwhite textalignleft down4 right14 fontsize12";

                    // Add this column
                    ContactsGrid.Columns.Add(column4);

                    // Create Column and set properties
                    Column column5 = new Column();
                    column5.Caption = "Address";
                    column5.ColumnName = "ShortAddress";
                    column5.Index = 4;
                    column5.ColumnNumber = 5;                        
                    column5.ColumnText = column5.Caption;
                    column5.Width = 120;
                    column5.Height = 16;
                    column5.ClassName = "displayinlineblock textdonotwrap width120 colorwhite textalignleft down4 right16 fontsize12";

                    // Add this column
                    ContactsGrid.Columns.Add(column5);

                    // Create Column and set properties
                    Column column6 = new Column();
                    column6.Caption = "City";
                    column6.ColumnName = "City";
                    column6.Index = 5;
                    column6.ColumnNumber = 6;                        
                    column6.ColumnText = column6.Caption;
                    column6.Width = 88;
                    column6.Height = 16;
                    column6.ClassName = "displayinlineblock textdonotwrap width88 colorwhite textalignleft down4 right8 fontsize12";

                    // Add this column
                    ContactsGrid.Columns.Add(column6);

                    // Create Column and set properties
                    Column column7 = new Column();
                    column7.Caption = "State";
                    column7.ColumnName = "StateName";
                    column7.Index = 6;
                    column7.ColumnNumber = 7;                        
                    column7.ColumnText = column7.Caption;
                    column7.Width = 48;
                    column7.Height = 16;
                    column7.ClassName = "displayinlineblock textdonotwrap width48 colorwhite textalignleft down4 right2 fontsize12";

                    // Add this column
                    ContactsGrid.Columns.Add(column7);

                    // Create Column and set properties
                    Column column8 = new Column();
                    column8.Caption = "Last Contact";
                    column8.ColumnName = "LastContactedDate";
                    column8.Index = 7;
                    column8.ColumnNumber = 8;
                    column8.ColumnText = column8.Caption;
                    column8.Width = 80;
                    column8.Height = 16;
                    column8.ClassName = "displayinlineblock textdonotwrap width80 colorwhite textalignleft down4 right4 fontsize12";

                     // Add this column
                    ContactsGrid.Columns.Add(column8);

                    // Create Column and set properties
                    Column column9 = new Column();
                    column9.Caption = "Follow Up";
                    column9.ColumnName = "FollowUpDate";
                    column9.Index = 8;
                    column9.ColumnNumber = 9;
                    column9.ColumnText = column9.Caption;
                    column9.Width = 80;
                    column9.Height = 16;
                    column9.ClassName = "displayinlineblock textdonotwrap width80 colorwhite textalignleft down4 right4 fontsize12";

                    // Add this column
                    ContactsGrid.Columns.Add(column9);

                    // Iterate the collection of IndustryLosingStreakView objects
                    foreach (ContactView contact in ContactsList)
                    {
                        // Create a row
                        Row row = new Row();                        
                        row.ExternalId = contact.Id;
                        row.ExternalIdDescription = "A Contact Was Opened";
                        row.ClassName = "textdonotwrap width448 height16 marginbottom0 down8";

                        // Create Column and set properties
                        column = new Column();                        
                        column.ColumnName = "FirstName";
                        column.Index = 0;
                        column.ColumnNumber = 1;                        
                        column.ColumnText = contact.FirstName;
                        column.Width = 64;
                        column.Height = 16;                        
                        column.ClassName = "displayinlineblock textdonotwrap width64 colorwhite textalignleft down4 right16 fontsize12 cursorpointer";  

                        // Set the Row
                        column.Row = row;

                        // Add this column
                        row.Columns.Add(column);

                        // Create Column and set properties
                        column2 = new Column();
                        column2.ColumnName = "LastName";
                        column2.Index = 1;
                        column2.ColumnNumber = 2;                        
                        column2.ColumnText = contact.LastName;
                        column2.Width = 64;
                        column2.Height = 16;
                        column2.ClassName = "displayinlineblock textdonotwrap width64 colorwhite textalignleft down4 right16 fontsize12";  

                        // Add Column 2 to the header row
                        row.Columns.Add(column2);

                        // Create Column and set properties
                        column3 = new Column();
                        column3.ColumnName = "PhoneNumber";
                        column3.Index = 2;
                        column3.ColumnNumber = 3;                        
                        column3.ColumnText = contact.PhoneNumber;
                        column3.Width = 96;
                        column3.Height = 16;
                        column3.ClassName = "displayinlineblock textdonotwrap width96 colorwhite textalignleft down4 right18 fontsize12";  

                        // Add this column
                        row.Columns.Add(column3);

                        // Create Column and set properties
                        column4 = new Column();
                        column4.ColumnName = "Email";
                        column4.Index = 3;
                        column4.ColumnNumber = 4;                        
                        column4.ColumnText = contact.ShortEmail;
                        column4.Width = 132;
                        column4.Height = 16;
                        column4.ClassName = "displayinlineblock textdonotwrap width132 colorwhite textalignleft down4 right16 fontsize12";

                        // Add this column
                        row.Columns.Add(column4);

                        // Create Column and set properties
                        column5 = new Column();
                        column5.ColumnName = "ShortAddress";
                        column5.Index = 3;
                        column5.ColumnNumber = 4;                        
                        column5.ColumnText = contact.ShortAddress;
                        column5.Width = 120;
                        column5.Height = 16;
                        column5.ClassName = "displayinlineblock textdonotwrap width120 colorwhite textalignleft down4 right16 fontsize12";

                        // Add this column
                        row.Columns.Add(column5);

                        // Create Column and set properties
                        column6 = new Column();
                        column6.ColumnName = "City";
                        column6.Index = 5;
                        column6.ColumnNumber = 6;                        
                        column6.ColumnText = contact.City;
                        column6.Width = 88;
                        column6.Height = 16;
                        column6.ClassName = "displayinlineblock textdonotwrap width88 colorwhite textalignleft down4 right8 fontsize12";

                        // Add this column
                        row.Columns.Add(column6);

                        // Create Column and set properties
                        column7 = new Column();
                        column7.ColumnName = "StateCode";
                        column7.Index = 6;
                        column7.ColumnNumber = 7;                        
                        column7.ColumnText = contact.StateCode;
                        column7.Width = 48;
                        column7.Height = 16;
                        column7.ClassName = "displayinlineblock textdonotwrap width48 colorwhite textalignleft down4 right8 fontsize12";

                        // Add this column
                        row.Columns.Add(column7);

                        // Create Column and set properties
                        column8 = new Column();
                        column8.ColumnName = "LastContactedDate";
                        column8.Index = 7;
                        column8.ColumnNumber = 8;

                        // if an actual date
                        if (contact.LastContactDate.Year > 1900)
                        {
                            column8.ColumnText = contact.LastContactDate.ToShortDateString();
                        }
                        else
                        {
                            // Empty
                            column8.ColumnText = "";
                        }
                        column8.Width = 80;
                        column8.Height = 16;
                        column8.ClassName = "displayinlineblock textdonotwrap width80 colorwhite textalignleft down4 right8 fontsize12";

                        // Add this column
                        row.Columns.Add(column8);

                        // Create Column and set properties
                        column9 = new Column();
                        column9.ColumnName = "FollowUpDate";
                        column9.Index = 8;
                        column9.ColumnNumber = 9;

                        // if an actual date
                        if (contact.FollowUpDate.Year > 1900)
                        {
                            column9.ColumnText = contact.FollowUpDate.ToShortDateString();
                        }
                        else
                        {
                            // Empty
                            column9.ColumnText = "";
                        }

                        column9.Width = 80;
                        column9.Height = 16;
                        column9.ClassName = "displayinlineblock textdonotwrap width80 colorwhite textalignleft down4 right8 fontsize12";

                        // Add this column
                        row.Columns.Add(column9);

                        // Add this row
                        rows.Add(row);
                    }
                }

                // return value
                return rows;
            }
            #endregion
            
            #region CreateSampleInfoBoxItems()
            /// <summary>
            /// returns a list of Sample Info Box Items
            /// </summary>
            public List<Item> CreateSampleInfoBoxItems()
            {
                // initial value
                List<Item> items = new List<Item>();

                // Create a new instance of an 'Item' object.
                Item item = new Item();
                item.Caption = "Acceptable Pressure Test?";
                item.Text = "Yes";
                
                // image
                item.IncludeImage = true;
                item.ImageAlignment = ImageAlignmentEnum.ImageOnLeftOfText;
                item.ImageWidth = 16;
                item.ImageHeight = 16;
                item.ImageUrl = "../Images/GreenCircle.png";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "PSI Loss to Leak?";
                item.Text = "30.1 psi";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "Total Test Time";
                item.Text = "8 Hours 0 Minutes";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "Min Test Duration Met?";
                item.Text = "Yes";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "Min Test Pressure Met?";
                item.Text = "Yes";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "MAOP Verified By Test";
                item.Text = "452 psi";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "Desired MAOP";
                item.Text = "400 psi";
                
                // Add this item
                items.Add(item);

                // Create a new instance of an 'Item' object.
                item = new Item();
                item.Caption = "Test Within Pressure Bounds?";
                item.Text = "Yes";
                
                // Add this item
                items.Add(item);

                // return value
                return items;
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method Find Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                 // probably not used
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region GetTime()
            /// <summary>
            /// Get Time
            /// </summary>
            public void GetTime()
            {
                if ((HasTimeComponent) && (TimeComponent.HasHoursTextBox) && (TimeComponent.HasMinutesTextBox))
                {
                    string hour = TimeComponent.HoursTextBox.Text;

                    string minute = TimeComponent.MinutesTextBox.Text;
                }
            }
            #endregion
            
            #region ImportExcel()
            /// <summary>
            /// Import Excel
            /// </summary>
            public void ImportExcel()
            {
                // Create a new instance of a 'WorksheetInfo' object.
                WorksheetInfo info = new WorksheetInfo();
                info.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
                info.ColumnsToLoad = 3;
                info.SheetName = "StateList";

                // Change to whereever you have the project saved
                info.Path = "C:\\Projects\\GitHub\\NTouch\\Excel\\States.xlsx";

                // Load the worksheet
                Worksheet worksheet = ExcelDataLoader.LoadWorksheet(info);

                // Load the States from Excel
                List<StateList> states = StateList.Load(worksheet);

                // If the states collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(states))
                {
                    // Set the Connection String
                    Gateway gateway = new Gateway(Connection.Name);

                    // iterate the states
                    foreach (StateList tempState in states)
                    {
                        // Create a new state
                        State state = new State();
                        state.Name = tempState.Name;
                        state.Code = tempState.Code;

                        // Perform the save
                        bool saved = gateway.SaveState(ref state);
                    }
                }

                // Show a message
                StatusLabel.SetTextValue("Import Excel Finished");
            }
            #endregion
            
            #region LoadAndDisplaySelectedContact()
            /// <summary>
            /// Load And Display Selected Contact
            /// </summary>
            public void LoadAndDisplaySelectedContact()
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(Connection.Name);

                // if the value for HasContactEditor is true
                if (HasContactEditor)
                {
                    // if the ContactEditor does not have a Selected Object, or if the Selected Contact doesn't match
                    if ((!ContactEditor.HasSelectedContact) || (ContactEditor.SelectedContact.Id != ContactIdToSelect))
                    {
                        // Set the SelectedContact
                        ContactEditor.SelectedContact = gateway.FindContact(ContactIdToSelect);
                    }

                    // Display the selected contact
                    ContactEditor.DisplaySelectedContact();
                }
            }
            #endregion
            
            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to load a Contact that was just opened
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {  
                // if there is a ContactIdToSelect
                if ((ContactIdToSelect > 0) && (ScreenType == ScreenTypeEnum.EditContact))
                {
                    // force return back
                    await Task.Yield();

                    // Load and display the selected contact
                    LoadAndDisplaySelectedContact();
                }
            }
            #endregion

            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    // Set the id
                    int contactId = message.Id;

                    // testing only
                    string description = message.Text;

                    // Enter Edit Mode
                    ScreenType = ScreenTypeEnum.EditContact;

                    // if the value for HasMainLayout is true
                    if (HasMainLayout)
                    {
                        // Set the Session Id
                        MainLayout.SessionId = Guid.NewGuid().ToString().Substring(12);
                    }

                    // Must select the contact when the ContactEditor is registered
                    ContactIdToSelect = contactId;

                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is Label)
                {
                    // Store
                    StatusLabel = component as Label;
                }                
                else if (component is ContactEditor)
                {
                    // store
                    ContactEditor = component as ContactEditor;

                    // if the value for HasContactEditor is true
                    if (HasContactEditor)
                    {
                        // if a ContactId was set
                        if (ContactIdToSelect > 0)
                        {
                            // Create a new instance of a 'Gateway' object.
                            Gateway gateway = new Gateway(Connection.Name);

                            // Find the selected contact
                            ContactEditor.SelectedContact = gateway.FindContact(ContactIdToSelect);

                            // Display this contact
                            ContactEditor.DisplaySelectedContact();
                        }
                        else
                        {
                            // Create a new Contact
                            ContactEditor.SelectedContact = new Contact();
                        }
                    }
                }
                // if is the component is a grid
                else if (component is Grid)
                {
                    // Store
                    ContactsGrid = component as Grid;

                    // Create an instance of the Gateway
                    Gateway gateway = new Gateway(Connection.Name);

                    // Load the Contacts
                    ContactsList = gateway.LoadContactViews();

                    // if the value for HasContactsGrid is true and has ContactList
                    if ((HasContactsGrid) && (ListHelper.HasOneOrMoreItems(ContactsList)))
                    {
                        // Reorder the ContactsList
                        ContactsList = ContactsList.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

                        // Create the Rows for the Contacts Grid
                        ContactsGrid.Rows = CreateRowsForContactsGrid();

                        // Refresh the Grid
                        ContactsGrid.Refresh();
                    }
                    else
                    {
                        // Get the last error
                        Exception error = gateway.GetLastException();

                        // If the error object exists
                        if (NullHelper.Exists(error))
                        {
                            // if the value for HasStatusLabel is true
                            if (HasStatusLabel)
                            {
                                StatusLabel.SetTextValue(error.ToString());
                            }
                        }
                    }
                }
                else if (component is SecretComponent)
                {
                    // Store
                    SecretControl = component as SecretComponent;

                    // Update the UI with the Secret
                    SecretControl.Refresh();
                }
                else if (component is InformationBox)
                {
                    // Store
                    InformationBox tempBox = component as InformationBox;

                    // if this is the Summary
                    if (tempBox.Name == "Summary")
                    {
                        // Set the tempBox
                        InfoBox = tempBox;

                        // test only
                        List<Item> items = CreateSampleInfoBoxItems();

                        // if the value for HasInfoBox is true
                        if (HasInfoBox)
                        {
                            // Set the Items
                            InfoBox.SetItems(items);

                            // Update the UI
                            InfoBox.Refresh();
                        }
                    }
                }
                else if (component is TimeComponent)
                {
                    // Cast as a TimeComponent
                    TimeComponent = component as TimeComponent;

                    if (HasTimeComponent)
                    {
                        // If the value for the property TimeComponent.HasHoursTextBox is true
                        if (TimeComponent.HasHoursTextBox)
                        {
                            
                        }

                        // If the value for the property TimeComponent.HasMinutesTextBox is true
                        if (TimeComponent.HasMinutesTextBox)
                        {
                            // Update the ClassName
                            TimeComponent.MinutesTextBox.SetClassName("right64", true);
                        }
                    }
                }
            }
            #endregion
            
            #region ReturnToContactList()
            /// <summary>
            /// Return To Contact List
            /// </summary>
            public void ReturnToContactList()
            {
                // Update
                ScreenType = ScreenTypeEnum.ContactList;

                // Reload
                Refresh();
            }
            #endregion
            
            #region ShowInformationBox()
            /// <summary>
            /// Show Information Box
            /// </summary>
            public void ShowInformationBox()
            {
                // Show Sample
                ScreenType = ScreenTypeEnum.TestInfoBox;

                // Update
                Refresh();
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion

            #region ContactEditor
            /// <summary>
            /// This property gets or sets the value for 'ContactEditor'.
            /// </summary>
            public ContactEditor ContactEditor
            {
                get { return contactEditor; }
                set { contactEditor = value; }
            }
            #endregion
            
            #region ContactIdToSelect
            /// <summary>
            /// This property gets or sets the value for 'ContactIdToSelect'.
            /// </summary>
            public int ContactIdToSelect
            {
                get { return contactIdToSelect; }
                set { contactIdToSelect = value; }
            }
            #endregion
            
            #region ContactsGrid
            /// <summary>
            /// This property gets or sets the value for 'ContactsGrid'.
            /// </summary>
            public Grid ContactsGrid
            {
                get { return contactsGrid; }
                set { contactsGrid = value; }
            }
            #endregion
            
            #region ContactsList
            /// <summary>
            /// This property gets or sets the value for 'ContactsList'.
            /// </summary>
            public List<ContactView> ContactsList
            {
                get { return contactsList; }
                set { contactsList = value; }
            }
            #endregion
            
            #region HasContactEditor
            /// <summary>
            /// This property returns true if this object has a 'ContactEditor'.
            /// </summary>
            public bool HasContactEditor
            {
                get
                {
                    // initial value
                    bool hasContactEditor = (this.ContactEditor != null);
                    
                    // return value
                    return hasContactEditor;
                }
            }
            #endregion
            
            #region HasContactsGrid
            /// <summary>
            /// This property returns true if this object has a 'ContactsGrid'.
            /// </summary>
            public bool HasContactsGrid
            {
                get
                {
                    // initial value
                    bool hasContactsGrid = (this.ContactsGrid != null);
                    
                    // return value
                    return hasContactsGrid;
                }
            }
            #endregion
            
            #region HasContactsList
            /// <summary>
            /// This property returns true if this object has a 'ContactsList'.
            /// </summary>
            public bool HasContactsList
            {
                get
                {
                    // initial value
                    bool hasContactsList = (this.ContactsList != null);
                    
                    // return value
                    return hasContactsList;
                }
            }
            #endregion
            
            #region HasInfoBox
            /// <summary>
            /// This property returns true if this object has an 'InfoBox'.
            /// </summary>
            public bool HasInfoBox
            {
                get
                {
                    // initial value
                    bool hasInfoBox = (this.InfoBox != null);
                    
                    // return value
                    return hasInfoBox;
                }
            }
            #endregion
            
            #region HasMainLayout
            /// <summary>
            /// This property returns true if this object has a 'MainLayout'.
            /// </summary>
            public bool HasMainLayout
            {
                get
                {
                    // initial value
                    bool hasMainLayout = (this.MainLayout != null);
                    
                    // return value
                    return hasMainLayout;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasSecretControl
            /// <summary>
            /// This property returns true if this object has a 'SecretControl'.
            /// </summary>
            public bool HasSecretControl
            {
                get
                {
                    // initial value
                    bool hasSecretControl = (this.SecretControl != null);
                    
                    // return value
                    return hasSecretControl;
                }
            }
            #endregion
            
            #region HasStatusLabel
            /// <summary>
            /// This property returns true if this object has a 'StatusLabel'.
            /// </summary>
            public bool HasStatusLabel
            {
                get
                {
                    // initial value
                    bool hasStatusLabel = (this.StatusLabel != null);
                    
                    // return value
                    return hasStatusLabel;
                }
            }
            #endregion
            
            #region HasTimeComponent
            /// <summary>
            /// This property returns true if this object has a 'TimeComponent'.
            /// </summary>
            public bool HasTimeComponent
            {
                get
                {
                    // initial value
                    bool hasTimeComponent = (this.TimeComponent != null);
                    
                    // return value
                    return hasTimeComponent;
                }
            }
            #endregion
            
            #region InfoBox
            /// <summary>
            /// This property gets or sets the value for 'InfoBox'.
            /// </summary>
            public InformationBox InfoBox
            {
                get { return infoBox; }
                set { infoBox = value; }
            }
            #endregion
            
            #region MainLayout
            /// <summary>
            /// This read only property returns the value of MainLayout from the object Parent.
            /// </summary>
            public MainLayout MainLayout
            {
                
                get
                {
                    // initial value
                    MainLayout mainLayout = null;
                    
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        mainLayout = Parent as MainLayout;
                    }
                    
                    // return value
                    return mainLayout;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                {
                    // Set the value
                    parent = value;

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // Notify the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region ScreenType
            /// <summary>
            /// This property gets or sets the value for 'ScreenType'.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                get { return screenType; }
                set { screenType = value; }
            }
            #endregion
            
            #region SecretControl
            /// <summary>
            /// This property gets or sets the value for 'SecretControl'.
            /// </summary>
            public SecretComponent SecretControl
            {
                get { return secretControl; }
                set { secretControl = value; }
            }
            #endregion
            
            #region SessionId
            /// <summary>
            /// This read only property returns the value of SessionId from the object MainLayout.
            /// </summary>
            public string SessionId
            {
                
                get
                {
                    // initial value
                    string sessionId = "";
                    
                    // if MainLayout exists
                    if (HasMainLayout)
                    {
                        // set the return value
                        sessionId = MainLayout.SessionId;
                    }
                    
                    // return value
                    return sessionId;
                }
            }
            #endregion
            
            #region StatusLabel
            /// <summary>
            /// This property gets or sets the value for 'StatusLabel'.
            /// </summary>
            public Label StatusLabel
            {
                get { return statusLabel; }
                set { statusLabel = value; }
            }
            #endregion
            
            #region TimeComponent
            /// <summary>
            /// This property gets or sets the value for 'TimeComponent'.
            /// </summary>
            public TimeComponent TimeComponent
            {
                get { return timeComponent; }
                set { timeComponent = value; }
            }
            #endregion
            
            #region Title
            /// <summary>
            /// This property gets or sets the value for 'Title'.
            /// </summary>
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
