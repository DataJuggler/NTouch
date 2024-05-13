

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

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private ContactMethods contactMethods;
        private ContactPreferenceMethods contactpreferenceMethods;
        private ContactViewMethods contactviewMethods;
        private StateMethods stateMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.ContactMethods = new ContactMethods(this.DataManager);
                this.ContactPreferenceMethods = new ContactPreferenceMethods(this.DataManager);
                this.ContactViewMethods = new ContactViewMethods(this.DataManager);
                this.StateMethods = new StateMethods(this.DataManager);
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

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region ContactMethods
            public ContactMethods ContactMethods
            {
                get { return contactMethods; }
                set { contactMethods = value; }
            }
            #endregion

            #region ContactPreferenceMethods
            public ContactPreferenceMethods ContactPreferenceMethods
            {
                get { return contactpreferenceMethods; }
                set { contactpreferenceMethods = value; }
            }
            #endregion

            #region ContactViewMethods
            public ContactViewMethods ContactViewMethods
            {
                get { return contactviewMethods; }
                set { contactviewMethods = value; }
            }
            #endregion

            #region StateMethods
            public StateMethods StateMethods
            {
                get { return stateMethods; }
                set { stateMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
