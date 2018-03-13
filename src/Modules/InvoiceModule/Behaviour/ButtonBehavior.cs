using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid;
using System.Windows.Input;
using System.IO;
using System.Windows;
using System.Xml;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;

namespace InvoiceModule.Behaviour
{
    /// <summary>
    ///  This is a button behavior.
    /// </summary>
    class ButtonBehavior : Behavior<ButtonAdv>
    {

        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty assistNameProperty = DependencyProperty.Register("AssistName", typeof(string), typeof(ButtonBehavior), 
            new UIPropertyMetadata(string.Empty));
        
        /// <summary>
        /// Set or Get the AssistName property.
        /// </summary>
        public string AssistName
        {
            get
            {
                return (string) GetValue(assistNameProperty);
            }
            set
            {
                SetValue(assistNameProperty, value);
            }
        }
        /// <summary>
        ///  OnAttached property. Attach the property to an item.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            var currentPathName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var myPath = currentPathName.Split('/');
            string[] pathVector = new string[myPath.Length - 1];
            for(int i = 0; i < myPath.Length -1; ++i)
            {
                pathVector[i] = myPath[i];
            }
            var currentPath = Path.Combine(pathVector);
            var path = Path.Combine(currentPath, "images/gobutton.jpg");
            path = path.Replace("C:", "C:\\");
            BitmapImage image = new BitmapImage(new Uri(path));
            this.AssociatedObject.SmallIcon = image;
        }
        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

    }
}
