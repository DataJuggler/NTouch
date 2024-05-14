

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ContactView
    public partial class ContactView
    {

        #region Private Variables
        private string address;
        private string city;
        private string emailAddress;
        private string firstName;
        private DateTime followUpDate;
        private int id;
        private string imagePath;
        private DateTime lastContactDate;
        private string lastName;
        private string phoneNumber;
        private string stateCode;
        private int stateId;
        private string stateName;
        private string zipCode;
        #endregion

        #region Methods


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
                set
                {
                    id = value;
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

            #region string StateCode
            public string StateCode
            {
                get
                {
                    return stateCode;
                }
                set
                {
                    stateCode = value;
                }
            }
            #endregion

            #region int StateId
            public int StateId
            {
                get
                {
                    return stateId;
                }
                set
                {
                    stateId = value;
                }
            }
            #endregion

            #region string StateName
            public string StateName
            {
                get
                {
                    return stateName;
                }
                set
                {
                    stateName = value;
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

        #endregion

    }
    #endregion

}
