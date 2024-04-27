

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class ContactMethods
    /// <summary>
    /// This class contains methods for modifying a 'Contact' object.
    /// </summary>
    public class ContactMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ContactMethods' object.
        /// </summary>
        public ContactMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteContact(Contact)
            /// <summary>
            /// This method deletes a 'Contact' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Contact' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteContact(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteContactStoredProcedure deleteContactProc = null;

                    // verify the first parameters is a(n) 'Contact'.
                    if (parameters[0].ObjectValue as Contact != null)
                    {
                        // Create Contact
                        Contact contact = (Contact) parameters[0].ObjectValue;

                        // verify contact exists
                        if(contact != null)
                        {
                            // Now create deleteContactProc from ContactWriter
                            // The DataWriter converts the 'Contact'
                            // to the SqlParameter[] array needed to delete a 'Contact'.
                            deleteContactProc = ContactWriter.CreateDeleteContactStoredProcedure(contact);
                        }
                    }

                    // Verify deleteContactProc exists
                    if(deleteContactProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ContactManager.DeleteContact(deleteContactProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Contact' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Contact' to delete.
            /// <returns>A PolymorphicObject object with all  'Contacts' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Contact> contactListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllContactsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ContactParameter
                    // Declare Parameter
                    Contact paramContact = null;

                    // verify the first parameters is a(n) 'Contact'.
                    if (parameters[0].ObjectValue as Contact != null)
                    {
                        // Get ContactParameter
                        paramContact = (Contact) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllContactsProc from ContactWriter
                    fetchAllProc = ContactWriter.CreateFetchAllContactsStoredProcedure(paramContact);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    contactListCollection = this.DataManager.ContactManager.FetchAllContacts(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(contactListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = contactListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindContact(Contact)
            /// <summary>
            /// This method finds a 'Contact' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Contact' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindContact(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Contact contact = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindContactStoredProcedure findContactProc = null;

                    // verify the first parameters is a 'Contact'.
                    if (parameters[0].ObjectValue as Contact != null)
                    {
                        // Get ContactParameter
                        Contact paramContact = (Contact) parameters[0].ObjectValue;

                        // verify paramContact exists
                        if(paramContact != null)
                        {
                            // Now create findContactProc from ContactWriter
                            // The DataWriter converts the 'Contact'
                            // to the SqlParameter[] array needed to find a 'Contact'.
                            findContactProc = ContactWriter.CreateFindContactStoredProcedure(paramContact);
                        }

                        // Verify findContactProc exists
                        if(findContactProc != null)
                        {
                            // Execute Find Stored Procedure
                            contact = this.DataManager.ContactManager.FindContact(findContactProc, dataConnector);

                            // if dataObject exists
                            if(contact != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = contact;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertContact (Contact)
            /// <summary>
            /// This method inserts a 'Contact' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Contact' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertContact(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Contact contact = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertContactStoredProcedure insertContactProc = null;

                    // verify the first parameters is a(n) 'Contact'.
                    if (parameters[0].ObjectValue as Contact != null)
                    {
                        // Create Contact Parameter
                        contact = (Contact) parameters[0].ObjectValue;

                        // verify contact exists
                        if(contact != null)
                        {
                            // Now create insertContactProc from ContactWriter
                            // The DataWriter converts the 'Contact'
                            // to the SqlParameter[] array needed to insert a 'Contact'.
                            insertContactProc = ContactWriter.CreateInsertContactStoredProcedure(contact);
                        }

                        // Verify insertContactProc exists
                        if(insertContactProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ContactManager.InsertContact(insertContactProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateContact (Contact)
            /// <summary>
            /// This method updates a 'Contact' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Contact' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateContact(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Contact contact = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateContactStoredProcedure updateContactProc = null;

                    // verify the first parameters is a(n) 'Contact'.
                    if (parameters[0].ObjectValue as Contact != null)
                    {
                        // Create Contact Parameter
                        contact = (Contact) parameters[0].ObjectValue;

                        // verify contact exists
                        if(contact != null)
                        {
                            // Now create updateContactProc from ContactWriter
                            // The DataWriter converts the 'Contact'
                            // to the SqlParameter[] array needed to update a 'Contact'.
                            updateContactProc = ContactWriter.CreateUpdateContactStoredProcedure(contact);
                        }

                        // Verify updateContactProc exists
                        if(updateContactProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ContactManager.UpdateContact(updateContactProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
