using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// UiDoubleDfObject.
    /// </summary>
    public class UiDoubleDfObject : IUiObject
    {
        private UiDfObject _leftUiDfObject = new UiDfObject();
        private UiDfObject _rightDfObject = new UiDfObject();
        private bool _isVisible = false;
        /// <summary>
        /// Current description
        /// </summary>
        public string Description
        {
            get { return _leftUiDfObject.Description; }
            set { _leftUiDfObject.Description = value; }
        }
        /// <summary>
        ///  Data not allowed.
        /// </summary>
        public ControlExt.DataType DataAllowed
        {
            get { return _leftUiDfObject.DataAllowed; }
            set { _leftUiDfObject.DataAllowed = value; }
        }
        /// <summary>
        ///  Value empty allowed for the data
        /// </summary>
        public bool AllowedEmpty
        {
            get { return _leftUiDfObject.AllowedEmpty; }
            set { _leftUiDfObject.AllowedEmpty = true; }
        }
        /// <summary>
        /// Handler for a change event.
        /// </summary>
        public event UiDfObject.ChangedField OnChangedField
        {
            add
            {
                _leftUiDfObject.OnChangedField += value;
                _rightDfObject.OnChangedField += value;
            }
            remove
            {
                _leftUiDfObject.OnChangedField -= value;
                _rightDfObject.OnChangedField -= value;
            }

        }
        /// <summary>
        /// Text content
        /// </summary>
        public string TextContent
        {
            get => _leftUiDfObject.TextContent;
            set => _leftUiDfObject.TextContent = value;
        }
        /// <summary>
        /// Uppercase of the content.
        /// </summary>
        public bool UpperCase
        {
            get => _leftUiDfObject.UpperCase;
            set => _leftUiDfObject.UpperCase = value;
        }
        /// <summary>
        /// Label of the double field.
        /// </summary>
        public string LabelText
        {
            get => _leftUiDfObject.LabelText;
            set => _leftUiDfObject.LabelText = value;
        }
        /// <summary>
        /// Label Text width.
        /// </summary>
        public string LabelTextWidth
        {
            get => _leftUiDfObject.LabelTextWidth;
            set => _leftUiDfObject.LabelTextWidth = value;
        }
        /// <summary>
        /// Label visible or not visible.
        /// </summary>
        public bool LabelVisible
        {
            get => _leftUiDfObject.LabelVisible;
            set => _leftUiDfObject.LabelVisible = value;
        }
        /// <summary>
        /// Is read only stuff.
        /// </summary>
        public bool IsReadOnly
        {
            get => _leftUiDfObject.IsReadOnly;
            set => _leftUiDfObject.IsReadOnly = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataField
        {
            get => _leftUiDfObject.DataField;
            set => _leftUiDfObject.DataField = value;
        }

        public ICommand ChangedItem
        {
            get { return _leftUiDfObject.ChangedItem; }
            set { _leftUiDfObject.ChangedItem = value; }
        }
        public ICommand ChangedItemRight
        {
            get { return _rightDfObject.ChangedItem; }
            set { _rightDfObject.ChangedItem = value; }
        }
        public string TableName
        {
            get { return _leftUiDfObject.TableName; }
            set
            {
                if (_leftUiDfObject != null)
                {
                    _leftUiDfObject.TableName = value;
                }
                if (_rightDfObject != null)
                {
                    _rightDfObject.TableName = value;
                }
            }
        }

        public object ItemSource
        {
            get => _leftUiDfObject.ItemSource;
            set
            {
                _leftUiDfObject.ItemSource = value;
                _rightDfObject.ItemSource = value;
            }
        }
        public object ItemSourceRight
        {
            get => _rightDfObject.ItemSource;
            set
            {
                _rightDfObject.ItemSource = value;
            }
        }

        public string Height
        {
            get => _leftUiDfObject.Height;
            set => _leftUiDfObject.Height = value;
        }

        public string TextContentRight
        {
            get => _rightDfObject.TextContent;
            set => _rightDfObject.TextContent = value;
        }

        public bool UpperCaseRight
        {
            get => _rightDfObject.UpperCase;
            set => _rightDfObject.UpperCase = value;
        }

        public string LabelTextRight
        {
            get => _rightDfObject.LabelText;
            set => _rightDfObject.LabelText = value;
        }

        public string LabelTextWidthRight
        {
            get => _rightDfObject.LabelTextWidth;
            set => _rightDfObject.LabelTextWidth = value;
        }

        public bool LabelVisibleRight
        {
            get => _rightDfObject.LabelVisible;
            set => _rightDfObject.LabelVisible = value;
        }

        public bool IsReadOnlyRight
        {
            get => _rightDfObject.IsReadOnly;
            set => _rightDfObject.IsReadOnly = value;
        }

        public string DataFieldRight
        {
            get => _rightDfObject.DataField;
            set => _rightDfObject.DataField = value;
        }
        

        public string HeightRight
        {
            get => _rightDfObject.Height;
            set => _rightDfObject.Height = value;
        }
        [XmlIgnore]
        public string ToSQLString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(_leftUiDfObject.DataField);
                builder.Append(",");
                builder.Append(_rightDfObject.DataField);
                builder.Append(",");
                return builder.ToString();


            }
        }

        public string PrimaryKey
        {
            get => _leftUiDfObject.PrimaryKey;
            set {
                _leftUiDfObject.PrimaryKey = value;
                _rightDfObject.PrimaryKey = value;
            }
        }

        public bool IsVisible {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        public string TextContentWidth
        {
            get { return this._leftUiDfObject.TextContentWidth; }
            set { this._leftUiDfObject.TextContentWidth = value; }
        }

        public string TextContentWidthRight
        {
            get { return this._rightDfObject.TextContentWidth; }
            set { this._rightDfObject.TextContentWidth = value; }

           
        }
    }
}
