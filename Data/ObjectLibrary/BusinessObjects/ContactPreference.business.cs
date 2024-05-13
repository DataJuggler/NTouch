
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
        private bool loadByContactId;
        private bool deleteByContactId;
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

            #region ToString()
            /// <summary>
            /// method returns the ToString() of the ContactMethod
            /// </summary>
            public override string ToString()
            {
                return ContactMethod.ToString();
            }
            #endregion
            
        #endregion

        #region Properties

        #region DeleteByContactId
        /// <summary>
        /// This property gets or sets the value for 'DeleteByContactId'.
        /// </summary>
        public bool DeleteByContactId
        {
            get { return deleteByContactId; }
            set { deleteByContactId = value; }
        }
        #endregion

        #region LoadByContactId
        /// <summary>
        /// This property gets or sets the value for 'LoadByContactId'.
        /// </summary>
        public bool LoadByContactId
            {
                get { return loadByContactId; }
                set { loadByContactId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
