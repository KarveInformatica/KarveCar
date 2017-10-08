using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    /*
      Content="{Binding TextContent, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                    TextContentWidth="{Binding TextContentWidth, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                    DataField="{Binding DataField, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"
                    ItemSource="{Binding ItemSource, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                    TableName="{Binding TableName, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"
                    DataFieldHeight="{Binding Height, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"
                    IsReadOnly="{Binding IsReadOnly, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}">
         */
    public class UiDataFieldCheckBox : UiDfObject
    {
        public string Content { set; get; }
        public bool IsChecked { set; get; }
      
        public override string ToSQLString {
            get
            {
                string dataField= DataField;
                string outValue = "";
                if (!string.IsNullOrEmpty(dataField))
                {
                    outValue = dataField + ",";
                }
                return outValue;
            }
            }
    }
}
