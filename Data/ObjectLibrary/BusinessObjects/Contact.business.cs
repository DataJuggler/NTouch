

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Contact
    [Serializable]
    public partial class Contact
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Contact()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Contact Clone()
            {
                // Create New Object
                Contact newContact = (Contact) this.MemberwiseClone();

                // Return Cloned Object
                return newContact;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
