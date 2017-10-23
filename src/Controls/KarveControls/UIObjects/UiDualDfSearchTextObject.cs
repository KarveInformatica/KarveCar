using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using Prism.Commands;

namespace KarveControls.UIObjects
{
    /// <summary>
    ///  This user object represent an abstraction for a search text box.
    /// </summary>
    public class UiDualDfSearchTextObject : UiDfObject
    {
        private string _assistQuery;
        private string _assistRefQuery;
        private ICommand _assistCommand;
        private DataTable _table = new DataTable();
        /// <summary>
        ///  Assist Query Handler. This method allows you to detect when the user has pressed the magnifier and 
        /// delivers to you the query and the table name.
        /// </summary>
        /// <param name="assistTableName">Table to execute the query.</param>
        /// <param name="assistQuery">Query to be executed in the query.</param>
        /// <param name="field">Data Field seen as primary key.</param>
        public delegate void OnAssistQueryRequestHandler(string assistTableName, string assistQuery, string field);
        /// <summary>
        ///  Event to be risen during an assist query.
        /// </summary>
        public event OnAssistQueryRequestHandler OnAssistQuery;
        /// <summary>
        /// This is the dual search box.
        /// </summary>
        public UiDualDfSearchTextObject()
        {
            
        }
        /// <summary>
        /// User object that represent an Doble field with a search text box using a cross reference table.
        /// </summary>
        /// <param name="labelTxt">Label of the data field.</param>
        /// <param name="labelWidth">Width of the label.</param>
        public UiDualDfSearchTextObject(string labelTxt, string labelWidth)
        {
            LabelText = labelTxt;
            LabelTextWidth = labelWidth;
           _assistCommand = new DelegateCommand<object>(OnAssistCommand);
        }
        /// <summary>
        /// Name of the cross reference table
        /// </summary>
        public string AssistTableName { set; get; }
        /// <summary>
        ///  Property Text of the first field
        /// </summary>
        public string TextContentFirst { set; get; }
        /// <summary>
        /// Property Text of the second field
        /// </summary>
        public string TextContentSecond { set; get; }
      /// <summary>
      ///  Property Text width of the first field
      /// </summary>
        public string TextContentFirstWidth { set; get; }
        /// <summary>
        /// Property Text width of the second field
        /// </summary>
        public string TextContentSecondWidth { set; get; }
        /// <summary>
        ///  Image button of the search box.
        /// </summary>
        public string ButtonImage { set; get; }
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public DataTable SourceView { set { _table = value; RaisePropertyChanged();}
            get { return _table; } }
        /// <summary>
        /// DataFieldFirst.
        /// </summary>
        public string DataFieldFirst {
            set { DataField = value; }
            get { return DataField; } }
        public string DataFieldSecond { set; get; }
        public string AssistDataFieldFirst { get; set; }
        public string AssistDataFieldSecond { get; set; }
        [XmlIgnore]
        public ICommand AssistCommand {
            get { return _assistCommand; }
            set { _assistCommand = value; }
        }

        private void OnAssistCommand(object value)
        {
            IDictionary<string, string> valueDictionary =(Dictionary<string,string>) value;
            string assistTable = "";
            string assistQuery = "";

            if (valueDictionary.ContainsKey(DualFieldSearchBox.MagnifierPressEventArgs.ASSISTTABLE))
            {
                assistTable = valueDictionary[DualFieldSearchBox.MagnifierPressEventArgs.ASSISTTABLE] as string;
            }
            if (valueDictionary.ContainsKey(DualFieldSearchBox.MagnifierPressEventArgs.ASSISTQUERY))
            {
                assistQuery = valueDictionary[DualFieldSearchBox.MagnifierPressEventArgs.ASSISTQUERY] as string;
            }
            OnAssistQuery?.Invoke(assistTable, assistQuery, DataFieldFirst);
        }
        /// <summary>
        ///  This returns the sql string query formed from the string.
        /// </summary>
        [XmlIgnore]
        public override string ToSQLString
        {
            get
            {
               StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrEmpty(DataFieldFirst))
                {
                    builder.Append(DataFieldFirst);
                    builder.Append(",");
                }
                if (!string.IsNullOrEmpty(DataFieldSecond))
                {
                    builder.Append(DataFieldSecond);
                    builder.Append(",");
                }
               string outValue = builder.ToString();
               return outValue;
            }
        }
        /// <summary>
        ///  This returns the reference assist query
        /// </summary>
        public string AssistRefQuery
        {
            get { return _assistRefQuery; }
        }
        public string AssistQuery
        {
            get
            {   ComputeAssistQuery();
                return _assistQuery;
            }
        }
        /// <summary>
        /// Set or Get the IsReadOnlyFirst
        /// </summary>
        public bool IsReadOnlyFirst { get; set; }
        /// <summary>
        ///  Set or Get the IsReadOnlySecond
        /// </summary>
        public bool IsReadOnlySecond { get; set; }

        // TODO: needs to moved from here
        private string ConvertToRightClause(object rowVal, Type colType)
        {
            string clause = "";
            if (colType == typeof(string))
            {
                clause = "'"+((string)rowVal)+"'";
            }
            if (colType == typeof(Int16))
            {
                Int16 value = (Int16) rowVal;
                clause = $"{value}";
            }
            if (colType == typeof(byte))
            {
                byte value = (byte) rowVal;
                clause = value.ToString();
            }
            if (colType == typeof(int))
            {
                int value = (Int32)rowVal;
                clause = $"{value}";
            }
            return clause;
        }

        private void ComputeAssistQuery()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            if (!string.IsNullOrEmpty(AssistDataFieldFirst))
            {
                builder.Append(AssistDataFieldFirst);
                builder.Append(",");
            }
            if (!string.IsNullOrEmpty(AssistDataFieldSecond))
            {
                builder.Append(AssistDataFieldSecond);
            }
            builder.Append(" FROM ");
            builder.Append(AssistTableName);
           _assistQuery = builder.ToString();
        }
        /// <summary>
        ///  This method compute the assistant query.
        /// </summary>
        /// <param name="itemSource">DataSet for which we need the queries.</param>
        public void ComputeAssistantRefQuery(DataSet itemSource)
        {
            IDictionary<string, DataTable> primaryDataTables = new Dictionary<string, DataTable>();
            foreach (DataTable table in itemSource.Tables)
            {
                if (table.TableName == TableName)
                {
                    primaryDataTables[table.TableName] = table;
                }
            }
            if (primaryDataTables.ContainsKey(TableName))
            {
                DataTable table = primaryDataTables[TableName];
                if (table.Columns.Contains(DataFieldFirst))
                {
                    object assistValue = table.Rows[0][DataFieldFirst];
                    if (!DBNull.Value.Equals(assistValue))
                    {
                        string rightPart = ConvertToRightClause(assistValue, table.Columns[DataFieldFirst].DataType).Trim();
                        if (!string.IsNullOrEmpty(rightPart))
                        {
                            StringBuilder builder = new StringBuilder();
                            builder.Append("SELECT ");
                            if (!string.IsNullOrEmpty(AssistDataFieldFirst))
                            {
                                builder.Append(AssistDataFieldFirst);
                                builder.Append(",");
                            }
                            if (!string.IsNullOrEmpty(AssistDataFieldSecond))
                            {
                                builder.Append(AssistDataFieldSecond);
                            }
                            builder.Append(" FROM ");
                            builder.Append(AssistTableName);
                            builder.Append(" WHERE ");
                            builder.Append(AssistDataFieldFirst);
                            builder.Append("=");
                            builder.Append(rightPart);
                            _assistRefQuery = builder.ToString();
                        }
                    }
                }
            }

        }
    }
}