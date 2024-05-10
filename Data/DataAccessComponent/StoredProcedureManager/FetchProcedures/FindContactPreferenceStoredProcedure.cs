

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindContactPreferenceStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ContactPreference' object.
    /// </summary>
    public class FindContactPreferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindContactPreferenceStoredProcedure' object.
        /// </summary>
        public FindContactPreferenceStoredProcedure()
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
                this.ProcedureName = "ContactPreference_Find";

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
