using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataField.xaml
    /// </summary>
    public partial class DataField : UserControl
    {

        
        public enum DataType
        {
            DoubleField, IntegerField, NifField, Any
        }

        public enum Encoding
        {
            Latin, Utf8
        }
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnDescriptionChange));

      
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnDataAllowedChange));


        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        public static readonly DependencyProperty DataEncodingDependencyProperty =
            DependencyProperty.Register(
                "DataEncoding",
                typeof(DataType),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        /* This modulate the label visible or not*/
        public static readonly DependencyProperty LabelVisible = DependencyProperty.Register("LabelVisible",
        typeof(Boolean),
        typeof(DataField),
        new PropertyMetadata(string.Empty, OnLabelVisibleChange));

       
    public readonly static DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataField), 
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public static readonly  DependencyProperty IsReadOnlyDependencyProperty = 
            DependencyProperty.Register("IsReadOnly",
                                        typeof(bool),
                                        typeof(DataField), 
                                        new PropertyMetadata(false, OnReadOnlyDependencyProperty));
        
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(DataField), 
                new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataField), 
                new PropertyMetadata(string.Empty, OnDataFieldChanged));

        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnItemSourceChanged));

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(SearchTextBox), new PropertyMetadata(new DataTable(), OnDataFieldItemSourceChanged));

       
        private static void OnSearchTextBoxItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnReadOnlyDependencyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnDataFieldItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnDescriptionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        public DataField()
        {
            InitializeComponent();
        }
    }
}
