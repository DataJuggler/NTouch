

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

    #region class ContactViewManager
    /// <summary>
    /// This class is used to manage a 'ContactView' object.
    /// </summary>
    public class ContactViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ContactViewManager' object.
        /// </summary>
        public ContactViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllContactViews()
            /// <summary>
            /// This method fetches a  'List<ContactView>' object.
            /// This method uses the 'ContactViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ContactView>'</returns>
            /// </summary>
            public List<ContactView> FetchAllContactViews(FetchAllContactViewsStoredProcedure fetchAllContactViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ContactView> contactViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allContactViewsDataSet = DataHelper.LoadDataSet(fetchAllContactViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allContactViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allContactViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            contactViewCollection = ContactViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return contactViewCollection;
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
