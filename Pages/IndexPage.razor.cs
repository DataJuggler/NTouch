

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using Microsoft.AspNetCore.Components;
using NTouch.Shared;
using ObjectLibrary.Enumerations;
using ObjectLibrary.BusinessObjects;
using NTouch.Components;

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
                // if the value for HasMainLayout is true
                if (HasMainLayout)
                {
                    // Set the ScreenType
                    MainLayout.ScreenType = ScreenTypeEnum.EditContact;

                    // Update the UI
                    Refresh();
                }
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
            /// This read only property returns the value of ScreenType from the object ParentMainLayout.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                
                get
                {
                    // initial value
                    ScreenTypeEnum screenType = ScreenTypeEnum.ListContacts;
                    
                    // if Parent MainLayout exists
                    if (HasMainLayout)
                    {
                        // set the return value
                        screenType = MainLayout.ScreenType;
                    }
                    
                    // return value
                    return screenType;
                }
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
