

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllContactViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ContactView' objects.
    /// </summary>
    public class FetchAllContactViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllContactViewsStoredProcedure' object.
        /// </summary>
        public FetchAllContactViewsStoredProcedure()
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
                this.ProcedureName = "ContactView_FetchAll";

                // Set tableName
                this.TableName = "ContactView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
