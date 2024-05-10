

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ContactPreference
    public partial class ContactPreference
    {

        #region Private Variables
        private int contactId;
        private int contactMethod;
        private int id;
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

            #region int ContactId
            public int ContactId
            {
                get
                {
                    return contactId;
                }
                set
                {
                    contactId = value;
                }
            }
            #endregion

            #region int ContactMethod
            public int ContactMethod
            {
                get
                {
                    return contactMethod;
                }
                set
                {
                    contactMethod = value;
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
