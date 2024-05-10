

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateContactPreferenceStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ContactPreference' object.
    /// </summary>
    public class UpdateContactPreferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateContactPreferenceStoredProcedure' object.
        /// </summary>
        public UpdateContactPreferenceStoredProcedure()
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
                this.ProcedureName = "ContactPreference_Update";

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
