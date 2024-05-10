

#region using statements

using DataJuggler.Blazor.Components;
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
using DataJuggler.NET8.Enumerations;

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
        private Label statusLabel;
        private ScreenTypeEnum screenType;

        // Test Only
        private CheckedListBox listBox;

        private ValidationComponent firstNameControl;
        private ValidationComponent LastNameControl;
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
        }
        #endregion
        
        #region Methods
            
            #region AddContact()
            /// <summary>
            /// Add Contact
            /// </summary>
            public void AddContact()
            {
                // Set the ScreenType
                ScreenType = ScreenTypeEnum.EditContact;

                // Update the UI
                Refresh();
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
                info.Path = "C:\\Temp\\States.xlsx";
                info.SheetName = "StateList";

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
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
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
                else if (component is CheckedListBox)
                {
                    ListBox = component as CheckedListBox;

                    // if the value for HasListBox is true
                    if (HasListBox)
                    {  
                        // Load the Items for this enum
                        List<Item> items = ItemHelper.LoadItems(typeof(TargetFrameworkEnum));
                        
                        // Set the items on the list box
                        ListBox.SetItems(items);
                    }
                }
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
            
            #region HasListBox
            /// <summary>
            /// This property returns true if this object has a 'ListBox'.
            /// </summary>
            public bool HasListBox
            {
                get
                {
                    // initial value
                    bool hasListBox = (this.ListBox != null);
                    
                    // return value
                    return hasListBox;
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
            
            #region ListBox
            /// <summary>
            /// This property gets or sets the value for 'ListBox'.
            /// </summary>
            public CheckedListBox ListBox
            {
                get { return listBox; }
                set { listBox = value; }
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
