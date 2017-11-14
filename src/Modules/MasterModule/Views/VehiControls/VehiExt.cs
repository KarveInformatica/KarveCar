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
        private static ICommand GetItemChangedCommand(DependencyObject ds)
        {
            return (ICommand)ds.GetValue(AssistCommandDependencyProperty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sourceNew"></param>
        private static void SetItemChangedCommand(DependencyObject ds, object sourceNew)
        {
            ds.SetValue(AssistCommandDependencyProperty, sourceNew);
        }
        /// <summary>
        ///  Kind of data allowed for this component.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand)GetValue(AssistCommandDependencyProperty); }
            set { SetValue(AssistCommandDependencyProperty, value); }
        }

    }
}
