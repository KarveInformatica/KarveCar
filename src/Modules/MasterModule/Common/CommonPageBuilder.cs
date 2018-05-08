using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveControls;
using KarveControls.UIObjects;
using MasterModule.Properties;

namespace MasterModule.Common
{
    class CommonPageBuilder
    {

        /// <summary>
        ///  This build the direction from a fields of datas.
        /// </summary>
        /// <param name="fieldList">List of fields that shall be present: DataField, LabelText, TableName, PrimaryKey</param>
        /// <param name="changedField"></param>
        /// <returns></returns>
        protected IUiObject BuildDirection(IDictionary<string, string> fieldList, UiDfObject.ChangedField changedField)
        {
            UiDfObject dataDfObject = new UiDfObject();
            dataDfObject.DataField = fieldList["DataField"];
            dataDfObject.LabelText = fieldList["Label"];
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthLarge;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TableName = fieldList["Table"];
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.ItemSource = new DataTable();
            dataDfObject.IsVisible = true;
            dataDfObject.PrimaryKey = fieldList["PrimaryKey"];
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            return dataDfObject;
        }
        protected IUiObject BuildEmail(IDictionary<string,string> databaseFields, UiEmailDataField.EmailCheckHandler requestHandler, UiDfObject.ChangedField changedField)
        {
            UiEmailDataField dataDfObject = new UiEmailDataField();
            DataTable table = new DataTable();
            dataDfObject.ItemSource = table;
            dataDfObject.ButtonImage = MasterModuleConstants.EmailImagePath;
            dataDfObject.DataField = databaseFields["DataField"];
            dataDfObject.LabelText = databaseFields["Label"];
            dataDfObject.DataAllowed = DataType.Email;
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TableName = databaseFields["Table"];
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.PrimaryKey = databaseFields["PrimaryKey"];
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            dataDfObject.EmailEventHandler += requestHandler;
            return dataDfObject;
        }
        protected IUiObject BuildDoubleDfObjectProviders(IDictionary<string,string> databaseFields, UiDfObject.ChangedField changedField)
        {
            
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = databaseFields["DataField"];
            doubleDfObject.LabelText = databaseFields["Label"];
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = UiConstants.TextBoxWidthLarge;
            doubleDfObject.Height = UiConstants.TextboxHeight;
            doubleDfObject.TableName =  "PROVEE1";
            doubleDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = databaseFields["PrimaryKey"]; 
            doubleDfObject.OnChangedField += changedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = databaseFields["DataFieldRight"];
            doubleDfObject.LabelTextRight = databaseFields["LabelRight"];
            doubleDfObject.LabelTextWidthRight = UiConstants.LabelTextWidthDefault;
            doubleDfObject.LabelVisibleRight = true;
            doubleDfObject.TextContentWidthRight = UiConstants.LabelTextWidthDefault;
            doubleDfObject.HeightRight = UiConstants.TextboxHeight;
            return doubleDfObject;
        }
    }
}
