

#region using statements

using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Contact
    [Serializable]
    public partial class Contact
    {

        #region Private Variables
        private List<ContactPreference> contactPreferences;
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

            #region ContactPreferences
            /// <summary>
            /// This property gets or sets the value for 'ContactPreferences'.
            /// </summary>
            public List<ContactPreference> ContactPreferences
            {
                get { return contactPreferences; }
                set { contactPreferences = value; }
            }
            #endregion
            
            #region HasContactPreferences
            /// <summary>
            /// This property returns true if this object has a 'ContactPreferences'.
            /// </summary>
            public bool HasContactPreferences
            {
                get
                {
                    // initial value
                    bool hasContactPreferences = (this.ContactPreferences != null);
                    
                    // return value
                    return hasContactPreferences;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
