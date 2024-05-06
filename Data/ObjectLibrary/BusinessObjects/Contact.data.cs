

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Contact
    public partial class Contact
    {

        #region Private Variables
        private string address;
        private string city;
        private DateTime createdDate;
        private string emailAddress;
        private string firstName;
        private DateTime followUpDate;
        private int id;
        private string imagePath;
        private DateTime lastContactDate;
        private string lastName;
        private string notes;
        private string phoneNumber;
        private string state;
        private string zipCode;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string Address
            public string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }
            #endregion

            #region string City
            public string City
            {
                get
                {
                    return city;
                }
                set
                {
                    city = value;
                }
            }
            #endregion

            #region DateTime CreatedDate
            public DateTime CreatedDate
            {
                get
                {
                    return createdDate;
                }
                set
                {
                    createdDate = value;
                }
            }
            #endregion

            #region string EmailAddress
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    emailAddress = value;
                }
            }
            #endregion

            #region string FirstName
            public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
                }
            }
            #endregion

            #region DateTime FollowUpDate
            public DateTime FollowUpDate
            {
                get
                {
                    return followUpDate;
                }
                set
                {
                    followUpDate = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region string ImagePath
            public string ImagePath
            {
                get
                {
                    return imagePath;
                }
                set
                {
                    imagePath = value;
                }
            }
            #endregion

            #region DateTime LastContactDate
            public DateTime LastContactDate
            {
                get
                {
                    return lastContactDate;
                }
                set
                {
                    lastContactDate = value;
                }
            }
            #endregion

            #region string LastName
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                }
            }
            #endregion

            #region string Notes
            public string Notes
            {
                get
                {
                    return notes;
                }
                set
                {
                    notes = value;
                }
            }
            #endregion

            #region string PhoneNumber
            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }
                set
                {
                    phoneNumber = value;
                }
            }
            #endregion

            #region string State
            public string State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }
            #endregion

            #region string ZipCode
            public string ZipCode
            {
                get
                {
                    return zipCode;
                }
                set
                {
                    zipCode = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
