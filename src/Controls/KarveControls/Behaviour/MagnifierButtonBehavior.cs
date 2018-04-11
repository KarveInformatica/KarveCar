using System.Collections.Generic;
using System.Windows;
using System.Windows.Interactivity;
using KarveControls.Interactivity;
using System.Windows.Controls;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  MagnifierButtonBehaviour. 
    /// </summary>
    public class MagnifierButtonBehaviour: Behavior<Button>
    {
        public static readonly DependencyProperty assistNameProperty = DependencyProperty.Register("AssistName", typeof(string), typeof(MagnifierButtonBehaviour),
            new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty requestControllerProperty = DependencyProperty.Register("RequestController", typeof(RequestController), typeof(MagnifierButtonBehaviour), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty sourceViewProperty = DependencyProperty.Register("SourceView", typeof(IEnumerable<object>), typeof(MagnifierButtonBehaviour));

        public static readonly DependencyProperty selectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(MagnifierButtonBehaviour));

        public MagnifierButtonBehaviour()
        {
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Click += OnClick;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= OnClick;
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
          
            if (RequestController != null)
            {
                RequestController.ShowAssistView<object>(AssistName, SourceView);
                SelectedItem = RequestController.SelectedItem;
            }
           
        }
        /// <summary>
        /// Set or Get the AssistName property.
        /// </summary>
        public string AssistName
        {
            get
            {
                return (string)GetValue(assistNameProperty);
            }
            set
            {
                SetValue(assistNameProperty, value);
            }
        }

        /// <summary>
        /// Set or Get the SelectedItem property.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return (string)GetValue(selectedItemProperty);
            }
            set
            {
                SetValue(selectedItemProperty, value);
            }
        }
        /// <summary>
        /// Set or Get the AssistName property.
        /// </summary>
        public RequestController RequestController
        {
            get
            {
                return (RequestController)GetValue(requestControllerProperty);
            }
            set
            {
                SetValue(requestControllerProperty, value);
            }
        }

        /// <summary>
        /// Set or Get the Source property.
        /// </summary>
        public IEnumerable<object> SourceView
        {
            get
            {
                return (IEnumerable<object>)GetValue(sourceViewProperty);
            }
            set
            {
                SetValue(sourceViewProperty, value);
            }
        }

    

    }
}
