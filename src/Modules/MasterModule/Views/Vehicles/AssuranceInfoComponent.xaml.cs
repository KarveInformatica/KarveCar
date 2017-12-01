using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveControls;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace MasterModule.Views.Vehicles
{
    /// <summary>
    /// Interaction logic for AssuranceInfoComponent
    /// .xaml
    /// </summary>
    public partial class AssuranceInfoComponent : UserControl
    {
        private bool changedText = false;
        private bool changedPolizaText = false;

        /// <summary>
        ///  Dependency preoperty for the assurance policy
        /// </summary>
        public static readonly DependencyProperty ItemChangedDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(AssuranceInfoComponent), new PropertyMetadata(null, ChangedPropertyCb));

        private static void ChangedPropertyCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand value = e.NewValue as ICommand;
            AssuranceInfoComponent component = d as AssuranceInfoComponent;
            if (component != null)
            {
                component.UpdateValue(value);
            }

        }

        private void UpdateValue(ICommand component)
        {
            if (component != null)
            {
               AssuranceCompany.ItemChangedCommand = component;
               
            }
        }
        /// <summary>
        ///  ItemChangedCommand. Command to be changed.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand) GetValue(ItemChangedDependencyProperty); }
            set
            {
                SetValue(ItemChangedDependencyProperty, value);
            }
        }
        
        /// <summary>
        ///  Dependency preoperty for the assurance policy
        /// </summary>
        public static readonly DependencyProperty MagnifierCommandDependencyProperty =
            DependencyProperty.Register(
                "MagnifierCommand",
                typeof(ICommand),
                typeof(AssuranceInfoComponent), new PropertyMetadata(null, ChangedMagnifierCb));

        private static void ChangedMagnifierCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand value = e.NewValue as ICommand;
            AssuranceInfoComponent component = d as AssuranceInfoComponent;
            if (component != null)
            {
                component.UpdateMagnifierValue(value);
            }

        }
        private void UpdateMagnifierValue(ICommand command)
        {
            this.AssuranceCompany.MagnifierCommand = command;
            if (DataObjectValue != null)
            {
                this.AssuranceCompany.DataSource = DataObjectValue;
            }
        }
        /// <summary>
        ///  MagnifierCommand. it is a command for raising a magnifier.
        /// </summary>
        public ICommand MagnifierCommand
        {
            get { return (ICommand)GetValue(MagnifierCommandDependencyProperty); }
            set
            {
                SetValue(MagnifierCommandDependencyProperty, value);
            }
        }
        /// <summary>
        ///  Dependency preoperty for the assurance policy
        /// </summary>
        public static readonly DependencyProperty AssurancePolicyDependencyProperty =
            DependencyProperty.Register(
                "AssurancePolicyPath",
                typeof(string),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Dependency properties for tha assurance company path
        /// </summary>
        public static readonly DependencyProperty AssuranceCompanyDependencyProperty =
            DependencyProperty.Register(
                "AssuranceCompanyPath",
                typeof(string),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Dependency properties for tha assurance company path
        /// </summary>
        public static readonly DependencyProperty AssuranceKindDependencyProperty =
            DependencyProperty.Register(
                "AssuranceKind",
                typeof(string),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Dependency peroperty for the assurance company list
        /// </summary>
        public static readonly DependencyProperty AssuranceCompanyListDependencyProperty =
            DependencyProperty.Register(
                "AssuranceCompanyList",
                typeof(IEnumerable),
                typeof(AssuranceInfoComponent), new PropertyMetadata(null));
        /// <summary>
        ///  Dependency properties for the assurance phone path
        /// </summary>
        public static readonly DependencyProperty AssurancePhonePathDependencyProperty =
            DependencyProperty.Register(
                "AssistancePhonePath",
                typeof(string),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Dependnecy property for the policy
        /// </summary>
        public static readonly DependencyProperty AssurancePolicyPathDependencyProperty =
            DependencyProperty.Register(
                "AssistancePolicyPath",
                typeof(string),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Dependnecy propety for the data object
        /// </summary>
        public static readonly DependencyProperty DataObjectValueDependencyProperty =
            DependencyProperty.Register(
                "DataObjectValue",
                typeof(object),
                typeof(AssuranceInfoComponent), new PropertyMetadata(null, DataSourceCallCb));

        private static void DataSourceCallCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AssuranceInfoComponent info = d as AssuranceInfoComponent;
            info?.UpdateDo(e);
        }

        private void UpdateDo(DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var value = dependencyPropertyChangedEventArgs.NewValue;
            if (value != null)
            {
                AssuranceCompany.DataSource = value;
                ControlExt.SetDataSource(EntryDate, value);
                ControlExt.SetDataSource(LeavingDate, value);

                ControlExt.SetDataSource(Amount, value);
                ControlExt.SetDataSource(PolizaBox, value);
            }
        }


        public static readonly DependencyProperty AssistQueryDependencyProperty = DependencyProperty.Register(
            "AssistQuery", typeof(string), typeof(AssuranceInfoComponent));

        /// <summary>
        ///  Dependnecy property for the assurance amount
        /// </summary>
        public static readonly DependencyProperty AssuranceAmountPathDependencyProperty =
            DependencyProperty.Register(
                "AssuranceAmountPath",
                typeof(object),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));

        
        /// <summary>
        ///  Dependnecy propety for the data object
        /// </summary>
        public static readonly DependencyProperty AssuranceEntryDatePathDependencyProperty =
            DependencyProperty.Register(
                "AssuranceEntryDatePath",
                typeof(object),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty, EntryDateCallback));

        private static void EntryDateCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AssuranceInfoComponent comp = d as AssuranceInfoComponent;
            if (comp != null)
            {
                string value = e.NewValue as string;
                ControlExt.SetDataSourcePath(comp.EntryDate, value);
            }
        }


        // <summary>
        ///  Dependnecy propety for the data object
        /// </summary>
        public static readonly DependencyProperty AssuranceLeavingDatePathDependencyProperty =
            DependencyProperty.Register(
                "AssuranceLeavingDatePath",
                typeof(object),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty, LeavingDateCallback));

        private static void LeavingDateCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AssuranceInfoComponent comp = d as AssuranceInfoComponent;
            if (comp != null)
            {
                string value = e.NewValue as string;
                ControlExt.SetDataSourcePath(comp.LeavingDate, value);
            }
        }



        /// <summary>
        ///  Set or Get the assurance company path in the data object
        /// </summary>
        public string AssuranceKind
        {
            get { return (string)GetValue(AssuranceKindDependencyProperty); }
            set { SetValue(AssuranceKindDependencyProperty, value); }
        }
        /// <summary>
        ///  Set or Get the assurance company path in the data object
        /// </summary>
        public string AssuranceCompanyPath
        {
            get { return (string) GetValue(AssuranceCompanyDependencyProperty); }
            set { SetValue(AssuranceCompanyDependencyProperty, value); }
        }
        /// <summary>
        ///  Set or Get the assurance policy path in the data object
        /// </summary>
        public string AssurancePolicyPath
        {
            get { return (string)GetValue(AssurancePolicyDependencyProperty); }
            set { SetValue(AssurancePolicyDependencyProperty, value); }
        }

        /// <summary>
        ///  Set or Get the assurance assistant phone path in the data object
        /// </summary>
        public string AssistancePhonePath
        {
            get { return (string)GetValue(AssurancePhonePathDependencyProperty); }
            set { SetValue(AssurancePhonePathDependencyProperty, value); }
        }

        /// <summary>
        ///  Set or Get the assurance policy path in the data object
        /// </summary>
        public object DataObjectValue
        {
            get { return (string)GetValue(DataObjectValueDependencyProperty); }
            set { SetValue(DataObjectValueDependencyProperty, value); }
        }
        /// <summary>
        ///  Set or Get the assurance company list to show up in the grid.
        /// </summary>
        public IEnumerable AssuranceCompanyList
        {
            get { return (IEnumerable) GetValue(AssuranceCompanyListDependencyProperty); }
            set { SetValue(AssuranceCompanyListDependencyProperty, value); }
        }
        /// <summary>
        ///  Set or Get the assurance company list to show up in the grid.
        /// </summary>
        public string AssuranceAmountPath
        {
            get { return (string)GetValue(AssuranceAmountPathDependencyProperty); }
            set { SetValue(AssuranceAmountPathDependencyProperty, value); }
        }
        /// <summary>
        ///  Set or Get the assurance company list to show up in the grid.
        /// </summary>
        public string AssuranceEntryDatePath
        {
            get { return (string)GetValue(AssuranceEntryDatePathDependencyProperty); }
            set { SetValue(AssuranceEntryDatePathDependencyProperty, value); }
        }
        /// <summary>
        ///  Set por Get the assurance leaving path 
        /// </summary>
        public string AssuranceLeavingDatePath
        {
            get { return (string)GetValue(AssuranceLeavingDatePathDependencyProperty); }
            set { SetValue(AssuranceLeavingDatePathDependencyProperty, value); }
        }

        public string AssistQuery
        {
            get { return (string) GetValue(AssistQueryDependencyProperty); }
            set {  SetValue(AssistQueryDependencyProperty, value);}
        }
        /// <summary>
        ///  Get or Get the assurance info component.
        /// </summary>
        public AssuranceInfoComponent()
        {
            InitializeComponent();
            EntryDate.DataDatePickerChanged += EntryDate_DataDatePickerChanged;
            Amount.TextChanged += Amount_TextChanged;
            Amount.LostFocus += Amount_LostFocus;
            PolizaBox.TextChanged += PolizaBox_TextChanged;
            PolizaBox.LostFocus += PolizaBox_LostFocus;
            AssuranceCompany.ItemChangedCommand = ItemChangedCommand;
            AssuranceCompany.MagnifierCommand = MagnifierCommand;
            AssuranceInfoLayout.DataContext = this;
        }

        private void PolizaBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((changedPolizaText) && (ItemChangedCommand != null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["DataObject"] = ControlExt.GetDataSource(this.Amount);
                objectName["DataSourcePath"] = ControlExt.GetDataSourcePath(this.Amount);
                objectName["ChangedValue"] = this.Amount.Text;
                ItemChangedCommand.Execute(objectName);
                changedText = false;
            }
        }
        private void PolizaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            changedPolizaText = true;           
        }

        private void Amount_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((changedText) && (ItemChangedCommand != null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["DataObject"] = ControlExt.GetDataSource(this.Amount);
                objectName["DataSourcePath"] = ControlExt.GetDataSourcePath(this.Amount);
                objectName["ChangedValue"] = this.Amount.Text;
                ItemChangedCommand.Execute(objectName);
                changedText = false;
            }
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            changedText = true;
        }
        private void EntryDate_DataDatePickerChanged(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
            DataDatePicker.DataDatePickerEventArgs ev = e as DataDatePicker.DataDatePickerEventArgs;
            if (ev != null)
            {
                valueDictionary = ev.ChangedValuesObjects;
                valueDictionary["DataSourcePath"] = ControlExt.GetDataSourcePath(EntryDate);
                if (ItemChangedCommand != null)
                {
                    this.ItemChangedCommand.Execute(valueDictionary);
                }
            }
        }
    }
}
