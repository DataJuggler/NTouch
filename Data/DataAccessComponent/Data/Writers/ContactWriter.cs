

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

    #region class ContactWriter
    /// <summary>
    /// This class is used for converting a 'Contact' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ContactWriter : ContactWriterBase
    {

        #region Static Methods

            // *******************************************
            // Write any overrides or custom methods here.
            // *******************************************

        #endregion

    }
    #endregion

}
