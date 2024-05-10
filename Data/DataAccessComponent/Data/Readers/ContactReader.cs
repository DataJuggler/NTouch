

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ContactReader
    /// <summary>
    /// This class loads a single 'Contact' object or a list of type <Contact>.
    /// </summary>
    public class ContactReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Contact' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Contact' DataObject.</returns>
            public static Contact Load(DataRow dataRow)
            {
                // Initial Value
                Contact contact = new Contact();

                // Create field Integers
                int addressfield = 0;
                int cityfield = 1;
                int createdDatefield = 2;
                int emailAddressfield = 3;
                int firstNamefield = 4;
                int followUpDatefield = 5;
                int idfield = 6;
                int imagePathfield = 7;
                int lastContactDatefield = 8;
                int lastNamefield = 9;
                int notesfield = 10;
                int phoneNumberfield = 11;
                int stateIdfield = 12;
                int zipCodefield = 13;

                try
                {
                    // Load Each field
                    contact.Address = DataHelper.ParseString(dataRow.ItemArray[addressfield]);
                    contact.City = DataHelper.ParseString(dataRow.ItemArray[cityfield]);
                    contact.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    contact.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    contact.FirstName = DataHelper.ParseString(dataRow.ItemArray[firstNamefield]);
                    contact.FollowUpDate = DataHelper.ParseDate(dataRow.ItemArray[followUpDatefield]);
                    contact.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    contact.ImagePath = DataHelper.ParseString(dataRow.ItemArray[imagePathfield]);
                    contact.LastContactDate = DataHelper.ParseDate(dataRow.ItemArray[lastContactDatefield]);
                    contact.LastName = DataHelper.ParseString(dataRow.ItemArray[lastNamefield]);
                    contact.Notes = DataHelper.ParseString(dataRow.ItemArray[notesfield]);
                    contact.PhoneNumber = DataHelper.ParseString(dataRow.ItemArray[phoneNumberfield]);
                    contact.StateId = DataHelper.ParseInteger(dataRow.ItemArray[stateIdfield], 0);
                    contact.ZipCode = DataHelper.ParseString(dataRow.ItemArray[zipCodefield]);
                }
                catch
                {
                }

                // return value
                return contact;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Contact' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Contact Collection.</returns>
            public static List<Contact> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Contact> contacts = new List<Contact>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Contact' from rows
                        Contact contact = Load(row);

                        // Add this object to collection
                        contacts.Add(contact);
                    }
                }
                catch
                {
                }

                // return value
                return contacts;
            }
            #endregion

        #endregion

    }
    #endregion

}
