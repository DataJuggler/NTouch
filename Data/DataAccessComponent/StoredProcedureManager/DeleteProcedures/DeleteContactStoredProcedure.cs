

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteContactStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Contact' object.
    /// </summary>
    public class DeleteContactStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteContactStoredProcedure' object.
        /// </summary>
        public DeleteContactStoredProcedure()
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
                this.ProcedureName = "Contact_Delete";

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
