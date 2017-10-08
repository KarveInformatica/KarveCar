using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using Prism.Commands;
using Telerik.WinControls;

namespace KarveControls.UIObjects
{
    public class UiDualDfSearchTextObject : UiDfObject
    {
        private string _dataField;
        private string _assistQuery;
        private string _assistRefQuery;
        private ICommand _assistCommand;
        private bool _lookup = false;
        private DataTable _table = new DataTable();

        public delegate void OnAssistQueryRequestHandler(string assistTableName, string assistQuery, string field);
        public event OnAssistQueryRequestHandler OnAssistQuery;

        public UiDualDfSearchTextObject(string labelTxt, string labelWidth)
        {
            LabelText = labelTxt;
            LabelTextWidth = labelWidth;
           _assistCommand = new DelegateCommand<object>(OnAssistCommand);
        }

        public string AssistTableName { set; get; }
        public string TextContentFirst { set; get; }
        public string TextContentSecond { set; get; }
        public string TextContentFirstWidth { set; get; }
        public string TextContentSecondWidth { set; get; }
        public string ButtonImage { set; get; }
        [XmlIgnore]
        public DataTable SourceView { set { _table = value;  }
            get { return _table; } }
        public string DataFieldFirst { set; get; }
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

        public bool Lookup
        {
            get { return _lookup; }
            set { _lookup = value;
                RaisePropertyChanged("Lookup");
            }
        }
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
        public bool IsReadOnlyFirst { get; set; }
        public bool IsReadOnlySecond { get; set; }

        // FIXME: needs to moved from here
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