

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

    #region class ContactPreferenceMethods
    /// <summary>
    /// This class contains methods for modifying a 'ContactPreference' object.
    /// </summary>
    public class ContactPreferenceMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ContactPreferenceMethods' object.
        /// </summary>
        public ContactPreferenceMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteContactPreference(ContactPreference)
            /// <summary>
            /// This method deletes a 'ContactPreference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactPreference' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteContactPreference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteContactPreferenceStoredProcedure deleteContactPreferenceProc = null;

                    // verify the first parameters is a(n) 'ContactPreference'.
                    if (parameters[0].ObjectValue as ContactPreference != null)
                    {
                        // Create ContactPreference
                        ContactPreference contactPreference = (ContactPreference) parameters[0].ObjectValue;

                        // verify contactPreference exists
                        if(contactPreference != null)
                        {
                            // Now create deleteContactPreferenceProc from ContactPreferenceWriter
                            // The DataWriter converts the 'ContactPreference'
                            // to the SqlParameter[] array needed to delete a 'ContactPreference'.
                            deleteContactPreferenceProc = ContactPreferenceWriter.CreateDeleteContactPreferenceStoredProcedure(contactPreference);
                        }
                    }

                    // Verify deleteContactPreferenceProc exists
                    if(deleteContactPreferenceProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ContactPreferenceManager.DeleteContactPreference(deleteContactPreferenceProc, dataConnector);

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
            /// This method fetches all 'ContactPreference' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactPreference' to delete.
            /// <returns>A PolymorphicObject object with all  'ContactPreferences' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ContactPreference> contactPreferenceListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllContactPreferencesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ContactPreferenceParameter
                    // Declare Parameter
                    ContactPreference paramContactPreference = null;

                    // verify the first parameters is a(n) 'ContactPreference'.
                    if (parameters[0].ObjectValue as ContactPreference != null)
                    {
                        // Get ContactPreferenceParameter
                        paramContactPreference = (ContactPreference) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllContactPreferencesProc from ContactPreferenceWriter
                    fetchAllProc = ContactPreferenceWriter.CreateFetchAllContactPreferencesStoredProcedure(paramContactPreference);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    contactPreferenceListCollection = this.DataManager.ContactPreferenceManager.FetchAllContactPreferences(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(contactPreferenceListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = contactPreferenceListCollection;
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

            #region FindContactPreference(ContactPreference)
            /// <summary>
            /// This method finds a 'ContactPreference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactPreference' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindContactPreference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ContactPreference contactPreference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindContactPreferenceStoredProcedure findContactPreferenceProc = null;

                    // verify the first parameters is a 'ContactPreference'.
                    if (parameters[0].ObjectValue as ContactPreference != null)
                    {
                        // Get ContactPreferenceParameter
                        ContactPreference paramContactPreference = (ContactPreference) parameters[0].ObjectValue;

                        // verify paramContactPreference exists
                        if(paramContactPreference != null)
                        {
                            // Now create findContactPreferenceProc from ContactPreferenceWriter
                            // The DataWriter converts the 'ContactPreference'
                            // to the SqlParameter[] array needed to find a 'ContactPreference'.
                            findContactPreferenceProc = ContactPreferenceWriter.CreateFindContactPreferenceStoredProcedure(paramContactPreference);
                        }

                        // Verify findContactPreferenceProc exists
                        if(findContactPreferenceProc != null)
                        {
                            // Execute Find Stored Procedure
                            contactPreference = this.DataManager.ContactPreferenceManager.FindContactPreference(findContactPreferenceProc, dataConnector);

                            // if dataObject exists
                            if(contactPreference != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = contactPreference;
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

            #region InsertContactPreference (ContactPreference)
            /// <summary>
            /// This method inserts a 'ContactPreference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactPreference' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertContactPreference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ContactPreference contactPreference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertContactPreferenceStoredProcedure insertContactPreferenceProc = null;

                    // verify the first parameters is a(n) 'ContactPreference'.
                    if (parameters[0].ObjectValue as ContactPreference != null)
                    {
                        // Create ContactPreference Parameter
                        contactPreference = (ContactPreference) parameters[0].ObjectValue;

                        // verify contactPreference exists
                        if(contactPreference != null)
                        {
                            // Now create insertContactPreferenceProc from ContactPreferenceWriter
                            // The DataWriter converts the 'ContactPreference'
                            // to the SqlParameter[] array needed to insert a 'ContactPreference'.
                            insertContactPreferenceProc = ContactPreferenceWriter.CreateInsertContactPreferenceStoredProcedure(contactPreference);
                        }

                        // Verify insertContactPreferenceProc exists
                        if(insertContactPreferenceProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ContactPreferenceManager.InsertContactPreference(insertContactPreferenceProc, dataConnector);
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

            #region UpdateContactPreference (ContactPreference)
            /// <summary>
            /// This method updates a 'ContactPreference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactPreference' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateContactPreference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ContactPreference contactPreference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateContactPreferenceStoredProcedure updateContactPreferenceProc = null;

                    // verify the first parameters is a(n) 'ContactPreference'.
                    if (parameters[0].ObjectValue as ContactPreference != null)
                    {
                        // Create ContactPreference Parameter
                        contactPreference = (ContactPreference) parameters[0].ObjectValue;

                        // verify contactPreference exists
                        if(contactPreference != null)
                        {
                            // Now create updateContactPreferenceProc from ContactPreferenceWriter
                            // The DataWriter converts the 'ContactPreference'
                            // to the SqlParameter[] array needed to update a 'ContactPreference'.
                            updateContactPreferenceProc = ContactPreferenceWriter.CreateUpdateContactPreferenceStoredProcedure(contactPreference);
                        }

                        // Verify updateContactPreferenceProc exists
                        if(updateContactPreferenceProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ContactPreferenceManager.UpdateContactPreference(updateContactPreferenceProc, dataConnector);

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
