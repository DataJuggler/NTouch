

#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ContactPreferenceController
    /// <summary>
    /// This class controls a(n) 'ContactPreference' object.
    /// </summary>
    public class ContactPreferenceController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ContactPreferenceController' object.
        /// </summary>
        public ContactPreferenceController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateContactPreferenceParameter
            /// <summary>
            /// This method creates the parameter for a 'ContactPreference' data operation.
            /// </summary>
            /// <param name='contactpreference'>The 'ContactPreference' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateContactPreferenceParameter(ContactPreference contactPreference)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = contactPreference;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ContactPreference tempContactPreference)
            /// <summary>
            /// Deletes a 'ContactPreference' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ContactPreference_Delete'.
            /// </summary>
            /// <param name='contactpreference'>The 'ContactPreference' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ContactPreference tempContactPreference)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteContactPreference";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcontactPreference exists before attemptintg to delete
                    if(tempContactPreference != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteContactPreferenceMethod = this.AppController.DataBridge.DataOperations.ContactPreferenceMethods.DeleteContactPreference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactPreferenceParameter(tempContactPreference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteContactPreferenceMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(ContactPreference tempContactPreference)
            /// <summary>
            /// This method fetches a collection of 'ContactPreference' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ContactPreference_FetchAll'.</summary>
            /// <param name='tempContactPreference'>A temporary ContactPreference for passing values.</param>
            /// <returns>A collection of 'ContactPreference' objects.</returns>
            public List<ContactPreference> FetchAll(ContactPreference tempContactPreference)
            {
                // Initial value
                List<ContactPreference> contactPreferenceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ContactPreferenceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateContactPreferenceParameter(tempContactPreference);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ContactPreference> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        contactPreferenceList = (List<ContactPreference>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return contactPreferenceList;
            }
            #endregion

            #region Find(ContactPreference tempContactPreference)
            /// <summary>
            /// Finds a 'ContactPreference' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ContactPreference_Find'</param>
            /// </summary>
            /// <param name='tempContactPreference'>A temporary ContactPreference for passing values.</param>
            /// <returns>A 'ContactPreference' object if found else a null 'ContactPreference'.</returns>
            public ContactPreference Find(ContactPreference tempContactPreference)
            {
                // Initial values
                ContactPreference contactPreference = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempContactPreference != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ContactPreferenceMethods.FindContactPreference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactPreferenceParameter(tempContactPreference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ContactPreference != null))
                        {
                            // Get ReturnObject
                            contactPreference = (ContactPreference) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return contactPreference;
            }
            #endregion

            #region Insert(ContactPreference contactPreference)
            /// <summary>
            /// Insert a 'ContactPreference' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ContactPreference_Insert'.</param>
            /// </summary>
            /// <param name='contactPreference'>The 'ContactPreference' object to insert.</param>
            /// <returns>The id (int) of the new  'ContactPreference' object that was inserted.</returns>
            public int Insert(ContactPreference contactPreference)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ContactPreferenceexists
                    if(contactPreference != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ContactPreferenceMethods.InsertContactPreference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactPreferenceParameter(contactPreference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref ContactPreference contactPreference)
            /// <summary>
            /// Saves a 'ContactPreference' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='contactPreference'>The 'ContactPreference' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ContactPreference contactPreference)
            {
                // Initial value
                bool saved = false;

                // If the contactPreference exists.
                if(contactPreference != null)
                {
                    // Is this a new ContactPreference
                    if(contactPreference.IsNew)
                    {
                        // Insert new ContactPreference
                        int newIdentity = this.Insert(contactPreference);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            contactPreference.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ContactPreference
                        saved = this.Update(contactPreference);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ContactPreference contactPreference)
            /// <summary>
            /// This method Updates a 'ContactPreference' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ContactPreference_Update'.</param>
            /// </summary>
            /// <param name='contactPreference'>The 'ContactPreference' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ContactPreference contactPreference)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(contactPreference != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ContactPreferenceMethods.UpdateContactPreference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactPreferenceParameter(contactPreference);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
