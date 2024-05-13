
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

    #region class StateWriter
    /// <summary>
    /// This class is used for converting a 'State' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StateWriter : StateWriterBase
    {

        #region Static Methods

            #region CreateFindStateStoredProcedure(State state)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStateStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'State_Find'.
            /// </summary>
            /// <param name="state">The 'State' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindStateStoredProcedure CreateFindStateStoredProcedure(State state)
            {
                // Initial Value
                FindStateStoredProcedure findStateStoredProcedure = null;

                // verify state exists
                if(state != null)
                {
                    // Instanciate findStateStoredProcedure
                    findStateStoredProcedure = new FindStateStoredProcedure();

                    // if state.FindByName is true
                    if (state.FindByName)
                    {
                            // Change the procedure name
                            findStateStoredProcedure.ProcedureName = "State_FindByName";
                            
                            // Create the @Name parameter
                            findStateStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Name", state.Name);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findStateStoredProcedure.Parameters = CreatePrimaryKeyParameter(state);
                    }
                }

                // return value
                return findStateStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
