using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MasterModule.Views.VehiControls
{
    internal class VehiExt: DependencyObject
    {
        #region PathCollection
        /// <summary>
        ///  Path collection attached properties. This is useful to inject a set of path inside a component.
        /// </summary>
        public static readonly DependencyProperty PathCollection =
            DependencyProperty.RegisterAttached("PathCollection",
                typeof(IEnumerable<string>),
                typeof(VehiExt),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Path collection changed.
        /// </summary>
        /// <param name="control">Control to be collected</param>
        /// <param name="source">Value</param>
        public static void SetPathCollection(DependencyObject d, string source)
        {
            d.SetValue(PathCollection, source);
        }
        /// <summary>
        ///  Get the path collection changed
        /// </summary>s
        /// <param name="control">User control of VehiControls</param>
        /// <returns></returns>
        public static string GetPathCollection(DependencyObject control)
        {
            return control.GetValue(PathCollection) as string;
        }
        #endregion
        #region PathCollection
        /// <summary>
        ///  Path collection attached properties. This is useful to inject a set of path inside a component.
        /// </summary>
        public static readonly DependencyProperty DataSource =
            DependencyProperty.RegisterAttached("DataSource",
                typeof(object),
                typeof(VehiExt),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Path collection changed.
        /// </summary>
        /// <param name="control">Control to be collected</param>
        /// <param name="source">Value</param>
        public static void SetDataSource(DependencyObject d, string source)
        {
            d.SetValue(DataSource, source);
        }
        /// <summary>
        ///  Get the path collection changed
        /// </summary>s
        /// <param name="control">User control of VehiControls</param>
        /// <returns></returns>
        public static object GetDataSource(DependencyObject control)
        {
         
               return control.GetValue(DataSource);
               
           
        }
        #endregion
        #region AssistCommand
        /// <summary>
        ///  This is a metadata that describe a component.
        /// </summary>
        public static readonly DependencyProperty AssistCommandDependencyProperty =
            DependencyProperty.RegisterAttached(
                "AssistCommand",
                typeof(ICommand),
                typeof(VehiExt),
                new UIPropertyMetadata(null, AssistCommandChanged));

        private static void AssistCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object sourceNew = e.NewValue;
            SetAssistCommand(d, sourceNew);
        }
        private static ICommand GetAssistCommand(DependencyObject ds)
        {
            return (ICommand) ds.GetValue(AssistCommandDependencyProperty);
        }
        private static void SetAssistCommand(DependencyObject ds, object value)
        {
            ds.SetValue(AssistCommandDependencyProperty, value);
        }
        /// <summary>
        ///  Kind of data allowed for this component.
        /// </summary>
        public ICommand AssistCommand
        {
            get { return (ICommand)GetValue(AssistCommandDependencyProperty); }
            set { SetValue(AssistCommandDependencyProperty, value); }
        }
        #endregion
      
        /// <summary>
        ///  This is a metadata that describe a component.
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandDependencyProperty =
            DependencyProperty.RegisterAttached(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(VehiExt),
                new UIPropertyMetadata(null, ItemCommandChanged));
        /// <summary>
        /// Event for changing
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">New Value</param>
        public static void ItemCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object sourceNew = e.NewValue;
            SetItemChangedCommand(d, sourceNew);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static ICommand GetItemChangedCommand(DependencyObject ds)
        {
            return (ICommand)ds.GetValue(ItemChangedCommandDependencyProperty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sourceNew"></param>
        public static void SetItemChangedCommand(DependencyObject ds, object sourceNew)
        {
            ds.SetValue(ItemChangedCommandDependencyProperty, sourceNew);
        }
        

    }
}
