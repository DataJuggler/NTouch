

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllContactPreferencesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ContactPreference' objects.
    /// </summary>
    public class FetchAllContactPreferencesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllContactPreferencesStoredProcedure' object.
        /// </summary>
        public FetchAllContactPreferencesStoredProcedure()
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
                this.ProcedureName = "ContactPreference_FetchAll";

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
