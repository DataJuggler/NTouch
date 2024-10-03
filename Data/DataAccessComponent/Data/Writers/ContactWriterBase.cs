

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

    #region class ContactWriterBase
    /// <summary>
    /// This class is used for converting a 'Contact' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ContactWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Contact contact)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='contact'>The 'Contact' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Contact contact)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (contact != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", contact.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteContactStoredProcedure(Contact contact)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteContact'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Contact_Delete'.
            /// </summary>
            /// <param name="contact">The 'Contact' to Delete.</param>
            /// <returns>An instance of a 'DeleteContactStoredProcedure' object.</returns>
            public static DeleteContactStoredProcedure CreateDeleteContactStoredProcedure(Contact contact)
            {
                // Initial Value
                DeleteContactStoredProcedure deleteContactStoredProcedure = new DeleteContactStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteContactStoredProcedure.Parameters = CreatePrimaryKeyParameter(contact);

                // return value
                return deleteContactStoredProcedure;
            }
            #endregion

            #region CreateFindContactStoredProcedure(Contact contact)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindContactStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Contact_Find'.
            /// </summary>
            /// <param name="contact">The 'Contact' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindContactStoredProcedure CreateFindContactStoredProcedure(Contact contact)
            {
                // Initial Value
                FindContactStoredProcedure findContactStoredProcedure = null;

                // verify contact exists
                if(contact != null)
                {
                    // Instanciate findContactStoredProcedure
                    findContactStoredProcedure = new FindContactStoredProcedure();

                    // Now create parameters for this procedure
                    findContactStoredProcedure.Parameters = CreatePrimaryKeyParameter(contact);
                }

                // return value
                return findContactStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Contact contact)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new contact.
            /// </summary>
            /// <param name="contact">The 'Contact' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Contact contact)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[14];
                SqlParameter param = null;

                // verify contactexists
                if(contact != null)
                {
                    // Create [Address] parameter
                    param = new SqlParameter("@Address", contact.Address);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [BirthDate] Parameter
                    param = new SqlParameter("@BirthDate", SqlDbType.DateTime);

                    // If contact.BirthDate does not exist.
                    if (contact.BirthDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.BirthDate;
                    }
                    // set parameters[1]
                    parameters[1] = param;

                    // Create [City] parameter
                    param = new SqlParameter("@City", contact.City);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If contact.CreatedDate does not exist.
                    if (contact.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.CreatedDate;
                    }
                    // set parameters[3]
                    parameters[3] = param;

                    // Create [EmailAddress] parameter
                    param = new SqlParameter("@EmailAddress", contact.EmailAddress);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [FirstName] parameter
                    param = new SqlParameter("@FirstName", contact.FirstName);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [FollowUpDate] Parameter
                    param = new SqlParameter("@FollowUpDate", SqlDbType.DateTime);

                    // If contact.FollowUpDate does not exist.
                    if (contact.FollowUpDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.FollowUpDate;
                    }
                    // set parameters[6]
                    parameters[6] = param;

                    // Create [ImagePath] parameter
                    param = new SqlParameter("@ImagePath", contact.ImagePath);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [LastContactDate] Parameter
                    param = new SqlParameter("@LastContactDate", SqlDbType.DateTime);

                    // If contact.LastContactDate does not exist.
                    if (contact.LastContactDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.LastContactDate;
                    }
                    // set parameters[8]
                    parameters[8] = param;

                    // Create [LastName] parameter
                    param = new SqlParameter("@LastName", contact.LastName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [Notes] parameter
                    param = new SqlParameter("@Notes", contact.Notes);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [PhoneNumber] parameter
                    param = new SqlParameter("@PhoneNumber", contact.PhoneNumber);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create [StateId] parameter
                    param = new SqlParameter("@StateId", contact.StateId);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [ZipCode] parameter
                    param = new SqlParameter("@ZipCode", contact.ZipCode);

                    // set parameters[13]
                    parameters[13] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertContactStoredProcedure(Contact contact)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertContactStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Contact_Insert'.
            /// </summary>
            /// <param name="contact"The 'Contact' object to insert</param>
            /// <returns>An instance of a 'InsertContactStoredProcedure' object.</returns>
            public static InsertContactStoredProcedure CreateInsertContactStoredProcedure(Contact contact)
            {
                // Initial Value
                InsertContactStoredProcedure insertContactStoredProcedure = null;

                // verify contact exists
                if(contact != null)
                {
                    // Instanciate insertContactStoredProcedure
                    insertContactStoredProcedure = new InsertContactStoredProcedure();

                    // Now create parameters for this procedure
                    insertContactStoredProcedure.Parameters = CreateInsertParameters(contact);
                }

                // return value
                return insertContactStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Contact contact)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing contact.
            /// </summary>
            /// <param name="contact">The 'Contact' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Contact contact)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[15];
                SqlParameter param = null;

                // verify contactexists
                if(contact != null)
                {
                    // Create parameter for [Address]
                    param = new SqlParameter("@Address", contact.Address);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [BirthDate]
                    // Create [BirthDate] Parameter
                    param = new SqlParameter("@BirthDate", SqlDbType.DateTime);

                    // If contact.BirthDate does not exist.
                    if (contact.BirthDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.BirthDate;
                    }

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [City]
                    param = new SqlParameter("@City", contact.City);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If contact.CreatedDate does not exist.
                    if (contact.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.CreatedDate;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [EmailAddress]
                    param = new SqlParameter("@EmailAddress", contact.EmailAddress);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [FirstName]
                    param = new SqlParameter("@FirstName", contact.FirstName);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [FollowUpDate]
                    // Create [FollowUpDate] Parameter
                    param = new SqlParameter("@FollowUpDate", SqlDbType.DateTime);

                    // If contact.FollowUpDate does not exist.
                    if (contact.FollowUpDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.FollowUpDate;
                    }

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [ImagePath]
                    param = new SqlParameter("@ImagePath", contact.ImagePath);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [LastContactDate]
                    // Create [LastContactDate] Parameter
                    param = new SqlParameter("@LastContactDate", SqlDbType.DateTime);

                    // If contact.LastContactDate does not exist.
                    if (contact.LastContactDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = contact.LastContactDate;
                    }

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [LastName]
                    param = new SqlParameter("@LastName", contact.LastName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [Notes]
                    param = new SqlParameter("@Notes", contact.Notes);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [PhoneNumber]
                    param = new SqlParameter("@PhoneNumber", contact.PhoneNumber);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [StateId]
                    param = new SqlParameter("@StateId", contact.StateId);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [ZipCode]
                    param = new SqlParameter("@ZipCode", contact.ZipCode);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", contact.Id);
                    parameters[14] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateContactStoredProcedure(Contact contact)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateContactStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Contact_Update'.
            /// </summary>
            /// <param name="contact"The 'Contact' object to update</param>
            /// <returns>An instance of a 'UpdateContactStoredProcedure</returns>
            public static UpdateContactStoredProcedure CreateUpdateContactStoredProcedure(Contact contact)
            {
                // Initial Value
                UpdateContactStoredProcedure updateContactStoredProcedure = null;

                // verify contact exists
                if(contact != null)
                {
                    // Instanciate updateContactStoredProcedure
                    updateContactStoredProcedure = new UpdateContactStoredProcedure();

                    // Now create parameters for this procedure
                    updateContactStoredProcedure.Parameters = CreateUpdateParameters(contact);
                }

                // return value
                return updateContactStoredProcedure;
            }
            #endregion

            #region CreateFetchAllContactsStoredProcedure(Contact contact)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllContactsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Contact_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllContactsStoredProcedure' object.</returns>
            public static FetchAllContactsStoredProcedure CreateFetchAllContactsStoredProcedure(Contact contact)
            {
                // Initial value
                FetchAllContactsStoredProcedure fetchAllContactsStoredProcedure = new FetchAllContactsStoredProcedure();

                // return value
                return fetchAllContactsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
