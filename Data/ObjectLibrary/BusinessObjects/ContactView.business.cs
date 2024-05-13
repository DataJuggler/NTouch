

#region using statements

using DataJuggler.UltimateHelper;
using ObjectLibrary.Enumerations;
using System;
using System.Security.Cryptography;

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
            
            #region Shortaddress
            /// <summary>
            /// This read only property returns the value of Shortaddress from the object Address.
            /// </summary>
            public string Shortaddress
            {
                
                get
                {
                    // initial value
                    string shortaddress = Address;
                    
                    // if Address exists
                    if ((Address != null) && (Address.Length > 18))
                    {
                        // set the return value
                        shortaddress = Address.Substring(0, 18);
                    }
                    
                    // return value
                    return shortaddress;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
