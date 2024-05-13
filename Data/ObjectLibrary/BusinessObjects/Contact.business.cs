

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
                    if ((Address != null) && (Address.Length > 20))
                    {
                        // set the return value
                        shortaddress = Address.Substring(0, 20);
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
