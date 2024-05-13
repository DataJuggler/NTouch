

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

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private string connectionName;
        private ContactManager contactManager;
        private ContactPreferenceManager contactpreferenceManager;
        private ContactViewManager contactviewManager;
        private StateManager stateManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.ContactManager = new ContactManager(this);
                this.ContactPreferenceManager = new ContactPreferenceManager(this);
                this.ContactViewManager = new ContactViewManager(this);
                this.StateManager = new StateManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region ContactManager
            public ContactManager ContactManager
            {
                get { return contactManager; }
                set { contactManager = value; }
            }
            #endregion

            #region ContactPreferenceManager
            public ContactPreferenceManager ContactPreferenceManager
            {
                get { return contactpreferenceManager; }
                set { contactpreferenceManager = value; }
            }
            #endregion

            #region ContactViewManager
            public ContactViewManager ContactViewManager
            {
                get { return contactviewManager; }
                set { contactviewManager = value; }
            }
            #endregion

            #region StateManager
            public StateManager StateManager
            {
                get { return stateManager; }
                set { stateManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
