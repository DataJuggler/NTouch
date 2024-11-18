

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
using System.Diagnostics;
using NPOI.SS.Formula.Eval;

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
        private TextBoxComponent firstNameControl;
        private TextBoxComponent lastNameControl;
        private TextBoxComponent phoneControl;
        private TextBoxComponent emailControl;
        private TextBoxComponent addressControl;
        private TextBoxComponent cityControl;     
        private TextBoxComponent notesControl;
        private TextBoxComponent zipControl;
        private ComboBox stateComboBox;
        private ComboBox contactPreferencesComboBox;        
        private CalendarComponent lastContactedDateControl;
        private CalendarComponent followUpDateControl;
        private CalendarComponent birthDateControl;
        private ToggleComponent subcriberComponent;
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
                    ParentIndexPage.ScreenType = ScreenTypeEnum.ContactList;

                    // Update the UI
                    ParentIndexPage.Refresh();
                }
            }
            #endregion
            
            #region ConvertContactPreferencesToItems(List<ContactPreference> contactPreferences, List<Item> items)
            /// <summary>
            /// returns a list of Contact Preferences To Items
            /// </summary>
            public static List<Item> ConvertContactPreferencesToItems(List<ContactPreference> contactPreferences, List<Item> items)
            {
                // initial value
                List<Item> selectedItems = new List<Item>();

                // If the items collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(items))
                {
                    // Iterate the collection of ContactPreference objects
                    foreach (ContactPreference contactPreference in contactPreferences)
                    {
                        // attempt to find this item
                        int contactMethodId = (int) contactPreference.ContactMethod;
                        Item selectedItem = ItemHelper.FindItemById(items, contactMethodId);

                        // If the selectedItem object exists
                        if (NullHelper.Exists(selectedItem))
                        {
                            // Select this item
                            selectedItem.ItemChecked = true;

                            // Add this item
                            selectedItems.Add(selectedItem);
                        }
                    }
                }
                
                // return value
                return selectedItems;
            }
            #endregion
            
            #region DisplaySelectedContact()
            /// <summary>
            /// Display Selected Contact
            /// </summary>
            public void DisplaySelectedContact()
            {
                // initial values
                string firstName = "";
                string lastName = "";
                string phoneNumber = "";
                string email = "";
                string address = "";
                string city = "";
                string stateName = "";
                string zip = "";
                string notes = "";
                DateTime birthDate = new DateTime();
                bool subscriber = false;

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(Connection.Name);

                // if the SelectedContact exists
                if (HasSelectedContact)
                {
                    // Set the Title
                    Title = "Edit Contact";

                    // Load the contact preferences
                    List<ContactPreference> contactPreferences = gateway.LoadContactPreferencesForContactId(SelectedContact.Id);

                    // If the contactPreferences collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(contactPreferences))
                    {
                        // if the value for HasContactPreferencesComboBox is true and the ComboBox has Items
                        if ((HasContactPreferencesComboBox) && (ContactPreferencesComboBox.HasItems))
                        {
                            // Load the Items used by the ComboBox
                            List<Item> items = ItemHelper.LoadItems(typeof(ContactMethodEnum));

                            // Get the SelectedItems
                            List<Item> selectedItems = ConvertContactPreferencesToItems(contactPreferences, items);

                            // If the selectedItems collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(selectedItems))
                            {
                                // Set the selected items
                                ContactPreferencesComboBox.SetSelectedItems(selectedItems);
                            }
                        }
                    }

                    // Set the values
                    firstName = SelectedContact.FirstName;
                    lastName = SelectedContact.LastName;
                    phoneNumber = SelectedContact.PhoneNumber;
                    email = SelectedContact.EmailAddress;
                    address = SelectedContact.Address;
                    city = SelectedContact.City;
                    zip = SelectedContact.ZipCode;
                    notes = SelectedContact.Notes;
                    birthDate = SelectedContact.BirthDate;
                    subscriber = SelectedContact.Subscriber;

                    // if the StateId is set
                    if (SelectedContact.StateId > 0)
                    {
                        // find the State
                        State state = gateway.FindState(SelectedContact.StateId);

                        // If the state object exists
                        if (NullHelper.Exists(state))
                        {
                            // Set the stateName
                            stateName = state.Name;
                        }
                    }
                }

                // if the value for HasFirstNameControl is true
                if (HasFirstNameControl)
                {
                    // Display firstName
                    FirstNameControl.SetTextValue(firstName);
                }

                // if the value for HasLastNameControl is true
                if (HasLastNameControl)
                {
                    // Display LastName
                    LastNameControl.SetTextValue(lastName);
                }

                // if the value for HasPhoneControl is true
                if (HasPhoneControl)
                {
                    // Display Phone
                    PhoneControl.SetTextValue(phoneNumber);
                }

                // if the value for HasEmailControl is true
                if (HasEmailControl)
                {
                    // Display Email
                    EmailControl.SetTextValue(email);
                }

                // if the value for HasAddressControl is true
                if (HasAddressControl)
                {
                    // Display Address
                    AddressControl.SetTextValue(address);
                }

                // if the value for HasCityControl is true
                if (HasCityControl)
                {
                    // Display City
                    CityControl.SetTextValue(city);
                }

                // if the value for HasStateComboBox is true
                if (HasStateComboBox)
                {
                    // Set the selected text
                    StateComboBox.SetSelectedItem(stateName);
                }
                
                // if the value for HasZipControl is true
                if (HasZipControl)
                {
                    // Display Zip
                    ZipControl.SetTextValue(zip);
                }

                // if the value for HasNotesControl is true
                if (HasNotesControl)
                {
                    // Display Notes
                    NotesControl.SetTextValue(notes);
                }

                // if the value for HasLastContactedDateControl is true
                if (HasLastContactedDateControl)
                {
                    // if a real date
                    if (SelectedContact.LastContactDate.Year > 1900)
                    {
                        // Set the SelectedDate
                        LastContactedDateControl.SetSelectedDate(SelectedContact.LastContactDate);
                    }
                }

                // if the value for HasFollowUpDateControl is true
                if (HasFollowUpDateControl)
                {
                    // if a real date
                    if (SelectedContact.FollowUpDate.Year > 1900)
                    {
                        // Set the SelectedDate
                        FollowUpDateControl.SetSelectedDate(SelectedContact.FollowUpDate);
                    }
                }

                // if the value for HasBirthDateControl is true
                if (HasBirthDateControl)
                {
                    // if a real date
                    if (birthDate.Year > 1900)
                    {
                        // Set the SelectedDate
                        BirthDateControl.SetSelectedDate(birthDate);
                    }
                }

                // if the value for HasSubcriberComponent is true
                if (HasSubcriberComponent)
                {
                    // Set the value for On
                    SubcriberComponent.SetOnValue(subscriber);
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

            #region FormatPhoneNumber(string number)
            /// <summary>
            /// returns the Phone Number
            /// </summary>
            public string FormatPhoneNumber(string number)
            {
                // initial value               
                string phone = number;

                // for now, just enter 9 digits and this works as long as I do it
                string numbersOnly = NumericHelper.GetNumbersOnly(number);

                // if 9 digits
                if (numbersOnly.Length >= 9)
                {
                    phone = "(" + numbersOnly.Substring(0, 3) + ") " + numbersOnly.Substring(3, 3) + "-" + numbersOnly.Substring(6);
                }
                    
                // return value
                return phone;
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
                if (component is TextBoxComponent)
                {
                    if (component.Name == "FirstNameControl")
                    {
                        // Store
                        FirstNameControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "LastNameControl")
                    {
                        // Store
                        LastNameControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "PhoneControl")
                    {
                        // Store
                        PhoneControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "EmailControl")
                    {
                        // Store
                        EmailControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "AddressControl")
                    {
                        // Store
                        AddressControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "CityControl")
                    {
                        // Store
                        CityControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "ZipControl")
                    {
                        // Store
                        ZipControl = component as TextBoxComponent;
                    }
                    else if (component.Name == "NotesControl")
                    {
                        // Store
                        NotesControl = component as TextBoxComponent;
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
                    else if (component.Name == "BirthDateControl")
                    {
                        // Store
                        BirthDateControl = component as CalendarComponent;
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
                        }

                        // if the value for HasSelectedContact is true
                        if ((HasSelectedContact) && (ScreenType == ScreenTypeEnum.EditContact))
                        {
                            // Display the SelectedContact
                            DisplaySelectedContact();
                        }
                    }
                }
                else if (component is ToggleComponent)
                {
                    // Store
                    SubcriberComponent = component as ToggleComponent;
                }
            }
            #endregion

            #region Save()
            /// <summary>
            /// Save
            /// </summary>
            public void Save()
            {
                // if the value for HasSelectedContact is true
                if (HasSelectedContact)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(Connection.Name);

                    // is this a new record
                    bool isNew = SelectedContact.IsNew;
                    int savedContactPreferences = 0;

                    // Create a new instance of a 'Contact' object.
                    Contact contact = SelectedContact;

                    // set each property
                    contact.FirstName = FirstNameControl.Text;
                    contact.LastName = LastNameControl.Text;
                    contact.PhoneNumber = FormatPhoneNumber(PhoneControl.Text);
                    contact.EmailAddress = EmailControl.Text;
                    contact.Address = AddressControl.Text;
                    contact.City = CityControl.Text;

                    // If the value for the property StateComboBox.HasSelectedText is true
                    if (StateComboBox.HasSelectedText)
                    {
                        // Get the StateName
                        string stateName = StateComboBox.SelectedText;

                        // If the stateName string exists
                        if (TextHelper.Exists(stateName))
                        {
                            // Find the state by name
                            State state = gateway.FindStateByName(stateName);

                            // If the state object exists
                            if (NullHelper.Exists(state))
                            {
                                // Set the StateId
                                contact.StateId = state.Id;
                            }
                        }
                    }

                    contact.ZipCode = ZipControl.Text;
                    contact.LastContactDate = LastContactedDateControl.SelectedDate;
                    contact.FollowUpDate = FollowUpDateControl.SelectedDate;

                    // if the value for HasBirthDateControl is true
                    if (HasBirthDateControl)
                    {
                        // Store
                        contact.BirthDate = BirthDateControl.SelectedDate;
                    }
                    
                    // if On
                    if (HasSubcriberComponent)
                    {
                        // It it currently On or Off
                        contact.Subscriber = SubcriberComponent.On;
                    }

                    contact.CreatedDate = DateTime.Now;
                    contact.ImagePath = SelectedContactImagePath;
                    contact.Notes = NotesControl.Text;

                    // perform the save
                    bool saved = gateway.SaveContact(ref contact);

                    // if the value for saved is true
                    if (saved)
                    {
                        // if the value for HasContactPreferencesComboBox is true
                        if (HasContactPreferencesComboBox)
                        {
                            // Get the selected items
                            List<Item> selectedItems = ContactPreferencesComboBox.SelectedItems;

                            // if this is an Edit
                            if (ScreenType == ScreenTypeEnum.EditContact)
                            {
                                // Delete the existing ContactPreferences before Saving
                                bool deleted = gateway.DeleteContactPreferenceByContactId(contact.Id);
                            }

                            // if the value for HasParentIndexPage is true
                            if (HasParentIndexPage)
                            {
                                // If the selectedItems collection exists and has one or more items
                                if (ListHelper.HasOneOrMoreItems(selectedItems))
                                {
                                    // Iterate the collection of Item objects
                                    foreach (Item item in selectedItems)
                                    {
                                        // if selected
                                        if (item.ItemChecked)
                                        {
                                            // Create a new instance of a 'ContactPreference' object.
                                            ContactPreference contactPreference = new ContactPreference();

                                            // set the ContactId
                                            contactPreference.ContactId = contact.Id;

                                            // Set the ContactMethod
                                            contactPreference.ContactMethod = (ContactMethodEnum) item.Id;

                                            // save
                                            saved = gateway.SaveContactPreference(ref contactPreference);

                                            // if the value for saved is true
                                            if (saved)
                                            {
                                                // Increment the value for savedContactPreferences
                                                savedContactPreferences++;
                                            }
                                        }
                                    }

                                    // if the StatusLabel exists
                                    if (ParentIndexPage.HasStatusLabel)
                                    {
                                        ParentIndexPage.StatusLabel.SetTextValue(savedContactPreferences.ToString() + " saved.");
                                    }
                                }

                                // Set the screen
                                ParentIndexPage.ScreenType = ScreenTypeEnum.ContactList;

                                // Update the page
                                ParentIndexPage.Refresh();
                            }
                        }
                    }
                    else
                    {
                        // Get the last exception
                        Exception error = gateway.GetLastException();

                        // if the StatusLabel exists
                        if (ParentIndexPage.HasStatusLabel)
                        {
                            ParentIndexPage.StatusLabel.SetTextValue("Error.");
                        }
                    }
                }
            }
            #endregion
            
            #region ViewSecret()
            /// <summary>
            /// View Secret
            /// </summary>
            public void ViewSecret()
            {
                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // Switch to View Secret mode
                    ParentIndexPage.ScreenType = ScreenTypeEnum.ViewSecret;

                    // Update the UI
                    ParentIndexPage.Refresh();
                }
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region AddressControl
            /// <summary>
            /// This property gets or sets the value for 'AddressControl'.
            /// </summary>
            public TextBoxComponent AddressControl
            {
                get { return addressControl; }
                set { addressControl = value; }
            }
            #endregion
            
            #region BirthDateControl
            /// <summary>
            /// This property gets or sets the value for 'BirthDateControl'.
            /// </summary>            
            public CalendarComponent BirthDateControl
            {
                get { return birthDateControl; }
                set { birthDateControl = value; }
            }
            #endregion
            
            #region ButtonText
            /// <summary>
            /// This read only property returns the value of ButtonText. It is either Upload or Change
            /// </summary>
            public string ButtonText
            {
                
                get
                {
                    // initial value
                    string buttonText = "Upload";
                    
                    // if there is an already an image path
                    if (TextHelper.Exists(SelectedContactImagePath))
                    {
                        // Switch to Change
                        buttonText = "Change";
                    }
                    
                    // return value
                    return buttonText;
                }
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
            public TextBoxComponent CityControl
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
            public TextBoxComponent EmailControl
            {
                get { return emailControl; }
                set { emailControl = value; }
            }
            #endregion
            
            #region FirstNameControl
            /// <summary>
            /// This property gets or sets the value for 'FirstNameControl'.
            /// </summary>
            public TextBoxComponent FirstNameControl
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
            
            #region HasAddressControl
            /// <summary>
            /// This property returns true if this object has an 'AddressControl'.
            /// </summary>
            public bool HasAddressControl
            {
                get
                {
                    // initial value
                    bool hasAddressControl = (this.AddressControl != null);
                    
                    // return value
                    return hasAddressControl;
                }
            }
            #endregion
            
            #region HasBirthDateControl
            /// <summary>
            /// This property returns true if this object has a 'BirthDateControl'.
            /// </summary>
            public bool HasBirthDateControl
            {
                get
                {
                    // initial value
                    bool hasBirthDateControl = (this.BirthDateControl != null);
                    
                    // return value
                    return hasBirthDateControl;
                }
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
            
            #region HasCityControl
            /// <summary>
            /// This property returns true if this object has a 'CityControl'.
            /// </summary>
            public bool HasCityControl
            {
                get
                {
                    // initial value
                    bool hasCityControl = (this.CityControl != null);
                    
                    // return value
                    return hasCityControl;
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
            
            #region HasEmailControl
            /// <summary>
            /// This property returns true if this object has an 'EmailControl'.
            /// </summary>
            public bool HasEmailControl
            {
                get
                {
                    // initial value
                    bool hasEmailControl = (this.EmailControl != null);
                    
                    // return value
                    return hasEmailControl;
                }
            }
            #endregion
            
            #region HasFirstNameControl
            /// <summary>
            /// This property returns true if this object has a 'FirstNameControl'.
            /// </summary>
            public bool HasFirstNameControl
            {
                get
                {
                    // initial value
                    bool hasFirstNameControl = (this.FirstNameControl != null);
                    
                    // return value
                    return hasFirstNameControl;
                }
            }
            #endregion
            
            #region HasFollowUpDateControl
            /// <summary>
            /// This property returns true if this object has a 'FollowUpDateControl'.
            /// </summary>
            public bool HasFollowUpDateControl
            {
                get
                {
                    // initial value
                    bool hasFollowUpDateControl = (this.FollowUpDateControl != null);
                    
                    // return value
                    return hasFollowUpDateControl;
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
            
            #region HasLastNameControl
            /// <summary>
            /// This property returns true if this object has a 'LastNameControl'.
            /// </summary>
            public bool HasLastNameControl
            {
                get
                {
                    // initial value
                    bool hasLastNameControl = (this.LastNameControl != null);
                    
                    // return value
                    return hasLastNameControl;
                }
            }
            #endregion
            
            #region HasNotesControl
            /// <summary>
            /// This property returns true if this object has a 'NotesControl'.
            /// </summary>
            public bool HasNotesControl
            {
                get
                {
                    // initial value
                    bool hasNotesControl = (this.NotesControl != null);
                    
                    // return value
                    return hasNotesControl;
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
            
            #region HasPhoneControl
            /// <summary>
            /// This property returns true if this object has a 'PhoneControl'.
            /// </summary>
            public bool HasPhoneControl
            {
                get
                {
                    // initial value
                    bool hasPhoneControl = (this.PhoneControl != null);
                    
                    // return value
                    return hasPhoneControl;
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
            
            #region HasSubcriberComponent
            /// <summary>
            /// This property returns true if this object has a 'SubcriberComponent'.
            /// </summary>
            public bool HasSubcriberComponent
            {
                get
                {
                    // initial value
                    bool hasSubcriberComponent = (this.SubcriberComponent != null);
                    
                    // return value
                    return hasSubcriberComponent;
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
            public TextBoxComponent LastNameControl
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
            public TextBoxComponent NotesControl
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
            public TextBoxComponent PhoneControl
            {
                get { return phoneControl; }
                set { phoneControl = value; }
            }
            #endregion
            
            #region ScreenType
            /// <summary>
            /// This read only property returns the value of ScreenType from the object ParentIndexPage.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                
                get
                {
                    // initial value
                    ScreenTypeEnum screenType = ScreenTypeEnum.ContactList;
                    
                    // if ParentIndexPage exists
                    if (HasParentIndexPage)
                    {
                        // set the return value
                        screenType = ParentIndexPage.ScreenType;
                    }
                    
                    // return value
                    return screenType;
                }
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
            
            #region SubcriberComponent
            /// <summary>
            /// This property gets or sets the value for 'SubcriberComponent'.
            /// </summary>
            public ToggleComponent SubcriberComponent
            {
                get { return subcriberComponent; }
                set { subcriberComponent = value; }
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
            public TextBoxComponent ZipControl
            {
                get { return zipControl; }
                set { zipControl = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion
}