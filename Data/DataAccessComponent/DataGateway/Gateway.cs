
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Data;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteContact(int id, Contact tempContact = null)
            /// <summary>
            /// This method is used to delete Contact objects.
            /// </summary>
            /// <param name="id">Delete the Contact with this id</param>
            /// <param name="tempContact">Pass in a tempContact to perform a custom delete.</param>
            public bool DeleteContact(int id, Contact tempContact = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempContact does not exist
                    if (tempContact == null)
                    {
                        // create a temp Contact
                        tempContact = new Contact();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempContact.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.ContactController.Delete(tempContact);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteContactPreference(int id, ContactPreference tempContactPreference = null)
            /// <summary>
            /// This method is used to delete ContactPreference objects.
            /// </summary>
            /// <param name="id">Delete the ContactPreference with this id</param>
            /// <param name="tempContactPreference">Pass in a tempContactPreference to perform a custom delete.</param>
            public bool DeleteContactPreference(int id, ContactPreference tempContactPreference = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempContactPreference does not exist
                    if (tempContactPreference == null)
                    {
                        // create a temp ContactPreference
                        tempContactPreference = new ContactPreference();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempContactPreference.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.ContactPreferenceController.Delete(tempContactPreference);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
                #region DeleteContactPreferenceByContactId(int contactId)
                /// <summary>
                /// This method is used to delete 'ContactPreference' objects for the ContactId given.
                /// </summary>
                public bool DeleteContactPreferenceByContactId(int contactId)
                {
                    // initial value
                    bool deleted = false;
                    
                    // Create a temp ContactPreference object
                    ContactPreference tempContactPreference = new ContactPreference();
                    
                    // Set the value for DeleteByContactId to true
                    tempContactPreference.DeleteByContactId = true;
                    
                    // Set the value for ContactId
                    tempContactPreference.ContactId = contactId;
                    
                    // Perform the delete
                    deleted = DeleteContactPreference(0, tempContactPreference);
                    
                    // return value
                    return deleted;
                }
                #endregion
                
            #region DeleteState(int id, State tempState = null)
            /// <summary>
            /// This method is used to delete State objects.
            /// </summary>
            /// <param name="id">Delete the State with this id</param>
            /// <param name="tempState">Pass in a tempState to perform a custom delete.</param>
            public bool DeleteState(int id, State tempState = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempState does not exist
                    if (tempState == null)
                    {
                        // create a temp State
                        tempState = new State();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempState.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StateController.Delete(tempState);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindContact(int id, Contact tempContact = null)
            /// <summary>
            /// This method is used to find 'Contact' objects.
            /// </summary>
            /// <param name="id">Find the Contact with this id</param>
            /// <param name="tempContact">Pass in a tempContact to perform a custom find.</param>
            public Contact FindContact(int id, Contact tempContact = null)
            {
                // initial value
                Contact contact = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempContact does not exist
                    if (tempContact == null)
                    {
                        // create a temp Contact
                        tempContact = new Contact();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempContact.UpdateIdentity(id);
                    }

                    // perform the find
                    contact = this.AppController.ControllerManager.ContactController.Find(tempContact);
                }

                // return value
                return contact;
            }
            #endregion

            #region FindContactPreference(int id, ContactPreference tempContactPreference = null)
            /// <summary>
            /// This method is used to find 'ContactPreference' objects.
            /// </summary>
            /// <param name="id">Find the ContactPreference with this id</param>
            /// <param name="tempContactPreference">Pass in a tempContactPreference to perform a custom find.</param>
            public ContactPreference FindContactPreference(int id, ContactPreference tempContactPreference = null)
            {
                // initial value
                ContactPreference contactPreference = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempContactPreference does not exist
                    if (tempContactPreference == null)
                    {
                        // create a temp ContactPreference
                        tempContactPreference = new ContactPreference();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempContactPreference.UpdateIdentity(id);
                    }

                    // perform the find
                    contactPreference = this.AppController.ControllerManager.ContactPreferenceController.Find(tempContactPreference);
                }

                // return value
                return contactPreference;
            }
            #endregion

            #region FindState(int id, State tempState = null)
            /// <summary>
            /// This method is used to find 'State' objects.
            /// </summary>
            /// <param name="id">Find the State with this id</param>
            /// <param name="tempState">Pass in a tempState to perform a custom find.</param>
            public State FindState(int id, State tempState = null)
            {
                // initial value
                State state = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempState does not exist
                    if (tempState == null)
                    {
                        // create a temp State
                        tempState = new State();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempState.UpdateIdentity(id);
                    }

                    // perform the find
                    state = this.AppController.ControllerManager.StateController.Find(tempState);
                }

                // return value
                return state;
            }
            #endregion

                #region FindStateByName(string name)
                /// <summary>
                /// This method is used to find 'State' objects for the Name given.
                /// </summary>
                public State FindStateByName(string name)
                {
                    // initial value
                    State state = null;
                    
                    // Create a temp State object
                    State tempState = new State();
                    
                    // Set the value for FindByName to true
                    tempState.FindByName = true;
                    
                    // Set the value for Name
                    tempState.Name = name;
                    
                    // Perform the find
                    state = FindState(0, tempState);
                    
                    // return value
                    return state;
                }
                #endregion
                
            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadContactPreferences(ContactPreference tempContactPreference = null)
            /// <summary>
            /// This method loads a collection of 'ContactPreference' objects.
            /// </summary>
            public List<ContactPreference> LoadContactPreferences(ContactPreference tempContactPreference = null)
            {
                // initial value
                List<ContactPreference> contactPreferences = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    contactPreferences = this.AppController.ControllerManager.ContactPreferenceController.FetchAll(tempContactPreference);
                }

                // return value
                return contactPreferences;
            }
            #endregion

                #region LoadContactPreferencesForContactId(int contactId)
                /// <summary>
                /// This method is used to load 'ContactPreference' objects for the ContactId given.
                /// </summary>
                public List<ContactPreference> LoadContactPreferencesForContactId(int contactId)
                {
                    // initial value
                    List<ContactPreference> contactPreferences = null;
                    
                    // Create a temp ContactPreference object
                    ContactPreference tempContactPreference = new ContactPreference();
                    
                    // Set the value for LoadByContactId to true
                    tempContactPreference.LoadByContactId = true;
                    
                    // Set the value for ContactId
                    tempContactPreference.ContactId = contactId;
                    
                    // Perform the load
                    contactPreferences = LoadContactPreferences(tempContactPreference);
                    
                    // return value
                    return contactPreferences;
                }
                #endregion
                
            #region LoadContacts(Contact tempContact = null)
            /// <summary>
            /// This method loads a collection of 'Contact' objects.
            /// </summary>
            public List<Contact> LoadContacts(Contact tempContact = null)
            {
                // initial value
                List<Contact> contacts = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    contacts = this.AppController.ControllerManager.ContactController.FetchAll(tempContact);
                }

                // return value
                return contacts;
            }
            #endregion

            #region LoadContactViews(ContactView tempContactView = null)
            /// <summary>
            /// This method loads a collection of 'ContactView' objects.
            /// </summary>
            public List<ContactView> LoadContactViews(ContactView tempContactView = null)
            {
                // initial value
                List<ContactView> contactViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    contactViews = this.AppController.ControllerManager.ContactViewController.FetchAll(tempContactView);
                }

                // return value
                return contactViews;
            }
            #endregion

            #region LoadStates(State tempState = null)
            /// <summary>
            /// This method loads a collection of 'State' objects.
            /// </summary>
            public List<State> LoadStates(State tempState = null)
            {
                // initial value
                List<State> states = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    states = this.AppController.ControllerManager.StateController.FetchAll(tempState);
                }

                // return value
                return states;
            }
            #endregion

            #region SaveContact(ref Contact contact)
            /// <summary>
            /// This method is used to save 'Contact' objects.
            /// </summary>
            /// <param name="contact">The Contact to save.</param>
            public bool SaveContact(ref Contact contact)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.ContactController.Save(ref contact);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveContactPreference(ref ContactPreference contactPreference)
            /// <summary>
            /// This method is used to save 'ContactPreference' objects.
            /// </summary>
            /// <param name="contactPreference">The ContactPreference to save.</param>
            public bool SaveContactPreference(ref ContactPreference contactPreference)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.ContactPreferenceController.Save(ref contactPreference);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveState(ref State state)
            /// <summary>
            /// This method is used to save 'State' objects.
            /// </summary>
            /// <param name="state">The State to save.</param>
            public bool SaveState(ref State state)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StateController.Save(ref state);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

