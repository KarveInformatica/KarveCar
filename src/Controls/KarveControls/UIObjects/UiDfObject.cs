using System;
using System.ComponentModel;
using System.Data;

namespace KarveControls.UIObjects
{
    public class UiDfObject: IUiObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _description;
        private CommonControl.DataType _dataAllowed;
        private bool _allowedEmpty;
        private bool _upperCase;
        private string _labelText;
        private bool _labelVisible;
        private string _textContent;
        private string _textContentWidth;
        private bool _isReadOnly;
        private bool _isVisible;
        private string _dataField;
        private string _tableName;
        private DataTable _itemSource;
        private string _labelTextWidth;



        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public CommonControl.DataType DataAllowed
        {
            set { _dataAllowed = value; }
            get { return _dataAllowed; }
        }

        public bool AllowedEmpty
        {
            set { _allowedEmpty = value; }
            get { return _allowedEmpty; }
        }

        public bool UpperCase
        {
            set { _upperCase = value; }
            get { return _upperCase; }
        }

        public string LabelText
        {
            set { _labelText = value; }
            get { return _labelText; }

        }

        public bool LabelVisible
        {
            set { _labelVisible = value; }
            get { return _labelVisible; }
        }

        public string TextContent
        {
            set { _textContent = value; }
            get { return _textContent; }
        }

        public string TextContentWidth
        {
            set { _textContentWidth = value; }
            get { return _textContentWidth; }
        }

        public bool IsReadOnly
        {
            set { _isReadOnly = value; }
            get { return _isReadOnly; }
        }

        public string DataField
        {
            set { _dataField = value; }
            get { return _dataField; }
        }

        public string TableName
        {
            set { _tableName = value; }
            get { return _tableName; }
        }

        public DataTable ItemSource
        {
            set { _itemSource = value; }
            get { return _itemSource; }

        }

        public string LabelTextWidth
        {
            set { _labelTextWidth = value; }
            get { return _labelTextWidth; }

        }
        public bool IsVisible
        {
            set { _isVisible = value; }
            get { return _isVisible; }
        }

    }
}