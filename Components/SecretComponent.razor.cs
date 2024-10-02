

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using Microsoft.AspNetCore.Components;
using NTouch.Pages;
using ObjectLibrary.Enumerations;

#endregion

namespace NTouch.Components
{

    #region class SecretComponent
    /// <summary>
    /// This class is a demo, only purpose is to demonstrate IBlazorComponent and IBlazorComponentParent interfaces
    /// </summary>
    public partial class SecretComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string name;
        private TextBoxComponent secretControl;
        private IBlazorComponentParent parent;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SecretComponent' object.
        /// </summary>
        public SecretComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region BackToContactEditor()
            /// <summary>
            /// Back To Contact Editor
            /// </summary>
            public void BackToContactEditor()
            {
                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // Back to the Contact Editor
                    ParentIndexPage.ScreenType = ScreenTypeEnum.EditContact;

                    // Update the UI
                    ParentIndexPage.Refresh();
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // Find the Child By Name
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
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
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // If this component is a TextBoxComponent
                if (component is TextBoxComponent)
                {
                    // store
                    SecretControl = component as TextBoxComponent;

                    // Display the Session Id
                    if (HasSecretControl)
                    {
                        // Display the value
                        SecretControl.SetTextValue(SessionId);
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
                
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                        
                    // return value
                    return hasChildren;
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
                
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
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
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
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
                    // set the parent
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
                
            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value of ParentIndexPage from the object Parent.
            /// </summary>
            public IndexPage ParentIndexPage
            {
                
                get
                {
                    // initial value
                    IndexPage parentIndexPage = null;
                    
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        parentIndexPage = Parent as IndexPage;
                    }
                    
                    // return value
                    return parentIndexPage;
                }
            }
            #endregion
            
            #region SecretControl
            /// <summary>
            /// This property gets or sets the value for 'SecretControl'.
            /// </summary>
            public TextBoxComponent SecretControl
            {
                get { return secretControl; }
                set { secretControl = value; }
            }
            #endregion
            
            #region SessionId
            /// <summary>
            /// This read only property returns the value of SessionId from the object ParentIndexPage.
            /// </summary>
            public string SessionId
            {
                
                get
                {
                    // initial value
                    string sessionId = "";
                    
                    // if ParentIndexPage exists
                    if (ParentIndexPage != null)
                    {
                        // set the return value
                        sessionId = ParentIndexPage.SessionId;
                    }
                    
                    // return value
                    return sessionId;
                }
            }
            #endregion
            
        #endregion
            
    }
    #endregion
    
}
