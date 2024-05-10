

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteContactPreferenceStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ContactPreference' object.
    /// </summary>
    public class DeleteContactPreferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteContactPreferenceStoredProcedure' object.
        /// </summary>
        public DeleteContactPreferenceStoredProcedure()
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
                this.ProcedureName = "ContactPreference_Delete";

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
