using KarveCommon.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace KarveTest.Behavior
{
    /// <summary>
    ///  This class is useful for loading a xaml component and putting inside
    ///  a view box.
    /// </summary>
    public static class XamlUnitTestHelper
    {
        private static ParserContext _XamlContext;
        private static Viewbox _Viewbox;

        /// <summary>
        /// Loads the xaml into a Viewbox so that we can parse it and verify its working.
        /// </summary>
        /// <param name="xamlFilePath">The xaml file path.</param>
        public static void LoadXaml(string xamlFilePath)
        {
            String xamlFileStream = File.ReadAllText(xamlFilePath);
            if (xamlFileStream.IndexOf("x:Class=") != -1)
                xamlFileStream = Regex.Replace(xamlFileStream, "x:Class=\\\".+([^\\\"])\\\"", "");

            object obj = XamlReader.Load(new MemoryStream(new System.Text.ASCIIEncoding().GetBytes(xamlFileStream)), XamlContext);
            _Viewbox = new Viewbox
            {
                Child = ((UIElement)obj)
            };
            _Viewbox.UpdateLayout();
            FlushDispatcher();
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T">This is the type of control that is being searched for</typeparam>
        /// <param name="name">The name of the control that is being searched for</param>
        /// <returns>If the control is found a reference to this control is returned else null</returns>
        public static T GetObject<T>(string name) where T : class
        {
            if (_Viewbox != null && _Viewbox.Child != null)
            {
                FrameworkElement child = _Viewbox.Child as FrameworkElement;
                // we need to rebuild the visual tree since we are crafting xaml.
                child.ApplyTemplate();
                // found the elements of a given tyme in the visual tree
                int count = VisualTreeHelper.GetChildrenCount(child);
              
                for(int i = 0; i < count; ++i)
                {
                    var myname = VisualTreeHelper.GetChild(child, i);
                     
                }
            }
            return null;
        }
        

        /// <summary>
        /// Gets the xaml context, to be used by the XamlReader.
        /// </summary>
        /// <value>The xaml context.</value>
        private static ParserContext XamlContext
        {
            get
            {
                if (_XamlContext == null)
                {
                    _XamlContext = new ParserContext();
                    _XamlContext.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    
                }
                return _XamlContext;
            }
        }
        /// <summary>
        /// Flushes the dispatcher, needed to get data binding working when the control is not actually rendered to screen
        /// </summary>
        private static void FlushDispatcher()
        {
            FlushDispatcher(Dispatcher.CurrentDispatcher);
        }
        /// <summary>
        /// Flushes the dispatcher, needed to get data binding working when the control is not actually rendered to screen
        /// </summary>
        private static void FlushDispatcher(Dispatcher ctx)
        {
            FlushDispatcher(ctx, DispatcherPriority.SystemIdle);
        }
        /// <summary>
        /// Flushes the dispatcher, needed to get data binding working when the control is not actually rendered to screen
        /// </summary>
        private static void FlushDispatcher(Dispatcher ctx, DispatcherPriority priority)
        {
            ctx.Invoke(priority, new DispatcherOperationCallback(delegate { return null; }), null);
        }
    }
}
