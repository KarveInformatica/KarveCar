using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;

namespace InvoiceModule.Behaviour
{
    /// <summary>
    ///     This is a button behavior.
    /// </summary>
    internal class ButtonBehavior : Behavior<ButtonAdv>
    {
        /// <summary>
        ///     This is a property for the cell presentation.
        /// </summary>
        public static readonly DependencyProperty assistNameProperty = DependencyProperty.Register("AssistName",
            typeof(string), typeof(ButtonBehavior),
            new UIPropertyMetadata(string.Empty));

        /// <summary>
        ///     Set or Get the AssistName property.
        /// </summary>
        public string AssistName
        {
            get => (string) GetValue(assistNameProperty);
            set => SetValue(assistNameProperty, value);
        }

        /// <summary>
        ///     OnAttached property. Attach the property to an item.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            var currentPathName = Assembly.GetExecutingAssembly().CodeBase;
            var myPath = currentPathName.Split('/');
            var pathVector = new string[myPath.Length - 1];
            for (var i = 0; i < myPath.Length - 1; ++i) pathVector[i] = myPath[i];
            var currentPath = Path.Combine(pathVector);
            var path = Path.Combine(currentPath, "images/gobutton.jpg");
            path = path.Replace("C:", "C:\\");
            var image = new BitmapImage(new Uri(path));
            AssociatedObject.SmallIcon = image;
        }

        /// <summary>
        ///     Detach the attached values.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}