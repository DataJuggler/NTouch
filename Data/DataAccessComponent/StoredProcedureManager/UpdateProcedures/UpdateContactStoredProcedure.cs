

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateContactStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Contact' object.
    /// </summary>
    public class UpdateContactStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateContactStoredProcedure' object.
        /// </summary>
        public UpdateContactStoredProcedure()
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
                this.ProcedureName = "Contact_Update";

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
