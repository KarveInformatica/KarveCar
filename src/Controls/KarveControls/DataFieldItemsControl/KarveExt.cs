using System;
using System.Windows;
namespace KarveControls
{
    /// <summary>
    ///  This is a list of attached properties to be associated to each karve control.
    /// </summary>
    public class KarveExt: DependencyObject
    {
        /// <summary>
        ///  DataType to be allowed.
        /// </summary>
        public enum DataType
        {
            /// <summary>
            ///  Double kind of data.
            /// </summary>
            DoubleField, 
            /// <summary>
            /// Integer field of the component.
            /// </summary>
            IntegerField,
            /// <summary>
            ///  Nif field of the component.
            /// </summary>
            NifField,
            /// <summary>
            ///  Iban field of the component.
            /// </summary>
            IbanField,
            /// <summary>
            ///  Any other kind of field control.
            /// </summary>
            Any,
            /// <summary>
            ///  Email kind field of the control.
            /// </summary>
            Email,
            /// <summary>
            ///  Bank Account field of the control.
            /// </summary>
            BankAccount,
            /// <summary>
            ///  Swift field of the control.
            /// </summary>
            Swift,
            /// <summary>
            ///  Datatime field of the contorl.
            /// </summary>
            DateTime
        }
        #region Description
        /// <summary>
        ///  This is a metadata that describe a component.
        /// </summary>
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.RegisterAttached(
                "Description",
                typeof(string),
                typeof(KarveExt),
                new PropertyMetadata(String.Empty));
        #endregion
        #region DataAllowed
        /// <summary>
        ///  This is the kind of data allowd.
        /// </summary>
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.RegisterAttached(
                "DataAllowed",
                typeof(DataType),
                typeof(KarveExt),
                new PropertyMetadata(DataType.Any));
        /// <summary>
        ///  Kind of data allowed for this component.
        /// </summary>
        public DataType DataAllowed
        {
            get { return (DataType) GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }

        #endregion
        #region ItemSource
        /// <summary>
        ///  DataSource: data table or data object associaed with this control.
        /// </summary>
        public static DependencyProperty DataSourceDependencyProperty
            = DependencyProperty.RegisterAttached(
                "DataSource",
                typeof(object),
                typeof(KarveExt),
                new PropertyMetadata(null));
       /// <summary>
       ///  Set/Gey the data source
       /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceDependencyProperty); }
            set { SetValue(DataSourceDependencyProperty, value); }
        }
    

        #endregion
        #region TableName
        /// <summary>
        ///  Dependency property associated with the name of the table.
        /// </summary>
        public static readonly DependencyProperty DbTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(KarveExt),
                new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the name of the table associated to this control.
        /// </summary>
        public string TableName
        {
            get { return (string) GetValue(DbTableNameDependencyProperty); }
            set { SetValue(DbTableNameDependencyProperty, value); }
        }
        #endregion
    }
}
