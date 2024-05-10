

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ContactPreferenceReader
    /// <summary>
    /// This class loads a single 'ContactPreference' object or a list of type <ContactPreference>.
    /// </summary>
    public class ContactPreferenceReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ContactPreference' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ContactPreference' DataObject.</returns>
            public static ContactPreference Load(DataRow dataRow)
            {
                // Initial Value
                ContactPreference contactPreference = new ContactPreference();

                // Create field Integers
                int contactIdfield = 0;
                int contactMethodfield = 1;
                int idfield = 2;

                try
                {
                    // Load Each field
                    contactPreference.ContactId = DataHelper.ParseInteger(dataRow.ItemArray[contactIdfield], 0);
                    contactPreference.ContactMethod = DataHelper.ParseInteger(dataRow.ItemArray[contactMethodfield], 0);
                    contactPreference.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                }
                catch
                {
                }

                // return value
                return contactPreference;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ContactPreference' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ContactPreference Collection.</returns>
            public static List<ContactPreference> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ContactPreference> contactPreferences = new List<ContactPreference>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ContactPreference' from rows
                        ContactPreference contactPreference = Load(row);

                        // Add this object to collection
                        contactPreferences.Add(contactPreference);
                    }
                }
                catch
                {
                }

                // return value
                return contactPreferences;
            }
            #endregion

        #endregion

    }
    #endregion

}
