namespace KarveCommon.Generic
{
    using Microsoft.Practices.ServiceLocation;
    using System;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Regions;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Interactivity;

    /// <summary>
    /// Shows a lazily instantiated window which supports region navigation via uri and passing of parameters
    /// </summary>
    public class LazyPopupWindowAction : TriggerAction<FrameworkElement>
    {
        protected INotification notification;
        private readonly IRegionManager regionManager;
        public LazyPopupWindowAction()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            }
        }

        /// <summary>
        /// Determines if the content should be shown in a modal window or not.
        /// </summary>
        public static readonly DependencyProperty IsModalProperty =
            DependencyProperty.Register(
                "IsModal",
                typeof(bool),
                typeof(LazyPopupWindowAction),
                new PropertyMetadata(null));

        /// <summary>
        /// Determines if the content should be initially shown centered over the view that raised the interaction request or not.
        /// </summary>
        public static readonly DependencyProperty CenterOverAssociatedObjectProperty =
            DependencyProperty.Register(
                "CenterOverAssociatedObject",
                typeof(bool),
                typeof(LazyPopupWindowAction),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets if the window will be modal or not.
        /// </summary>
        public bool IsModal
        {
            get { return (bool)GetValue(IsModalProperty); }
            set { SetValue(IsModalProperty, value); }
        }

        /// <summary>
        /// Gets or sets if the window will be initially shown centered over the view that raised the interaction request or not.
        /// </summary>
        public bool CenterOverAssociatedObject
        {
            get { return (bool)GetValue(CenterOverAssociatedObjectProperty); }
            set { SetValue(CenterOverAssociatedObjectProperty, value); }
        }

        /// <summary>
        /// Gets or sets the navigation uri
        /// </summary>
        public string NavigationUri
        {
            get { return (string)GetValue(NavigationUriProperty); }
            set { SetValue(NavigationUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationUriProperty =
            DependencyProperty.Register("NavigationUri", typeof(string), typeof(LazyPopupWindowAction), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the navigation parameter
        /// </summary>
        public object NavigationParameter
        {
            get { return (object)GetValue(NavigationParameterProperty); }
            set { SetValue(NavigationParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationParameterProperty =
            DependencyProperty.Register("NavigationParameter", typeof(object), typeof(LazyPopupWindowAction), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the region name
        /// </summary>
        public string RegionName
        {
            get { return (string)GetValue(RegionNameProperty); }
            set { SetValue(RegionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RegionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.Register("RegionName", typeof(string), typeof(LazyPopupWindowAction), new PropertyMetadata(null));


        protected override void Invoke(object parameter)
        {
            InteractionRequestedEventArgs args = parameter as InteractionRequestedEventArgs;
            if (args == null)
                return;

            notification = args.Context;
            Window wrapperWindow = this.GetWindow(args.Context);
            wrapperWindow.SizeToContent = SizeToContent.WidthAndHeight;

            // We invoke the callback when the interaction's window is closed.
            var callback = args.Callback;
            EventHandler handler = null;
            handler =
                (o, e) =>
                {
                    wrapperWindow.Closed -= handler;
                    wrapperWindow.Content = null;
                    if (callback != null) callback();
                };
            wrapperWindow.Closed += handler;

            if (this.CenterOverAssociatedObject && this.AssociatedObject != null)
            {
                // If we should center the popup over the parent window we subscribe to the SizeChanged event
                // so we can change its position after the dimensions are set.
                SizeChangedEventHandler sizeHandler = null;
                sizeHandler =
                    (o, e) =>
                    {
                        wrapperWindow.SizeChanged -= sizeHandler;

                        FrameworkElement view = this.AssociatedObject;
                        Point position = view.PointToScreen(new Point(0, 0));

                        wrapperWindow.Top = position.Y + ((view.ActualHeight - wrapperWindow.ActualHeight) / 2);
                        wrapperWindow.Left = position.X + ((view.ActualWidth - wrapperWindow.ActualWidth) / 2);
                    };
                wrapperWindow.SizeChanged += sizeHandler;
            }

            NavigationParameters navigationParameters = null;
            if (this.NavigationParameter != null)
            {
                navigationParameters = new NavigationParameters();
                navigationParameters.Add("Parameter", this.NavigationParameter);
            }

            regionManager.RequestNavigate(this.RegionName, new Uri(this.NavigationUri, UriKind.Relative), navigationParameters);

            if (this.IsModal)
            {
                wrapperWindow.ShowDialog();
            }
            else
            {
                wrapperWindow.Show();
            }
        }

        protected virtual Window GetWindow(INotification notification)
        {
            Window window = new Window();

            // If the WindowContent does not have its own DataContext, it will inherit this one.
            window.DataContext = notification;
            window.Title = notification.Title;

            window.ContentRendered += window_ContentRendered;
            window.Closed += window_Closed;

            if (!this.regionManager.Regions.ContainsRegionWithName(this.RegionName))
            {
                RegionManager.SetRegionManager(window, this.regionManager);
                RegionManager.SetRegionName(window, this.RegionName);
            }

            return window;
        }

        private void window_Closed(object sender, EventArgs e)
        {
            Window window = sender as Window;

            window.Closed -= window_Closed;
            window.ContentRendered -= window_ContentRendered;

            regionManager.Regions.Remove(this.RegionName);
        }

        private void window_ContentRendered(object sender, EventArgs e)
        {
            Window window = sender as Window;
            if (window == null || window.Content == null)
                return;

            IInteractionRequestAware interactionAware;

            // If the WindowContent implements IInteractionRequestAware we set the corresponding properties.
            interactionAware = window.Content as IInteractionRequestAware;
            if (interactionAware != null)
            {
                interactionAware.Notification = notification;
                interactionAware.FinishInteraction = () => window.Close();
            }

            // If the WindowContent's DataContext implements IInteractionRequestAware we set the corresponding properties.
            var content = window.Content as FrameworkElement;
            if (content != null)
            {
                interactionAware = content.DataContext as IInteractionRequestAware;
                if (interactionAware != null)
                {
                    interactionAware.Notification = notification;
                    interactionAware.FinishInteraction = () => window.Close();
                }
            }
        }
    }
}

