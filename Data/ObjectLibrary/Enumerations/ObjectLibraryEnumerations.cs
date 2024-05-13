

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum ScreenTypeEnum : int
    /// <summary>
    /// This enum is the type of component to show
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        ContactList = 0,
        AddContact = 1,
        EditContact = 2        
    }
    #endregion

    #region ContactMethodEnum : int
    /// <summary>
    /// This enum is the type of communication methods contact prefers
    /// </summary>
    public enum ContactMethodEnum : int
    {
        Email = 1,
        Text = 2,
        Phone = 3
    }
    #endregion

}
