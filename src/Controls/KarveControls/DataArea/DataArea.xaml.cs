using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataArea.xaml
    /// </summary>
    public partial class DataArea : UserControl
    {
        private double _dataAreaWidth;
        private string _dataAreaLabel;
        private string _textValue;
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _dataAreaChanged = false;
        private object _itemSource;
        private string _DataArea = string.Empty;
        protected string _tableName = string.Empty;
 
        #region ItemSource
        /// <summary>
        ///  Item source dependency property.
        /// </summary>
        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSource",
                typeof(object),
                typeof(DataArea),
                new PropertyMetadata(null, OnItemSourceChanged));

        /// <summary>
        ///  Data source for the area.
        /// </summary>
        public object ItemSource
        {
            get { return GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }


        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnItemSourceChanged(e);
            }
        }
        private void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            this._itemSource = e.NewValue;
        }


        #endregion
        
        #region DataAreaTitle
        public static readonly DependencyProperty DataAreaTitleDependencyProperty =
            DependencyProperty.Register(
                "DataAreaTitle",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnDataAreaTitleChange));
        private static void OnDataAreaTitleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnDateAreaTitleChanged(e);
            }
        }
        /// <summary>
        ///  Title of the data area.
        /// </summary>
        public string DataAreaTitle
        {
            get { return (string)GetValue(DataAreaTitleDependencyProperty); }
            set { SetValue(DataAreaTitleDependencyProperty, value); }
        }
        private void OnDateAreaTitleChanged(DependencyPropertyChangedEventArgs e)
        {
            this.GBox.Header = e.NewValue;
        }

        #endregion
        
        #region IsReadOnly
        /// <summary>
        ///  Readonly dependency property for the control.
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnIsReadOnlyChanged(e);
            }
        }

        private void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.IsReadOnly=value;
            }
        }
        /// <summary>
        ///  It is a read only control.
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }
        #endregion
        #region DataArea
        /// <summary>
        ///  Path of the control.
        /// </summary>
        public static DependencyProperty DataAreaDependencyProperty =
            DependencyProperty.Register(
                "DataSourcePath",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnDataAreaChanged));

        /// <summary>
        ///  Path of an area to be binded.
        /// </summary>
        public string DataSourcePath
        {
            get { return (string)GetValue(DataAreaDependencyProperty); }
            set { SetValue(DataAreaDependencyProperty, value); }
        }
        private static void OnDataAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea controlDataArea = d as DataArea;
            if (controlDataArea != null)
            {
                controlDataArea.OnDataAreaPropertyChanged(e);
            }
        }
        private void OnDataAreaPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _DataArea = e.NewValue as string;
        }
        #endregion
        #region LabelText
        /// <summary>
        ///  Label text dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnLabelTextChange));
        /// <summary>
        ///  Label of the text.
        /// </summary>
        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnLabelTextChanged(e);
            }
        }

        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            LabelComponent.Content = value;
        }

        #endregion
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));
        /// <summary>
        /// Width of text to be present in the area.
        /// </summary>
        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            DataAreaWidth = Convert.ToDouble(value);
        }
        #endregion
        #region LabelVisible
        /// <summary>
        ///  Set if the label is visible or not.
        /// </summary>
        public readonly static DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register(
                "LabelVisible",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(true, OnLabelVisibleChange));
        /// <summary>
        /// Label is 
        /// </summary>
        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnLabelVisibleChanged(e);
            }
        }

        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = Convert.ToBoolean(e.NewValue);
            if (isVisible)
            {
                this.LabelComponent.Visibility = Visibility.Visible;
            }
            else
            {
                LabelComponent.Visibility = Visibility.Collapsed;
            }
        }

        #endregion
      
        /// <summary>
        ///  Text content dependency property
        /// </summary>
        #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        /// <summary>
        ///  Text content dependency property.
        /// </summary>
        public string TextContent
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }

        

        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.EditorText.Text = value;
        }
        #endregion

        
        /// <summary>
        ///  Data area.
        /// </summary>
        public DataArea()
        {
            InitializeComponent();
            this.DataAreaLayout.DataContext = this;
            this.EditorText.LostFocus +=EditorTextOnLostFocus;
            this.EditorText.GotFocus+=EditorTextOnGotFocus;
        }

        private void EditorTextOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            _dataAreaChanged = false;
            RaiseEvent(routedEventArgs);
        }


        private void EditorTextOnLostFocus(object sender, RoutedEventArgs e)
        {
            if (_dataAreaChanged)
            {
                if (EditorText.Text != null)
                {
                    DataAreaFieldEventsArgs ev = new DataAreaFieldEventsArgs();
                    ev.FieldData = EditorText.Text;
                    IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                    valueDictionary["Field"] = DataSourcePath;
                    valueDictionary["DataTable"] = ItemSource;
                    valueDictionary["DataObject"] = ItemSource;
                    valueDictionary["ChangedValue"] = EditorText.Text;
                    ev.ChangedValuesObjects = valueDictionary;
                    RaiseEvent(ev);
                    _dataAreaChanged = false;
                }
            }
        }

        private void EditorTextOnDataContextChanged(object sender, RoutedEventArgs e)
        {
            _dataAreaChanged = true;
            RaiseEvent(e);
        }
        /// <summary>
        ///  Width do the data area.
        /// </summary>
        public double DataAreaWidth
        {
            get { return _dataAreaWidth; }
            set
            {
             _dataAreaWidth = value;
             EditorText.Width = _dataAreaWidth;
            }
        }
        /// <summary>
        ///  Label of the area
        /// </summary>
        public string DataAreaLabel
        {
            get
            {
                return _dataAreaLabel;
            }
            set
            {
                _dataAreaLabel = value;
                 LabelComponent.Content = value;
            }
        }
    }
}
