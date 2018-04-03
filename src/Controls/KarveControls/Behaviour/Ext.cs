using System.Windows;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  Assist Extension name.
    /// </summary>
    public class AssistExt
    {
        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty AssistNameProperty = DependencyProperty.RegisterAttached("AssistName", typeof(string), typeof(AssistExt));
       
        /// <summary>
        /// Set the assist name attached property to a component.
        /// An assist is a command from a magnifier to the viewmodel.
        /// </summary>
        /// <param name="ext">Control or UIElement</param>
        /// <param name="command">Assist name to be associated</param>
        public static void SetAssistName(UIElement ext, string command)
        {
            ext.SetValue(AssistNameProperty, command);
        }
        /// <summary>
        ///  Get the name associated with the assist.
        /// An assist is a command from a magnifier to the viewmodel.
        /// </summary>
        /// <param name="ext">UI control to be used in an assist</param>
        /// <returns></returns>
        public static string GetAssistName(UIElement ext)
        {
            return ext.GetValue(AssistNameProperty) as string;
        }


    }
}
