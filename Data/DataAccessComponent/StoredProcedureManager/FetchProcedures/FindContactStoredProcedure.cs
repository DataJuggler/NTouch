

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindContactStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Contact' object.
    /// </summary>
    public class FindContactStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindContactStoredProcedure' object.
        /// </summary>
        public FindContactStoredProcedure()
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
                this.ProcedureName = "Contact_Find";

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
