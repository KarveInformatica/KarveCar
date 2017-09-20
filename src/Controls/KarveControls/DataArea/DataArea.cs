/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids
   
   This program has been extended with extension from Karve Informatica S.L.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using KarveControls;
using KarveControls.Utilities;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace KarveControls
{
    [TemplatePart(Name = PART_TextBlock, Type = typeof(TextBlock))]
    [TemplatePart(Name = PART_ResizeThumb, Type = typeof(Thumb))]
    [TemplatePart(Name = PART_TextBox, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_DropDownButton, Type = typeof(ToggleButton))]
    public class DataArea : ContentControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected DataTable _itemSource;
        private const string PART_TextBlock = "Part_TextBlock";
        private const string PART_ResizeThumb = "PART_ResizeThumb";
        private const string PART_TextBox = "PART_TextBox";
        private const string PART_DropDownButton = "PART_DropDownButton";
        private bool _labelVisible = false;

        #region Members

        private Thumb _resizeThumb;
        private TextBlock _labelPart;
        private TextBox _textBox;
        private ToggleButton _toggleButton;

        #endregion //Members


        #region DataArea Events

   
        public static readonly RoutedEvent DataAreaChangedEvent =
          EventManager.RegisterRoutedEvent(
              "DataAreaChanged",
              RoutingStrategy.Bubble,
              typeof(RoutedEventHandler),
              typeof(DataArea));

        public class DataAreaEventArgs : RoutedEventArgs
        {
            private string _fieldData = "";
            private string _fieldName = "";

            public string FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public string FieldName
            {
                get
                {
                    return _fieldName;
                }
                set { _fieldName = value; }
            }
            public DataAreaEventArgs() : base()
            {

            }
            public DataAreaEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }
        public event RoutedEventHandler DataAreaChanged
        {
            add { AddHandler(DataAreaChangedEvent, value); }
            remove { RemoveHandler(DataAreaChangedEvent, value); }
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region KarveDependencyProperties

        #region
        public static readonly DependencyProperty DescriptionDependencyProperty =
          DependencyProperty.Register(
              "Description",
              typeof(string),
              typeof(DataArea),
              new PropertyMetadata(String.Empty));


        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(CommonControl.DataType),
                typeof(DataArea),
                new PropertyMetadata(CommonControl.DataType.Any));
        #endregion

        #region ItemSource
        public static readonly DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DataArea),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));
        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }
        private void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
            if (!string.IsNullOrEmpty(this._dataField))
            {
                DataRow row = table.Rows[0];
                string field = row[_dataField] as string;
                Text = field;
            }
        }
        #endregion

        #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnTextContentChange));

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
                control.OnPropertyChanged("TextContent");
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.Text = value;
        }
        #endregion
        #region LabelVisible

        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnLabelVisibleChange));

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
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisibleChanged(e);
            }
        }

        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                _labelPart.Visibility = Visibility.Visible;
            }
            else
            {
                _labelPart.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

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
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextChanged(e);
            }
        }
        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string label = e.NewValue as string;
            this._labelPart.Text = label;
        }
        #endregion
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

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
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            this._labelPart.Width = value;
        }

        #endregion


        private string _dataField = string.Empty;
        private string _tableName = string.Empty;



        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnTableNameChange));


        #region TableName

        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }

        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }

        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }

        #endregion


        #region TextContentWidth

        public string TextContentWidth
        {
            get { return (string)GetValue(TextContentWidthDependencyProperty); }
            set { SetValue(TextContentWidthDependencyProperty, value); }
        }

        public readonly static DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(DataArea), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentWidth");
                control.OnTextContentWidthPropertyChanged(e);
            }
        }
        private void OnTextContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string tmpValue = e.NewValue as string;
            double valueName = Convert.ToDouble(tmpValue);
            this._textBox.Width = valueName;
        }
        #endregion

        public static DependencyProperty DataBaseFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnDataBaseFieldChanged));

        public string DataField
        {
            get { return (string)GetValue(DataBaseFieldDependencyProperty); }
            set { SetValue(DataBaseFieldDependencyProperty, value); }
        }
        private static void OnDataBaseFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea controlDataField = d as DataArea;

            if (controlDataField != null)
            {
                controlDataField.OnPropertyChanged("DataField");
                controlDataField.OnDataBaseFieldPropertyChanged(e);
            }
        }

        private void OnDataBaseFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            if (_dataField != null)
            {
                if ((this._itemSource != null) && (this._itemSource.Rows.Count > 0))
                {

                    DataRow row = this._itemSource.Rows[0];
                    string field = row[_dataField] as string;
                    TextContent = field;
                }
            }
        }

        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();
            if (!string.IsNullOrEmpty(field))
            {
                Binding oBind = new Binding("Text");
                oBind.Source = dta.Columns[field];
                oBind.Mode = BindingMode.TwoWay;
                oBind.ValidatesOnDataErrors = true;
                oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                if (rules != null)
                {
                    foreach (ValidationRule rule in rules)
                    {
                        oBind.ValidationRules.Add(rule);
                    }
                }
                _textBox.Width = dta.Columns[field].MaxLength;
                SetBinding(TextProperty, oBind);
            }
        }
        #endregion

        #region Properties

        #region DropDownHeight
        public static readonly DependencyProperty DropDownHeightProperty = DependencyProperty.Register("DropDownHeight", typeof(double), typeof(MultiLineTextEditor), new UIPropertyMetadata(150.0));
        public double DropDownHeight
        {
            get
            {
                return (double)GetValue(DropDownHeightProperty);
            }
            set
            {
                SetValue(DropDownHeightProperty, value);
            }
        }
        #endregion DropDownHeight

        #region DropDownWidth
        public static readonly DependencyProperty DropDownWidthProperty = DependencyProperty.Register("DropDownWidth", typeof(double), typeof(MultiLineTextEditor), new UIPropertyMetadata(200.0));
        public double DropDownWidth
        {
            get
            {
                return (double)GetValue(DropDownWidthProperty);
            }
            set
            {
                SetValue(DropDownWidthProperty, value);
            }
        }
        #endregion DropDownWidth

        #region IsOpen

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(MultiLineTextEditor), new UIPropertyMetadata(false, OnIsOpenChanged));
        public bool IsOpen
        {
            get
            {
                return (bool)GetValue(IsOpenProperty);
            }
            set
            {
                SetValue(IsOpenProperty, value);
            }
        }

        private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataArea _dataArea = o as DataArea;
            if (_dataArea != null)
                _dataArea.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
        {
            // Focus the content of the popup, after its loaded
            Dispatcher.BeginInvoke(new Action(() => _textBox.Focus()), DispatcherPriority.Background);
        }

        #endregion //IsOpen

        #region IsSpellCheckEnabled
        public static readonly DependencyProperty IsSpellCheckEnabledProperty = DependencyProperty.Register("IsSpellCheckEnabled", typeof(bool), typeof(DataArea), new UIPropertyMetadata(false));
        public bool IsSpellCheckEnabled
        {
            get
            {
                return (bool)GetValue(IsSpellCheckEnabledProperty);
            }
            set
            {
                SetValue(IsSpellCheckEnabledProperty, value);
            }
        }
        #endregion IsSpellCheckEnabled

        #region IsReadOnly
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MultiLineTextEditor), new UIPropertyMetadata(false));
        public bool IsReadOnly
        {
            get
            {
                return (bool)GetValue(IsReadOnlyProperty);
            }
            set
            {
                SetValue(IsReadOnlyProperty, value);
            }
        }
        #endregion IsReadOnly

        #region Text

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MultiLineTextEditor), new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataArea textEditor = o as DataArea;
            if (textEditor != null)
                textEditor.OnTextChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual void OnTextChanged(string oldValue, string newValue)
        {

        }

        #endregion //Text

        #region TextAlignment
        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(MultiLineTextEditor), new UIPropertyMetadata(TextAlignment.Left));
        public TextAlignment TextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(TextAlignmentProperty);
            }
            set
            {
                SetValue(TextAlignmentProperty, value);
            }
        }
        #endregion TextAlignment

        #region TextWrapping
        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(MultiLineTextEditor), new UIPropertyMetadata(TextWrapping.NoWrap));
        public TextWrapping TextWrapping
        {
            get
            {
                return (TextWrapping)GetValue(TextWrappingProperty);
            }
            set
            {
                SetValue(TextWrappingProperty, value);
            }
        }
        #endregion TextWrapping

        #endregion //Properties

        #region Constructors

        static DataArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataArea), new FrameworkPropertyMetadata(typeof(DataArea)));
        }

        public DataArea()
        {
            Keyboard.AddKeyDownHandler(this, OnKeyDown);
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideCapturedElement);
        }
        #endregion //Constructors

        #region Bass Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_resizeThumb != null)
                _resizeThumb.DragDelta -= ResizeThumb_DragDelta;

            _resizeThumb = GetTemplateChild(PART_ResizeThumb) as Thumb;

            if (_resizeThumb != null)
                _resizeThumb.DragDelta += ResizeThumb_DragDelta;

            if ((_labelPart != null) && (_labelVisible))
            {
                _labelPart = GetTemplateChild(PART_TextBlock) as TextBlock;
            }
            _textBox = GetTemplateChild(PART_TextBox) as TextBox;
            _toggleButton = GetTemplateChild(PART_DropDownButton) as ToggleButton;
        }

        #endregion //Bass Class Overrides

        #region Event Handlers

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsOpen)
            {
                if (KeyboardUtils.IsKeyModifyingPopupState(e))
                {
                    IsOpen = true;
                    e.Handled = true;
                }
            }
            else
            {
                if (KeyboardUtils.IsKeyModifyingPopupState(e)
                  || (e.Key == Key.Escape)
                  || (e.Key == Key.Tab))
                {
                    CloseEditor();
                    e.Handled = true;
                }
            }
        }

        private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
        {
            CloseEditor();
        }

        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double yadjust = DropDownHeight + e.VerticalChange;
            double xadjust = DropDownWidth + e.HorizontalChange;

            if ((xadjust >= 0) && (yadjust >= 0))
            {
                DropDownWidth = xadjust;
                DropDownHeight = yadjust;
            }
        }

        #endregion //Event Handlers

        #region Methods

        private void CloseEditor()
        {
            if (IsOpen)
                IsOpen = false;
            ReleaseMouseCapture();

            _toggleButton.Focus();
        }

        #endregion //Methods
    }
}
