

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertContactPreferenceStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ContactPreference' object.
    /// </summary>
    public class InsertContactPreferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertContactPreferenceStoredProcedure' object.
        /// </summary>
        public InsertContactPreferenceStoredProcedure()
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
                this.ProcedureName = "ContactPreference_Insert";

                // Set tableName
                this.TableName = "ContactPreference";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
