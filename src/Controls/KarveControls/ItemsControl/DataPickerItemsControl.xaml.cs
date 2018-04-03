using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveControls.Generic;
using Prism.Commands;

namespace KarveControls.ItemsControl
{
        /// <summary>
        ///  Collection of controls in DataPicker.
        /// </summary>
        public partial class DataPickerItemsControl : UserControl
        {
            private DelegateCommand<object> _localCommand;

            /// <summary>
            ///  This expose the change action dependency property.
            /// </summary>
            public static DependencyProperty ChangeActionDependencyProperty
                = DependencyProperty.Register(
                    "ChangeActionCommand",
                    typeof(ICommand),
                    typeof(DataPickerItemsControl));
            /// <summary>
            ///  Localization of change action.
            /// </summary>
            public ICommand ChangeActionCommand
            {
                get { return (ICommand)GetValue(ChangeActionDependencyProperty); }
                set { SetValue(ChangeActionDependencyProperty, (ICommand)value); }
            }
            /// <summary>
            ///  This trigger a command during a change.
            /// </summary>
            /// <param name="obj">parameters of the change</param>
            private void OnChangeField(object obj)
            {
                ICommand value = ChangeActionCommand;
                if (value != null)
                    value.Execute(obj);
            }
            /// <summary>
            /// Collection of labels.
            /// </summary>
            public static DependencyProperty LabelEnumerable = DependencyProperty.Register("Localization",
                typeof(IEnumerable<string>),
                typeof(DataPickerItemsControl),
                new PropertyMetadata(new List<string>(), OnLabelSourceChanged));
            /// <summary>
            /// Handle the change of a label in a collection datapicker controls.
            /// </summary>
            /// <param name="d">Dependency object of the label</param>
            /// <param name="e">Event changed</param>
            private static void OnLabelSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataPickerItemsControl control = d as DataPickerItemsControl;
                control.OnLocaleLabelChanged(e);
            }
            /// <summary>
            ///  This change the locale.
            /// </summary>
            /// <param name="e"></param>
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
                    typeof(DataPickerItemsControl),
                    new PropertyMetadata(null, OnDataSourceChanged));
            /// <summary>
            ///  Set or Get the data source of the control collection.
            /// </summary>
            public object DataSource
            {
                get { return GetValue(DataSourceDependencyProperty); }
                set { SetValue(DataSourceDependencyProperty, value); }
            }
            /// <summary>
            ///  DataSourceChanged. Change of a data source.
            /// </summary>
            /// <param name="d">Dependency object of a data picker</param>
            /// <param name="e">Dependency object of a data source</param>
            private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataPickerItemsControl control = d as DataPickerItemsControl;
                if (control != null)
                {
                    control.OnDataSourceChanged(e);
                }
            }            
            /// <summary>
            /// DataSourceChanged. This change the source of a program.
            /// </summary>
            /// <param name="e">Event of a dependency property.</param>
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
                        listOfObjects[i].LabelText = localizationStrings[i];
                    }
                }

                this.DataControl.ItemsSource = listOfObjects;
            }

            /// <summary>
            ///  Items control for multiple data picker with a list of label and bindings.
            /// </summary>
            public DataPickerItemsControl()
            {
                _localCommand = new DelegateCommand<object>(OnChangeField);
                InitializeComponent();
            }
        }
    }
