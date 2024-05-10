

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ContactPreference
    [Serializable]
    public partial class ContactPreference
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ContactPreference()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ContactPreference Clone()
            {
                // Create New Object
                ContactPreference newContactPreference = (ContactPreference) this.MemberwiseClone();

                // Return Cloned Object
                return newContactPreference;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
