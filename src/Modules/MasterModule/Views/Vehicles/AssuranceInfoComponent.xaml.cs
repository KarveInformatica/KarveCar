using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MasterModule.Views.Vehicles
{
    /// <summary>
    /// Interaction logic for AssuranceInfoComponent
    /// .xaml
    /// </summary>
    public partial class AssuranceInfoComponent : UserControl
    {


        /// <summary>
        ///  Dependency preoperty for the assurance policy
        /// </summary>
        public static readonly DependencyProperty ItemChangedDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(AssuranceInfoComponent), new PropertyMetadata(null, ItemChangedCommandCb));

        private static void ItemChangedCommandCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
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
                typeof(AssuranceInfoComponent), new PropertyMetadata(null));


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
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));


        // <summary>
        ///  Dependnecy propety for the data object
        /// </summary>
        public static readonly DependencyProperty AssuranceLeavingDatePathDependencyProperty =
            DependencyProperty.Register(
                "AssuranceLeavingDatePath",
                typeof(object),
                typeof(AssuranceInfoComponent), new PropertyMetadata(string.Empty));
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

        public string AssuranceLeavingDatePath
        {
            get { return (string)GetValue(AssuranceLeavingDatePathDependencyProperty); }
            set { SetValue(AssuranceLeavingDatePathDependencyProperty, value); }
        }

        public AssuranceInfoComponent()
        {
            InitializeComponent();
            AssuranceInfoLayout.DataContext = this;
        }
    }
}
