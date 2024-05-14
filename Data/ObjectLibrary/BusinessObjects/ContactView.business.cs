

#region using statements

using DataJuggler.UltimateHelper;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ContactView
    [Serializable]
    public partial class ContactView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ContactView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ContactView Clone()
            {
                // Create New Object
                ContactView newContactView = (ContactView) this.MemberwiseClone();

                // Return Cloned Object
                return newContactView;
            }
            #endregion

        #endregion

        #region Properties

            #region ShortAddress
            /// <summary>
            /// This read only property returns the value of ShortAddress from the object Address.
            /// </summary>
            public string ShortAddress
            {
                
                get
                {
                    // initial value
                    string shortAddress = Address;

                    // If the shortAddress string exists
                    if (TextHelper.Exists(shortAddress))
                    {
                        if (Address.Length > 19)
                        {
                            // Get a short Address
                            shortAddress = Address.Substring(0, 19);
                        }
                    }
                    
                    // return value
                    return shortAddress;
                }
            }
            #endregion
            
            #region ShortEmail
            /// <summary>
            /// This read only property returns the value of ShortEmail from the object Email.
            /// </summary>
            public string ShortEmail
            {
                
                get
                {
                    // initial value
                    string shortEmail = EmailAddress;

                    // If the EmailAddress string exists
                    if (TextHelper.Exists(EmailAddress))
                    {
                        // if > 19
                        if (EmailAddress.Length > 19)
                        {
                            // Set a short email
                            shortEmail = EmailAddress.Substring(0, 19);
                        }
                    }
                    
                    // return value
                    return shortEmail;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
