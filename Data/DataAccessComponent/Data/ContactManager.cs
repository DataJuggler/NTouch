

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class ContactManager
    /// <summary>
    /// This class is used to manage a 'Contact' object.
    /// </summary>
    public class ContactManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ContactManager' object.
        /// </summary>
        public ContactManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteContact()
            /// <summary>
            /// This method deletes a 'Contact' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteContact(DeleteContactStoredProcedure deleteContactProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteContactProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllContacts()
            /// <summary>
            /// This method fetches a  'List<Contact>' object.
            /// This method uses the 'Contacts_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Contact>'</returns>
            /// </summary>
            public List<Contact> FetchAllContacts(FetchAllContactsStoredProcedure fetchAllContactsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Contact> contactCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allContactsDataSet = DataHelper.LoadDataSet(fetchAllContactsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allContactsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allContactsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            contactCollection = ContactReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return contactCollection;
            }
            #endregion

            #region FindContact()
            /// <summary>
            /// This method finds a  'Contact' object.
            /// This method uses the 'Contact_Find' procedure.
            /// </summary>
            /// <returns>A 'Contact' object.</returns>
            /// </summary>
            public Contact FindContact(FindContactStoredProcedure findContactProc, DataConnector databaseConnector)
            {
                // Initial Value
                Contact contact = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet contactDataSet = DataHelper.LoadDataSet(findContactProc, databaseConnector);

                    // Verify DataSet Exists
                    if(contactDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(contactDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Contact
                            contact = ContactReader.Load(row);
                        }
                    }
                }

                // return value
                return contact;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertContact()
            /// <summary>
            /// This method inserts a 'Contact' object.
            /// This method uses the 'Contact_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertContact(InsertContactStoredProcedure insertContactProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertContactProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateContact()
            /// <summary>
            /// This method updates a 'Contact'.
            /// This method uses the 'Contact_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateContact(UpdateContactStoredProcedure updateContactProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateContactProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
