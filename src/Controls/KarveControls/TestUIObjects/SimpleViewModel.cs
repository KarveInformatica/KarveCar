using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using Prism.Mvvm;

namespace KarveControls.TestUIObject
{
    class SimpleViewModel: BindableBase
    {
        ObservableCollection<IUiObject> _list = new ObservableCollection<IUiObject>();
        private IList<string> _columns= new List<string>();
        private string _sqlQuery="";
        public SimpleViewModel()
        {
            // get values from db.
            UiDfObject dfObject0 = new UiDfObject();
            dfObject0.LabelText = "Nombre";
            dfObject0.LabelVisible = true;
            dfObject0.DataField = "NOMBRE";
            dfObject0.TableName = "PROVE1";
            dfObject0.TextContent = "Luca Deri";
            dfObject0.TextContentWidth = "60";
            dfObject0.TableName = "Auxliares";
           
            DataTable workTable = new DataTable();
            DataColumn workCol = workTable.Columns.Add("Nombre", typeof(string));
            DataRow row = workTable.NewRow();
            row["Nombre"] = "Marta";
            workTable.Rows.Add(row);
            dfObject0.ItemSource = workTable;
            UiSearchTextObject dfObject1 = new UiSearchTextObject();
            dfObject1.LabelText = "Nombre";
            dfObject1.TableName = "PROVE1";
            dfObject1.LabelVisible = true;
            dfObject1.TextContent = "Luca Deri";
            dfObject1.TextContentWidth = "60";
            dfObject1.AssistDataField = "Nombre";
            dfObject1.DataField = "Nombre";
            DataTable workTable3 = new DataTable();
            DataColumn workCol1 = workTable3.Columns.Add("Nombre", typeof(string));
            DataRow row8 = workTable3.NewRow();
            row8["Nombre"] = "Luigi";
            workTable3.Rows.Add(row8);
            dfObject1.SourceView = workTable3;
            _list.Add(dfObject0);
            _list.Add(dfObject0);
            _list.Add(dfObject1);
          
        }

        public string Query
        {
            set
            {
                _sqlQuery = value;
                RaisePropertyChanged("Query");
            }
            get { return _sqlQuery; }

        }
        public ObservableCollection<IUiObject> ItemCollectionValue
        {
            set {
                _list = value;
                RaisePropertyChanged("ItemCollectionValue");
            }
            get { return _list; }
        }
    }
}
