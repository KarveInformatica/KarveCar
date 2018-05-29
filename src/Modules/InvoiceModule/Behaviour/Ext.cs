using System.Windows;

namespace InvoiceModule.Behaviour
{
    /// <summary>
    ///     Extension class for attached properties.
    /// </summary>
    public static class Ext
    {
        /// <summary>
        ///     This is a property for the cell presentation.
        /// </summary>
        public static readonly DependencyProperty AssistNameProperty =
            DependencyProperty.RegisterAttached("AssistName", typeof(string), typeof(Ext));

        /// <summary>
        ///     Set the name of the assist.
        /// </summary>
        public static void SetAssistName(UIElement ext, string command)
        {
            ext.SetValue(AssistNameProperty, command);
        }

        /// <summary>
        ///     Get the name of a button for navigation.
        /// </summary>
        /// <param name="d">Dependency Properties</param>
        /// <param name="e">Value</param>
        /// <returns></returns>
        public static string GetAssistName(UIElement ext)
        {
            return ext.GetValue(AssistNameProperty) as string;
        }
    }
}