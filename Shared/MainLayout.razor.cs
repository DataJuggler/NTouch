

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using NTouch.Pages;

#endregion

namespace NTouch.Shared
{

    #region class MainLayout
    /// <summary>
    /// This class is the top level parent of this app
    /// </summary>
    public partial class MainLayout : IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private IndexPage indexPage;
        private string sessionId;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a MainLayout object
        /// </summary>
        public MainLayout()
        {
            // Create a new collection of 'IBlazorComponentParent' objects.
            Children = new List<IBlazorComponent>();
        }
        #endregion
        
        #region Methods
            
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
                // if this is an IndexPage
                if (component is IndexPage)
                {
                    // Store
                    IndexPage = component as IndexPage;
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
            
            #region HasIndexPage
            /// <summary>
            /// This property returns true if this object has an 'IndexPage'.
            /// </summary>
            public bool HasIndexPage
            {
                get
                {
                    // initial value
                    bool hasIndexPage = (this.IndexPage != null);
                    
                    // return value
                    return hasIndexPage;
                }
            }
            #endregion
            
            #region HasSessionId
            /// <summary>
            /// This property returns true if the 'SessionId' exists.
            /// </summary>
            public bool HasSessionId
            {
                get
                {
                    // initial value
                    bool hasSessionId = (!String.IsNullOrEmpty(this.SessionId));
                    
                    // return value
                    return hasSessionId;
                }
            }
            #endregion
            
            #region IndexPage
            /// <summary>
            /// This property gets or sets the value for 'IndexPage'.
            /// </summary>
            public IndexPage IndexPage
            {
                get { return indexPage; }
                set { indexPage = value; }
            }
            #endregion
            
            #region SessionId
            /// <summary>
            /// This property gets or sets the value for 'SessionId'.
            /// </summary>
            public string SessionId
            {
                get { return sessionId; }
                set { sessionId = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
