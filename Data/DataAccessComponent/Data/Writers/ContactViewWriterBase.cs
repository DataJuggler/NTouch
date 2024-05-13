

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class ContactViewWriterBase
    /// <summary>
    /// This class is used for converting a 'ContactView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ContactViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllContactViewsStoredProcedure(ContactView contactView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllContactViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllContactViewsStoredProcedure' object.</returns>
            public static FetchAllContactViewsStoredProcedure CreateFetchAllContactViewsStoredProcedure(ContactView contactView)
            {
                // Initial value
                FetchAllContactViewsStoredProcedure fetchAllContactViewsStoredProcedure = new FetchAllContactViewsStoredProcedure();

                // return value
                return fetchAllContactViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
