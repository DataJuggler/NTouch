

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ContactViewReader
    /// <summary>
    /// This class loads a single 'ContactView' object or a list of type <ContactView>.
    /// </summary>
    public class ContactViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ContactView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ContactView' DataObject.</returns>
            public static ContactView Load(DataRow dataRow)
            {
                // Initial Value
                ContactView contactView = new ContactView();

                // Create field Integers
                int addressfield = 0;
                int birthDatefield = 1;
                int cityfield = 2;
                int createdDatefield = 3;
                int emailAddressfield = 4;
                int firstNamefield = 5;
                int followUpDatefield = 6;
                int idfield = 7;
                int imagePathfield = 8;
                int lastContactDatefield = 9;
                int lastNamefield = 10;
                int notesfield = 11;
                int phoneNumberfield = 12;
                int stateCodefield = 13;
                int stateIdfield = 14;
                int stateNamefield = 15;
                int subscriberfield = 16;
                int zipCodefield = 17;

                try
                {
                    // Load Each field
                    contactView.Address = DataHelper.ParseString(dataRow.ItemArray[addressfield]);
                    contactView.BirthDate = DataHelper.ParseDate(dataRow.ItemArray[birthDatefield]);
                    contactView.City = DataHelper.ParseString(dataRow.ItemArray[cityfield]);
                    contactView.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    contactView.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    contactView.FirstName = DataHelper.ParseString(dataRow.ItemArray[firstNamefield]);
                    contactView.FollowUpDate = DataHelper.ParseDate(dataRow.ItemArray[followUpDatefield]);
                    contactView.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    contactView.ImagePath = DataHelper.ParseString(dataRow.ItemArray[imagePathfield]);
                    contactView.LastContactDate = DataHelper.ParseDate(dataRow.ItemArray[lastContactDatefield]);
                    contactView.LastName = DataHelper.ParseString(dataRow.ItemArray[lastNamefield]);
                    contactView.Notes = DataHelper.ParseString(dataRow.ItemArray[notesfield]);
                    contactView.PhoneNumber = DataHelper.ParseString(dataRow.ItemArray[phoneNumberfield]);
                    contactView.StateCode = DataHelper.ParseString(dataRow.ItemArray[stateCodefield]);
                    contactView.StateId = DataHelper.ParseInteger(dataRow.ItemArray[stateIdfield], 0);
                    contactView.StateName = DataHelper.ParseString(dataRow.ItemArray[stateNamefield]);
                    contactView.Subscriber = DataHelper.ParseBoolean(dataRow.ItemArray[subscriberfield], false);
                    contactView.ZipCode = DataHelper.ParseString(dataRow.ItemArray[zipCodefield]);
                }
                catch
                {
                }

                // return value
                return contactView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ContactView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ContactView Collection.</returns>
            public static List<ContactView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ContactView> contactViews = new List<ContactView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ContactView' from rows
                        ContactView contactView = Load(row);

                        // Add this object to collection
                        contactViews.Add(contactView);
                    }
                }
                catch
                {
                }

                // return value
                return contactViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
