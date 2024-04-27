

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllContactsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Contact' objects.
    /// </summary>
    public class FetchAllContactsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllContactsStoredProcedure' object.
        /// </summary>
        public FetchAllContactsStoredProcedure()
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
                this.ProcedureName = "Contact_FetchAll";

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
