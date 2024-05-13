

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

    #region class ContactViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'ContactView' object.
    /// </summary>
    public class ContactViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ContactViewMethods' object.
        /// </summary>
        public ContactViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ContactView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ContactView' to delete.
            /// <returns>A PolymorphicObject object with all  'ContactViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ContactView> contactViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllContactViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ContactViewParameter
                    // Declare Parameter
                    ContactView paramContactView = null;

                    // verify the first parameters is a(n) 'ContactView'.
                    if (parameters[0].ObjectValue as ContactView != null)
                    {
                        // Get ContactViewParameter
                        paramContactView = (ContactView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllContactViewsProc from ContactViewWriter
                    fetchAllProc = ContactViewWriter.CreateFetchAllContactViewsStoredProcedure(paramContactView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    contactViewListCollection = this.DataManager.ContactViewManager.FetchAllContactViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(contactViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = contactViewListCollection;
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
