

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NTouch.Pages;
using ObjectLibrary.Enumerations;
using DataAccessComponent.DataGateway;
using DataAccessComponent.Connection;
using DataJuggler.NET8;
using DataJuggler.NET8.Enumerations;
using ObjectLibrary.BusinessObjects;
using System.Xml.Serialization;
using DataJuggler.Blazor.FileUpload;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

#endregion

namespace NTouch.Components
{

    #region class ContactEditor
    /// <summary>
    /// This class is used to add or edit contacts
    /// </summary>
    public partial class ContactEditor : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private List<IBlazorComponent> children;
        private ValidationComponent firstNameControl;
        private ValidationComponent lastNameControl;
        private ValidationComponent phoneControl;
        private ValidationComponent emailControl;
        private ValidationComponent addressControl;
        private ValidationComponent cityControl;        
        private ComboBox stateComboBox;
        private ComboBox contactPreferencesComboBox;
        private ValidationComponent zipControl;
        private CalendarComponent lastContactedDateControl;
        private CalendarComponent followUpDateControl;
        private ValidationComponent notesControl;
        private string title;
        private Contact selectedContact;
        private string uploadButtonStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an EditContact component
        /// </summary>
        public ContactEditor()
        {
            // Setup the Title
            Title = "Add Contact";
        }
        #endregion

        #region Methods
            
            #region Cancel()
            /// <summary>
            /// Cancel
            /// </summary>
            public void Cancel()
            {
                if (HasParentIndexPage)
                {
                    // Set the Index Page
                    ParentIndexPage.ScreenType = ScreenTypeEnum.IndexPage;

                    // Update the UI
                    ParentIndexPage.Refresh();
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

            #region OnFileUploaded(UploadedFileInfo file)
            /// <summary>
            /// This method On File Uploaded
            /// </summary>
            public void OnFileUploaded(UploadedFileInfo file)
            {
                // if the file was uploaded
                if (!file.Aborted)
                {
                   // To Do: Save the uploaded file
                   string fileName = file.FullName;

                   // if the value for HasSelectedContact is true
                   if (HasSelectedContact)
                   {
                        // Create a fileInfo object
                        FileInfo fileInfo = new FileInfo(fileName);

                        // Set th ImagePath
                        SelectedContact.ImagePath = "../Upload/" + System.Web.HttpUtility.UrlPathEncode(fileInfo.Name);
                   }
                }
                else
                {
                    if (file.HasException)
                    {
                        string exception = file.Exception.ToString();
                    }
                    // To Do; Show Error Message
                }
            }
            #endregion
            
            #region OnReset()
            /// <summary>
            /// On Reset
            /// </summary>
            public void OnReset()
            {
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                if (NullHelper.Exists(message))
                {
                    if (message.Text.Contains("text"))
                    {
                        // get the key pressed
                        string keyPressed = message.Text.Replace("text: Key", "");

                        // Filter the list of items
                        
                    }   
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
                if (component is ValidationComponent)
                {
                    if (component.Name == "FirstNameControl")
                    {
                        // Store
                        FirstNameControl = component as ValidationComponent;
                    }
                    else if (component.Name == "LastNameControl")
                    {
                        // Store
                        LastNameControl = component as ValidationComponent;
                    }
                    else if (component.Name == "PhoneControl")
                    {
                        // Store
                        PhoneControl = component as ValidationComponent;
                    }
                    else if (component.Name == "EmailControl")
                    {
                        // Store
                        EmailControl = component as ValidationComponent;
                    }
                    else if (component.Name == "AddressControl")
                    {
                        // Store
                        AddressControl = component as ValidationComponent;
                    }
                    else if (component.Name == "CityControl")
                    {
                        // Store
                        CityControl = component as ValidationComponent;
                    }
                    else if (component.Name == "ZipControl")
                    {
                        // Store
                        ZipControl = component as ValidationComponent;
                    }
                     else if (component.Name == "NotesControl")
                    {
                        // Store
                        NotesControl = component as ValidationComponent;
                    }
                }
                else if (component is CalendarComponent)
                {
                    if (component.Name == "LastContactedDateControl")
                    {
                        // Store
                        LastContactedDateControl = component as CalendarComponent;
                    }
                    else if (component.Name == "FollowUpDateControl")
                    {
                        // Store
                        FollowUpDateControl = component as CalendarComponent;
                    }
                }
                else if (component is ComboBox)
                {
                    if (component.Name == "StateComboBox")
                    {
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway(Connection.Name);

                        // load the States
                        List<State> states = gateway.LoadStates();

                        // Store
                        StateComboBox = component as ComboBox;

                        // if the value for HasStateComboBox is true
                        if (HasStateComboBox)
                        {
                            // Load the ComboBox
                            StateComboBox.LoadItems(states);                        
                        }
                    }
                    else if (component.Name == "ContactPreferencesComboBox")
                    {
                        // Store
                        ContactPreferencesComboBox = component as ComboBox;

                        // if the value for HasContactPreferencesComboBox is true
                        if (HasContactPreferencesComboBox)
                        {
                            // Load the choices
                            ContactPreferencesComboBox.LoadItems(typeof(ContactMethodEnum));

                            // Edit mode is different, must reselect choices
                        }
                    }
                }
            }
            #endregion

            #region Save()
            /// <summary>
            /// Save
            /// </summary>
            public void Save()
            {
                // Create a new instance of a 'Contact' object.
                Contact contact = new Contact();

                // set each property
                contact.FirstName = FirstNameControl.Text;
                contact.LastName = LastNameControl.Text;
                contact.PhoneNumber = PhoneControl.Text;
                contact.EmailAddress = EmailControl.Text;
                contact.Address = AddressControl.Text;
                contact.City = CityControl.Text;
                contact.StateId = StateComboBox.SelectedItem.Id;
                contact.ZipCode = ZipControl.Text;
                contact.LastContactDate = LastContactedDateControl.SelectedDate;
                contact.FollowUpDate = FollowUpDateControl.SelectedDate;
                contact.CreatedDate = DateTime.Now;
            }
            #endregion
            
            #region Cancel(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Cancel
            /// </summary>
            public void Cancel(object sender, EventArgs e)
            {
                
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region AddressControl
            /// <summary>
            /// This property gets or sets the value for 'AddressControl'.
            /// </summary>
            public ValidationComponent AddressControl
            {
                get { return addressControl; }
                set { addressControl = value; }
            }
            #endregion
            
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
            
            #region CityControl
            /// <summary>
            /// This property gets or sets the value for 'CityControl'.
            /// </summary>
            public ValidationComponent CityControl
            {
                get { return cityControl; }
                set { cityControl = value; }
            }
            #endregion
            
            #region ContactPreferencesComboBox
            /// <summary>
            /// This property gets or sets the value for 'ContactPreferencesComboBox'.
            /// </summary>
            public ComboBox ContactPreferencesComboBox
            {
                get { return contactPreferencesComboBox; }
                set { contactPreferencesComboBox = value; }
            }
            #endregion
            
            #region EmailControl
            /// <summary>
            /// This property gets or sets the value for 'EmailControl'.
            /// </summary>
            public ValidationComponent EmailControl
            {
                get { return emailControl; }
                set { emailControl = value; }
            }
            #endregion
            
            #region FirstNameControl
            /// <summary>
            /// This property gets or sets the value for 'FirstNameControl'.
            /// </summary>
            public ValidationComponent FirstNameControl
            {
                get { return firstNameControl; }
                set { firstNameControl = value; }
            }
            #endregion
            
            #region FollowUpCalendarControl
            /// <summary>
            /// This property gets or sets the value for 'FollowUpCalendarControl'.
            /// </summary>
            public CalendarComponent FollowUpDateControl
            {
                get { return followUpDateControl; }
                set { followUpDateControl = value; }
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
            
            #region HasContactPreferencesComboBox
            /// <summary>
            /// This property returns true if this object has a 'ContactPreferencesComboBox'.
            /// </summary>
            public bool HasContactPreferencesComboBox
            {
                get
                {
                    // initial value
                    bool hasContactPreferencesComboBox = (this.ContactPreferencesComboBox != null);
                    
                    // return value
                    return hasContactPreferencesComboBox;
                }
            }
            #endregion
            
            #region HasLastContactedDateControl
            /// <summary>
            /// This property returns true if this object has a 'LastContactedDateControl'.
            /// </summary>
            public bool HasLastContactedDateControl
            {
                get
                {
                    // initial value
                    bool hasLastContactedDateControl = (this.LastContactedDateControl != null);
                    
                    // return value
                    return hasLastContactedDateControl;
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
            
            #region HasSelectedContact
            /// <summary>
            /// This property returns true if this object has a 'SelectedContact'.
            /// </summary>
            public bool HasSelectedContact
            {
                get
                {
                    // initial value
                    bool hasSelectedContact = (this.SelectedContact != null);
                    
                    // return value
                    return hasSelectedContact;
                }
            }
            #endregion
            
            #region HasStateComboBox
            /// <summary>
            /// This property returns true if this object has a 'StateComboBox'.
            /// </summary>
            public bool HasStateComboBox
            {
                get
                {
                    // initial value
                    bool hasStateComboBox = (this.StateComboBox != null);
                    
                    // return value
                    return hasStateComboBox;
                }
            }
            #endregion
            
            #region HasZipControl
            /// <summary>
            /// This property returns true if this object has a 'ZipControl'.
            /// </summary>
            public bool HasZipControl
            {
                get
                {
                    // initial value
                    bool hasZipControl = (this.ZipControl != null);
                    
                    // return value
                    return hasZipControl;
                }
            }
            #endregion
            
            #region LastContactedDateControl
            /// <summary>
            /// This property gets or sets the value for 'LastContactedDateControl'.
            /// </summary>
            public CalendarComponent LastContactedDateControl
            {
                get { return lastContactedDateControl; }
                set { lastContactedDateControl = value; }
            }
            #endregion
            
            #region LastNameControl
            /// <summary>
            /// This property gets or sets the value for 'LastNameControl'.
            /// </summary>
            public ValidationComponent LastNameControl
            {
                get { return lastNameControl; }
                set { lastNameControl = value; }
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
            
            #region NotesControl
            /// <summary>
            /// This property gets or sets the value for 'NotesControl'.
            /// </summary>
            public ValidationComponent NotesControl
            {
                get { return notesControl; }
                set { notesControl = value; }
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
                    parent = value;

                    if (HasParent)
                    {
                        // Register witht he parent
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
                    if (HasParent)
                    {
                        // set the return value
                        parentIndexPage = Parent as IndexPage;
                    }
                    
                    // return value
                    return parentIndexPage;
                }
            }
            #endregion
            
            #region PhoneControl
            /// <summary>
            /// This property gets or sets the value for 'PhoneControl'.
            /// </summary>
            public ValidationComponent PhoneControl
            {
                get { return phoneControl; }
                set { phoneControl = value; }
            }
            #endregion
            
            #region SelectedContact
            /// <summary>
            /// This property gets or sets the value for 'SelectedContact'.
            /// </summary>
            public Contact SelectedContact
            {
                get { return selectedContact; }
                set { selectedContact = value; }
            }
            #endregion
            
            #region SelectedContactId
            /// <summary>
            /// This read only property returns the value of SelectedContactId from the object SelectedContact.
            /// </summary>
            public int SelectedContactId
            {
                
                get
                {
                    // initial value
                    int selectedContactId = 0;

                    // if the value for HasSelectedContact is true
                    if (HasSelectedContact)
                    {
                        // Set the return value
                        selectedContactId = SelectedContact.Id;
                    }
                    
                    // return value
                    return selectedContactId;
                }
            }
            #endregion
            
            #region SelectedContactImagePath
            /// <summary>
            /// This read only property returns the value of SelectedContactImagePath from the object SelectedContact.
            /// </summary>
            public string SelectedContactImagePath
            {
                
                get
                {
                    // initial value
                    string selectedContactImagePath = "";
                    
                    // if SelectedContact exists
                    if (HasSelectedContact)
                    {
                        // set the return value
                        selectedContactImagePath = SelectedContact.ImagePath;
                    }
                    
                    // return value
                    return selectedContactImagePath;
                }
            }
            #endregion
            
            #region StateComboBox
            /// <summary>
            /// This property gets or sets the value for 'StateComboBox'.
            /// </summary>
            public ComboBox StateComboBox
            {
                get { return stateComboBox; }
                set { stateComboBox = value; }
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
            
            #region UploadButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'UploadButtonStyle'.
            /// </summary>
            public string UploadButtonStyle
            {
                get { return uploadButtonStyle; }
                set { uploadButtonStyle = value; }
            }
            #endregion
            
            #region ZipControl
            /// <summary>
            /// This property gets or sets the value for 'ZipControl'.
            /// </summary>
            public ValidationComponent ZipControl
            {
                get { return zipControl; }
                set { zipControl = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion
}