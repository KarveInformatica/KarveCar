using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        ///  Set the name of a button for navigation.
        /// </summary>
        /// <param name="d">Depedency property</param>
        /// <param name="e">Value</param>
        public static void SetAssistName(UIElement ext, string command)
        {
            ext.SetValue(AssistNameProperty, command);
        }
        /// <summary>
        ///  Get the name of a button for navigation.
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
