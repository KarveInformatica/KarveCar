using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveControls.Generic;
using Prism.Commands;
using Syncfusion.Windows.Shared;

namespace KarveControls
{
    
    [TemplatePart(Name = "PART_DataField", Type = typeof(DataField))]
    [TemplatePart(Name = "PART_SearchBox", Type = typeof(DualFieldSearchBox))]

    public class KarveSearchBox : TextBox
    {

        /// <summary>
        ///  FieldCollection. This is a collection of fields.
        /// </summary>
        public static readonly DependencyProperty FieldCollectionDependencyProperty =
            DependencyProperty.Register(
                "FieldCollection",
                typeof(string),
                typeof(KarveSearchBox), new PropertyMetadata(string.Empty, OnFieldCollectionChange));

        /// <summary>
        /// Collection source.
        /// </summary>
        public static readonly DependencyProperty SourceCollectionDependencyProperty =
            DependencyProperty.Register(
                "SourceCollection",
                typeof(string),
                typeof(KarveSearchBox), new PropertyMetadata(string.Empty, OnFieldCollectionChange));
        /// <summary>
        ///  Data Field.
        /// </summary>
        private DataField _dataField;
        /// <summary>
        ///  Dual Field searchbox.
        /// </summary>
        private DualFieldSearchBox _dualFieldSearchBox;

        /// <summary>
        ///  First property
        /// </summary>
        private string _firstProperty;
        /// <summary>
        ///  Second property
        /// </summary>
        private string _secondProperty;
        /// <summary>
        ///  Third property
        /// </summary>
        private string _thirdProperty;
        /// <summary>
        ///  Current Dto.
        /// </summary>
        private object _currentDto;

        private IEnumerable _currentSourceView;

        private IDictionary<string, string> _sourceToFieldMap = new Dictionary<string, string>();

        public IDictionary<string, string> BuildSourceToFields(string source, string fields)
        {
            IDictionary<string, string> sourceToFields = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(source))
            {
                return null;
            }
            if (string.IsNullOrEmpty(fields))
            {
                return null;
            }
            if (source.Length != fields.Length)
            {
                return null;
            }
            string[] s = source.Split(',');
            string[] f = fields.Split(',');
            if (!sourceToFields.ContainsKey(s[0]))
            sourceToFields.Add(s[0],f[0]);
            if (!sourceToFields.ContainsKey(s[1]))
                sourceToFields.Add(s[1], f[1]);
            if (!sourceToFields.ContainsKey(s[2]))
                sourceToFields.Add(s[2], f[2]);
            return sourceToFields;
        }

        public string FieldCollection
        {
            get { return (string) GetValue(FieldCollectionDependencyProperty); }
            set { SetValue(FieldCollectionDependencyProperty, value); }
        }

        public string SourceCollection
        {
            get { return (string) GetValue(SourceCollectionDependencyProperty); }
            set { SetValue(SourceCollectionDependencyProperty, value); }
        }

        private static void OnFieldCollectionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveSearchBox karveSearch = d as KarveSearchBox;
            if (karveSearch != null)
            {
                karveSearch.OnFieldCollectionChanged(e);
            }
        }
        /// <summary>
        ///  OnFieldCollectionChanged.
        /// </summary>
        /// <param name="e">Event to be changed</param>
        private void OnFieldCollectionChanged(DependencyPropertyChangedEventArgs e)
        {
            _sourceToFieldMap = BuildSourceToFields(SourceCollection, FieldCollection);
            List<string> currentList = _sourceToFieldMap.Keys.ToList();
            List<string> assistProperties = _sourceToFieldMap.Values.ToList();
            if (_dataField != null)
            {
                _dataField.DataSourcePath =  currentList[0];

            }
            if (_dualFieldSearchBox != null)
            {
                _dualFieldSearchBox.DataFieldFirst = currentList[1];
                _dualFieldSearchBox.AssistProperties = FieldCollection;
            }
        }
        /// <summary>
        ///  SourceView. This is the value object for the search..
        /// </summary>
        public static readonly DependencyProperty SourceViewDependencyProperty = DependencyProperty.Register(
            "SourceView",
            typeof(object),
            typeof(KarveSearchBox), new PropertyMetadata(null, OnSourceViewChanged));
        /// <summary>
        ///  SourceView. Collection of values.
        /// </summary>
        public object SourceView
        {
            get { return GetValue(SourceViewDependencyProperty); }
            set { SetValue(SourceViewDependencyProperty, value); }
        }
        /// <summary>
        ///  Dependency property command executed when a change happens.
        /// </summary>
        public static DependencyProperty AssistNameDependencyProperty = DependencyProperty.Register(
            "AssistName",
            typeof(string),
            typeof(KarveSearchBox), new PropertyMetadata(string.Empty, OnAssistNameChanged));

        private static void OnAssistNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string myValue = (string)d.GetValue(AssistNameDependencyProperty);
            KarveSearchBox box = d as KarveSearchBox;
            if (box != null)
            {
                box.OnUpdateAssist(myValue);
            }
        }
        private void OnUpdateAssist(string myValue)
        {
            if (_dualFieldSearchBox != null)
            {
                _dualFieldSearchBox.AssistTableName = myValue;
            }
        }
        public string AssistName
        {
            get { return (string)GetValue(AssistNameDependencyProperty); }
            set { SetValue(AssistNameDependencyProperty, value); }
        }

        /// <summary>
        ///  Dependency property command executed when a change happens.
        /// </summary>
        public static DependencyProperty ItemChangedDependencyProperty = DependencyProperty.Register(
            "Command",
            typeof(object),
            typeof(KarveSearchBox));

        /// <summary>
        ///  Dependency property command value.
        /// </summary>
        public static DependencyProperty LabelWidthDependencyProperty = DependencyProperty.Register(
            "LabelWidth",
            typeof(double),
            typeof(KarveSearchBox));

        /// <summary>
        ///  DataSource. Source of the dependency property.
        /// </summary>
        public object LabelWidth
        {
            get { return GetValue(LabelWidthDependencyProperty); }
            set { SetValue(LabelWidthDependencyProperty, value); }
        }
        // <summary>
        ///  Dependency property command value.
        /// </summary>
        public static DependencyProperty TextWidthDependencyProperty = DependencyProperty.Register(
            "TextWidth",
            typeof(double),
            typeof(KarveSearchBox));

        /// <summary>
        ///  TextWidth. Source of the dependency property.
        /// </summary>
        public object TextWidth
        {
            get { return GetValue(TextWidthDependencyProperty); }
            set { SetValue(TextWidthDependencyProperty, value); }
        }
        /// <summary>
        ///  Dependency property command value.
        /// </summary>
        public static DependencyProperty DataSourceDependencyProperty = DependencyProperty.Register(
            "DataSource",
            typeof(object),
            typeof(KarveSearchBox));

        /// <summary>
        ///  DataSource. Source of the dependency property.
        /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceDependencyProperty); }
            set { SetValue(DataSourceDependencyProperty, value); }
        }
        /// <summary>
        ///  Dependency property command executed when a change happens.
        /// </summary>
        public static DependencyProperty MagnifierDependencyProperty = DependencyProperty.Register(
            "MagnifierCommand",
            typeof(object),
            typeof(KarveSearchBox));


        /// <summary>
        ///  Command to get the value.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand) GetValue(ItemChangedDependencyProperty); }
            set { SetValue(ItemChangedDependencyProperty, value); }
        }
        /// <summary>
        /// On Magnifier command.
        /// </summary>
        /// <param name="command"></param>
        public void OnMagnifierCommand(object command)
        {
            //ok the magnifier has clicked.
            if (_dualFieldSearchBox != null)
            {
                ICommand cmd = (ICommand)GetValue(ItemChangedDependencyProperty);
                cmd.Execute(command);
            }
        }

        /// <summary>
        /// OnSourceView.
        /// </summary>
        /// <param name="d">OnSourceView.</param>
        /// <param name="e">Dependency</param>
        private static void OnSourceViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveSearchBox karveSearch = d as KarveSearchBox;
            if (karveSearch != null)
            {
                karveSearch.OnSourceViewChanged(e);
            }
        }

        private void OnSourceViewChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_dualFieldSearchBox != null)
            {
                _currentSourceView = e.NewValue as IEnumerable;
                if (_dualFieldSearchBox != null)
                {
                    _dualFieldSearchBox.SourceView = e.NewValue;
                }
            }
        }

        /// <summary>
        ///  OnApplyTemplate. This allow a template to be done.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dataField = GetTemplateChild("PART_DataField") as DataField;
            _dualFieldSearchBox = GetTemplateChild("PART_SearchBox") as DualFieldSearchBox;
            if (_dataField != null)
            {
                _dataField.ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnFirstChanged); 
            }
            if (_dualFieldSearchBox != null)
            {
                _dualFieldSearchBox.ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnSecondChanged);
              //  _dualFieldSearchBox.MagnifierCommand = new Prism.Commands.DelegateCommand<object>(OnMagnifierCommand);
            }
        }

        private void OnSecondChanged(object obj)
        {
            IDictionary<string, object> valueDictionary = obj as IDictionary<string, object>;
            if (valueDictionary != null)
            {
                var doCode = valueDictionary["DataFieldFirst"];
                var dataObject = valueDictionary["DataObject"];
                var sourceView = valueDictionary["AssistDataTable"] as IEnumerable;
                var mappedFiled = _sourceToFieldMap[_dataField.DataSourcePath];

                // selectedItem.
              //  var selectedItem = _dualFieldSearchBox.SelectedItem;
                /*
                ComponentUtils.Utils(selectedItem, mappedFie)
                /*
                if (sourceView!=null)
                {
                    foreach (var value in sourceView)
                    {
                        ComponentUtils.GetPropValue(value, mappedFiled);
                    }
                }
                
                _dataField.DataObject = dataObject;
                _dataField.TextContent = */
            }
        }

        private void OnFirstChanged(object obj)
        {
            throw new NotImplementedException();
        }

        static KarveSearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KarveSearchBox), new FrameworkPropertyMetadata(typeof(KarveSearchBox)));
        }


    }
}
