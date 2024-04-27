

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertContactStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Contact' object.
    /// </summary>
    public class InsertContactStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertContactStoredProcedure' object.
        /// </summary>
        public InsertContactStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Contact_Insert";

                // Set tableName
                this.TableName = "Contact";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
