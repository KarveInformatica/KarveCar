using System;
using System.Collections;
using System.Collections.Generic;
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
using KarveControls.Generic;
using Prism.Commands;

namespace KarveControls.ItemsControl
{
 
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
                    typeof(global::KarveControls.ItemsControl.DataPickerItemsControl));
            /// <summary>
            ///  localization of strings.
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
            /// Localization stuff.
            /// </summary>
            public static DependencyProperty LabelEnumerable = DependencyProperty.Register("Localization",
                typeof(IEnumerable<string>),
                typeof(global::KarveControls.ItemsControl.DataPickerItemsControl),
                new PropertyMetadata(new List<string>(), OnLabelSourceChanged));
            /// <summary>
            /// Label source changed.
            /// </summary>
            /// <param name="d"></param>
            /// <param name="e"></param>
            private static void OnLabelSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                global::KarveControls.ItemsControl.DataPickerItemsControl control = d as global::KarveControls.ItemsControl.DataPickerItemsControl;
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
                    typeof(global::KarveControls.ItemsControl.DataPickerItemsControl),
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
                global::KarveControls.ItemsControl.DataPickerItemsControl control = d as global::KarveControls.ItemsControl.DataPickerItemsControl;
                if (control != null)
                {
                    control.OnDataSourceChanged(e);
                }
            }
            /// <summary>
            ///  DataSourceChanged
            /// </summary>
            /// <param name="d"></param>
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
