

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

    #region class ContactPreferenceWriterBase
    /// <summary>
    /// This class is used for converting a 'ContactPreference' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ContactPreferenceWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ContactPreference contactPreference)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='contactPreference'>The 'ContactPreference' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ContactPreference contactPreference)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (contactPreference != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", contactPreference.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteContactPreferenceStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteContactPreference'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_Delete'.
            /// </summary>
            /// <param name="contactPreference">The 'ContactPreference' to Delete.</param>
            /// <returns>An instance of a 'DeleteContactPreferenceStoredProcedure' object.</returns>
            public static DeleteContactPreferenceStoredProcedure CreateDeleteContactPreferenceStoredProcedure(ContactPreference contactPreference)
            {
                // Initial Value
                DeleteContactPreferenceStoredProcedure deleteContactPreferenceStoredProcedure = new DeleteContactPreferenceStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteContactPreferenceStoredProcedure.Parameters = CreatePrimaryKeyParameter(contactPreference);

                // return value
                return deleteContactPreferenceStoredProcedure;
            }
            #endregion

            #region CreateFindContactPreferenceStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindContactPreferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_Find'.
            /// </summary>
            /// <param name="contactPreference">The 'ContactPreference' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindContactPreferenceStoredProcedure CreateFindContactPreferenceStoredProcedure(ContactPreference contactPreference)
            {
                // Initial Value
                FindContactPreferenceStoredProcedure findContactPreferenceStoredProcedure = null;

                // verify contactPreference exists
                if(contactPreference != null)
                {
                    // Instanciate findContactPreferenceStoredProcedure
                    findContactPreferenceStoredProcedure = new FindContactPreferenceStoredProcedure();

                    // Now create parameters for this procedure
                    findContactPreferenceStoredProcedure.Parameters = CreatePrimaryKeyParameter(contactPreference);
                }

                // return value
                return findContactPreferenceStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ContactPreference contactPreference)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new contactPreference.
            /// </summary>
            /// <param name="contactPreference">The 'ContactPreference' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ContactPreference contactPreference)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify contactPreferenceexists
                if(contactPreference != null)
                {
                    // Create [ContactId] parameter
                    param = new SqlParameter("@ContactId", contactPreference.ContactId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ContactMethod] parameter
                    param = new SqlParameter("@ContactMethod", contactPreference.ContactMethod);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertContactPreferenceStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertContactPreferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_Insert'.
            /// </summary>
            /// <param name="contactPreference"The 'ContactPreference' object to insert</param>
            /// <returns>An instance of a 'InsertContactPreferenceStoredProcedure' object.</returns>
            public static InsertContactPreferenceStoredProcedure CreateInsertContactPreferenceStoredProcedure(ContactPreference contactPreference)
            {
                // Initial Value
                InsertContactPreferenceStoredProcedure insertContactPreferenceStoredProcedure = null;

                // verify contactPreference exists
                if(contactPreference != null)
                {
                    // Instanciate insertContactPreferenceStoredProcedure
                    insertContactPreferenceStoredProcedure = new InsertContactPreferenceStoredProcedure();

                    // Now create parameters for this procedure
                    insertContactPreferenceStoredProcedure.Parameters = CreateInsertParameters(contactPreference);
                }

                // return value
                return insertContactPreferenceStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ContactPreference contactPreference)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing contactPreference.
            /// </summary>
            /// <param name="contactPreference">The 'ContactPreference' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ContactPreference contactPreference)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify contactPreferenceexists
                if(contactPreference != null)
                {
                    // Create parameter for [ContactId]
                    param = new SqlParameter("@ContactId", contactPreference.ContactId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ContactMethod]
                    param = new SqlParameter("@ContactMethod", contactPreference.ContactMethod);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", contactPreference.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateContactPreferenceStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateContactPreferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_Update'.
            /// </summary>
            /// <param name="contactPreference"The 'ContactPreference' object to update</param>
            /// <returns>An instance of a 'UpdateContactPreferenceStoredProcedure</returns>
            public static UpdateContactPreferenceStoredProcedure CreateUpdateContactPreferenceStoredProcedure(ContactPreference contactPreference)
            {
                // Initial Value
                UpdateContactPreferenceStoredProcedure updateContactPreferenceStoredProcedure = null;

                // verify contactPreference exists
                if(contactPreference != null)
                {
                    // Instanciate updateContactPreferenceStoredProcedure
                    updateContactPreferenceStoredProcedure = new UpdateContactPreferenceStoredProcedure();

                    // Now create parameters for this procedure
                    updateContactPreferenceStoredProcedure.Parameters = CreateUpdateParameters(contactPreference);
                }

                // return value
                return updateContactPreferenceStoredProcedure;
            }
            #endregion

            #region CreateFetchAllContactPreferencesStoredProcedure(ContactPreference contactPreference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllContactPreferencesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ContactPreference_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllContactPreferencesStoredProcedure' object.</returns>
            public static FetchAllContactPreferencesStoredProcedure CreateFetchAllContactPreferencesStoredProcedure(ContactPreference contactPreference)
            {
                // Initial value
                FetchAllContactPreferencesStoredProcedure fetchAllContactPreferencesStoredProcedure = new FetchAllContactPreferencesStoredProcedure();

                // return value
                return fetchAllContactPreferencesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
