

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.Excelerate.Interfaces;
using DataJuggler.NET8;
using DataJuggler.UltimateHelper;

#endregion

namespace NTouch.Objects
{

    #region class StateList : IExcelerateObject
    public class StateList : IExcelerateObject
    {

        #region Private Variables
        private string changedColumns;
        private string code;
        private int id;
        private bool loading;
        private string name;
        private Guid rowId;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a StateList object from a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be used to load this object.</param>
            public void Load(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    // Turn Loading On
                    Loading = true;

                    // set values
                    Id = row.Columns[0].IntValue;
                    Name = row.Columns[1].StringValue;
                    Code = row.Columns[2].StringValue;

                    // Turn Loading Off
                    Loading = false;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of StateList objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of StateList objects.</param>
            public static List<StateList> Load(Worksheet worksheet)
            {
                // Initial value
                List<StateList> stateListList = new List<StateList>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a StateList object.
                            StateList stateList = new StateList();
                            
                            // Load this object
                            stateList.Load(row);
                            
                            // Add this object to the list
                            stateListList.Add(stateList);
                        }
                    }
                }
                
                // return value
                return stateListList;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new StateList object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column idColumn = new Column("Id", rowNumber, 1, DataManager.DataTypeEnum.Integer);

                // Add this column
                newRow.Columns.Add(idColumn);

                // Create Column
                Column nameColumn = new Column("Name", rowNumber, 2, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(nameColumn);

                // Create Column
                Column codeColumn = new Column("Code", rowNumber, 3, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(codeColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a StateList object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists and the ChangedColumns string is not null or empty
                if ((NullHelper.Exists(row)) && (row.HasColumns) && (TextHelper.Exists(ChangedColumns)))
                {
                    // Parse the changed column indexes
                    List<int> changedColumnIndexes = ExcelHelper.ParseChangedColumnIndexes(ChangedColumns);

                    row.Columns[0].ColumnValue = Id;
                    row.Columns[0].HasChanges = changedColumnIndexes.Contains(0);
                    row.Columns[1].ColumnValue = Name;
                    row.Columns[1].HasChanges = changedColumnIndexes.Contains(1);
                    row.Columns[2].ColumnValue = Code;
                    row.Columns[2].HasChanges = changedColumnIndexes.Contains(2);
                }

                // return value
                return row;
            }
            #endregion

        #endregion

        #region Properties

            #region string ChangedColumns
            public string ChangedColumns
            {
                get
                {
                    return changedColumns;
                }
                set
                {
                    changedColumns = value;
                }
            }
            #endregion

            #region string Code
            public string Code
            {
                get
                {
                    return code;
                }
                set
                {
                    code = value;

                    if (!Loading)
                    {
                        ChangedColumns += 2 + ",";
                    }
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

                    if (!Loading)
                    {
                        ChangedColumns += 0 + ",";
                    }
                }
            }
            #endregion

            #region bool Loading
            public bool Loading
            {
                get
                {
                    return loading;
                }
                set
                {
                    loading = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;

                    if (!Loading)
                    {
                        ChangedColumns += 1 + ",";
                    }
                }
            }
            #endregion

            #region Guid RowId
            public Guid RowId
            {
                get
                {
                    return rowId;
                }
                set
                {
                    rowId = value;

                    if (!Loading)
                    {
                        ChangedColumns += 3 + ",";
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}