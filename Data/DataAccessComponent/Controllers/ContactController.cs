

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

    #region class ContactController
    /// <summary>
    /// This class controls a(n) 'Contact' object.
    /// </summary>
    public class ContactController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ContactController' object.
        /// </summary>
        public ContactController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateContactParameter
            /// <summary>
            /// This method creates the parameter for a 'Contact' data operation.
            /// </summary>
            /// <param name='contact'>The 'Contact' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateContactParameter(Contact contact)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = contact;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Contact tempContact)
            /// <summary>
            /// Deletes a 'Contact' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Contact_Delete'.
            /// </summary>
            /// <param name='contact'>The 'Contact' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Contact tempContact)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteContact";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcontact exists before attemptintg to delete
                    if(tempContact != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteContactMethod = this.AppController.DataBridge.DataOperations.ContactMethods.DeleteContact;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactParameter(tempContact);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteContactMethod, parameters);

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

            #region FetchAll(Contact tempContact)
            /// <summary>
            /// This method fetches a collection of 'Contact' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Contact_FetchAll'.</summary>
            /// <param name='tempContact'>A temporary Contact for passing values.</param>
            /// <returns>A collection of 'Contact' objects.</returns>
            public List<Contact> FetchAll(Contact tempContact)
            {
                // Initial value
                List<Contact> contactList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ContactMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateContactParameter(tempContact);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Contact> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        contactList = (List<Contact>) returnObject.ObjectValue;
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
                return contactList;
            }
            #endregion

            #region Find(Contact tempContact)
            /// <summary>
            /// Finds a 'Contact' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Contact_Find'</param>
            /// </summary>
            /// <param name='tempContact'>A temporary Contact for passing values.</param>
            /// <returns>A 'Contact' object if found else a null 'Contact'.</returns>
            public Contact Find(Contact tempContact)
            {
                // Initial values
                Contact contact = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempContact != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ContactMethods.FindContact;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactParameter(tempContact);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Contact != null))
                        {
                            // Get ReturnObject
                            contact = (Contact) returnObject.ObjectValue;
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
                return contact;
            }
            #endregion

            #region Insert(Contact contact)
            /// <summary>
            /// Insert a 'Contact' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Contact_Insert'.</param>
            /// </summary>
            /// <param name='contact'>The 'Contact' object to insert.</param>
            /// <returns>The id (int) of the new  'Contact' object that was inserted.</returns>
            public int Insert(Contact contact)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Contactexists
                    if(contact != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ContactMethods.InsertContact;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactParameter(contact);

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

            #region Save(ref Contact contact)
            /// <summary>
            /// Saves a 'Contact' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='contact'>The 'Contact' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Contact contact)
            {
                // Initial value
                bool saved = false;

                // If the contact exists.
                if(contact != null)
                {
                    // Is this a new Contact
                    if(contact.IsNew)
                    {
                        // Insert new Contact
                        int newIdentity = this.Insert(contact);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            contact.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Contact
                        saved = this.Update(contact);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Contact contact)
            /// <summary>
            /// This method Updates a 'Contact' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Contact_Update'.</param>
            /// </summary>
            /// <param name='contact'>The 'Contact' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Contact contact)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(contact != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ContactMethods.UpdateContact;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateContactParameter(contact);
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
