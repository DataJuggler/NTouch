

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

    #region class ContactPreferenceManager
    /// <summary>
    /// This class is used to manage a 'ContactPreference' object.
    /// </summary>
    public class ContactPreferenceManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ContactPreferenceManager' object.
        /// </summary>
        public ContactPreferenceManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteContactPreference()
            /// <summary>
            /// This method deletes a 'ContactPreference' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteContactPreference(DeleteContactPreferenceStoredProcedure deleteContactPreferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteContactPreferenceProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllContactPreferences()
            /// <summary>
            /// This method fetches a  'List<ContactPreference>' object.
            /// This method uses the 'ContactPreferences_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ContactPreference>'</returns>
            /// </summary>
            public List<ContactPreference> FetchAllContactPreferences(FetchAllContactPreferencesStoredProcedure fetchAllContactPreferencesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ContactPreference> contactPreferenceCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allContactPreferencesDataSet = this.DataHelper.LoadDataSet(fetchAllContactPreferencesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allContactPreferencesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allContactPreferencesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            contactPreferenceCollection = ContactPreferenceReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return contactPreferenceCollection;
            }
            #endregion

            #region FindContactPreference()
            /// <summary>
            /// This method finds a  'ContactPreference' object.
            /// This method uses the 'ContactPreference_Find' procedure.
            /// </summary>
            /// <returns>A 'ContactPreference' object.</returns>
            /// </summary>
            public ContactPreference FindContactPreference(FindContactPreferenceStoredProcedure findContactPreferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                ContactPreference contactPreference = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet contactPreferenceDataSet = this.DataHelper.LoadDataSet(findContactPreferenceProc, databaseConnector);

                    // Verify DataSet Exists
                    if(contactPreferenceDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(contactPreferenceDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ContactPreference
                            contactPreference = ContactPreferenceReader.Load(row);
                        }
                    }
                }

                // return value
                return contactPreference;
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

            #region InsertContactPreference()
            /// <summary>
            /// This method inserts a 'ContactPreference' object.
            /// This method uses the 'ContactPreference_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertContactPreference(InsertContactPreferenceStoredProcedure insertContactPreferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertContactPreferenceProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateContactPreference()
            /// <summary>
            /// This method updates a 'ContactPreference'.
            /// This method uses the 'ContactPreference_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateContactPreference(UpdateContactPreferenceStoredProcedure updateContactPreferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateContactPreferenceProc, databaseConnector);
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
