using KarveControls;
using Prism.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using KarveControls.Generic;

namespace KarveControls.DataFieldItemsControl
{

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DataFieldItemsControl : UserControl
    {
        private DelegateCommand<object> _localCommand;
        /// <summary>
        ///  Command for detecting a change. It comes triggered when it changes.
        /// </summary>
        public static DependencyProperty ChangeActionDependencyProperty
        = DependencyProperty.Register(
            "ChangeActionCommand",
            typeof(ICommand),
            typeof(DataFieldItemsControl));
        /// <summary>
        ///  localization of strings.
        /// </summary>
        public ICommand ChangeActionCommand
        {
            get { return (ICommand)GetValue(ChangeActionDependencyProperty); }
            set { SetValue(ChangeActionDependencyProperty, (ICommand)value); }
        }

        private void OnChangeField(object obj)
        {
            ICommand value = ChangeActionCommand;
            if (value!=null)
            value.Execute(obj);
        }
        /// <summary>
        ///  Localization strings for the lablels.
        /// </summary>
        public static DependencyProperty LabelEnumerable = DependencyProperty.Register("Localization",
            typeof(IEnumerable<string>),
            typeof(DataFieldItemsControl), 
            new PropertyMetadata(new List<string>(), OnLabelSourceChanged));
        
        private static void OnLabelSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldItemsControl control = d as DataFieldItemsControl;
            control.OnLocaleLabelChanged(e);
        }

        private void OnLocaleLabelChanged(DependencyPropertyChangedEventArgs e)
        {
            List<string> localizationStrings = e.NewValue as List<string>;
            if (localizationStrings != null)
            {
                ComponentFiller filler = new ComponentFiller();
                List<ComponentFiller.UiMetaObject> listOfObjects = filler.GetCollectionProperties(DataSource);
                
                for (int i = 0; i < localizationStrings.Count; i++)
                {
                    if (i < listOfObjects.Count)
                    {
                        listOfObjects[i].LabelText = localizationStrings[i];
                    }
                }
                for (int i = 0; i < listOfObjects.Count; i++)
                {
                    listOfObjects[i].ChangedItem = _localCommand;
                }
                this.TextBoxCollection.ItemsSource = listOfObjects;
            }
        }

        /// <summary>
        ///  localization of strings.
        /// </summary>
        public IEnumerable<string> Localization
        {
            get { return (IEnumerable<string>)GetValue(LabelEnumerable); }
            set { SetValue(LabelEnumerable, (IEnumerable)value); }
        }
        /// <summary>
        /// Data Source Dependency Property
        /// </summary>
        public static DependencyProperty DataSourceDependencyProperty
            = DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(DataFieldItemsControl),
                new PropertyMetadata(null, OnDataSourceChanged));
        /// <summary>
        ///  Data source property handy way to associate a data field to a value.
        /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceDependencyProperty); }
            set { SetValue(DataSourceDependencyProperty, value); }
        }

        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldItemsControl control = d as DataFieldItemsControl;
            if (control != null)
            {
                control.OnDataSourceChanged(e);
            }
        }
        /// <summary>
        ///  DataSourceChanged
        /// </summary>
        /// <param name="e">Event args for the property change</param>
        private void OnDataSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            object value = e.NewValue;
            ComponentFiller filler = new ComponentFiller();
            List<ComponentFiller.UiMetaObject> listOfObjects = filler.GetCollectionProperties(value);
            int count = listOfObjects.Count<ComponentFiller.UiMetaObject>();
            IList<string> localizationStrings = Localization as List<string>;
            int secondCount = localizationStrings.Count<string>();
            // i am sure that the component filler gives us a list of objects.
            for (int i = 0; i < count; i++)
            {
                listOfObjects[i].ChangedItem = _localCommand;
            }
            if (count == secondCount)
            {
                for (int i = 0; i < count; i++)
                {
                    listOfObjects[i].LabelText = localizationStrings[i] ;
                }
            }
            this.TextBoxCollection.ItemsSource = listOfObjects;
        }
       
        /// <summary>
        /// Data Field items control. 
        /// It is an user control that allow us to put different items together with the same object.
        /// </summary>
        public DataFieldItemsControl()
        {
            _localCommand = new DelegateCommand<object>(OnChangeField);
            InitializeComponent();
        }
    }
}
