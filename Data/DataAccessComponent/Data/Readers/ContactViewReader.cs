

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
                int cityfield = 1;
                int emailAddressfield = 2;
                int firstNamefield = 3;
                int followUpDatefield = 4;
                int idfield = 5;
                int imagePathfield = 6;
                int lastContactDatefield = 7;
                int lastNamefield = 8;
                int phoneNumberfield = 9;
                int stateCodefield = 10;
                int stateIdfield = 11;
                int stateNamefield = 12;
                int zipCodefield = 13;

                try
                {
                    // Load Each field
                    contactView.Address = DataHelper.ParseString(dataRow.ItemArray[addressfield]);
                    contactView.City = DataHelper.ParseString(dataRow.ItemArray[cityfield]);
                    contactView.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    contactView.FirstName = DataHelper.ParseString(dataRow.ItemArray[firstNamefield]);
                    contactView.FollowUpDate = DataHelper.ParseDate(dataRow.ItemArray[followUpDatefield]);
                    contactView.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    contactView.ImagePath = DataHelper.ParseString(dataRow.ItemArray[imagePathfield]);
                    contactView.LastContactDate = DataHelper.ParseDate(dataRow.ItemArray[lastContactDatefield]);
                    contactView.LastName = DataHelper.ParseString(dataRow.ItemArray[lastNamefield]);
                    contactView.PhoneNumber = DataHelper.ParseString(dataRow.ItemArray[phoneNumberfield]);
                    contactView.StateCode = DataHelper.ParseString(dataRow.ItemArray[stateCodefield]);
                    contactView.StateId = DataHelper.ParseInteger(dataRow.ItemArray[stateIdfield], 0);
                    contactView.StateName = DataHelper.ParseString(dataRow.ItemArray[stateNamefield]);
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
