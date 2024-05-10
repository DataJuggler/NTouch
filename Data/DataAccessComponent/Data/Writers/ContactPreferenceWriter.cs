
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

    #region class ContactPreferenceWriter
    /// <summary>
    /// This class is used for converting a 'ContactPreference' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ContactPreferenceWriter : ContactPreferenceWriterBase
    {

        #region Static Methods

            #region CreateFetchAllContactPreferencesStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllContactPreferencesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllContactPreferencesStoredProcedure' object.</returns>
            public static new FetchAllContactPreferencesStoredProcedure CreateFetchAllContactPreferencesStoredProcedure(ContactPreference contactPreference)
            {
                // Initial value
                FetchAllContactPreferencesStoredProcedure fetchAllContactPreferencesStoredProcedure = new FetchAllContactPreferencesStoredProcedure();

                // if the contactPreference object exists
                if (contactPreference != null)
                {
                    // if LoadByContactId is true
                    if (contactPreference.LoadByContactId)
                    {
                        // Change the procedure name
                        fetchAllContactPreferencesStoredProcedure.ProcedureName = "ContactPreference_FetchAllForContactId";
                        
                        // Create the @ContactId parameter
                        fetchAllContactPreferencesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ContactId", contactPreference.ContactId);
                    }
                }
                
                // return value
                return fetchAllContactPreferencesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
