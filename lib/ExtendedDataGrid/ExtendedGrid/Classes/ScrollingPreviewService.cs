using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace ExtendedGrid.Classes
{
    /// <summary>
    ///     Displays a ToolTip next to the ScrollBar thumb while it is being dragged.
    /// </summary>
    public static class ScrollingPreviewService
    {
        public static DataTemplate GetVerticalScrollingPreviewTemplate(DependencyObject obj)
        {
            return (DataTemplate) obj.GetValue(VerticalScrollingPreviewTemplateProperty);
        }

        public static void SetVerticalScrollingPreviewTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(VerticalScrollingPreviewTemplateProperty, value);
        }

        /// <summary>
        ///     Allows for specifying a ContentTemplate for a ToolTip that will appear next to the 
        ///     vertical ScrollBar while dragging the thumb.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollingPreviewTemplateProperty =
            DependencyProperty.RegisterAttached("VerticalScrollingPreviewTemplate", typeof (DataTemplate),
                                                typeof (ScrollingPreviewService),
                                                new FrameworkPropertyMetadata(null,
                                                                              OnVerticalScrollingPreviewTemplateChanged));

        private static void OnVerticalScrollingPreviewTemplateChanged(DependencyObject obj,
                                                                      DependencyPropertyChangedEventArgs e)
        {
            if ((e.OldValue == null) && (e.NewValue != null))
            {
                PostAttachToEvents(obj, (DataTemplate) e.NewValue, true);
            }
            else
            {
                throw new NotSupportedException("Cannot change the template once it has been set.");
            }
        }

        public static void OnVerticalScrollingPreviewTemplateChanged(ScrollViewer obj,
                                                                     DataTemplate datatemplate)
        {
           
                obj.Dispatcher.BeginInvoke((NoParamCallback)(() => AttachToEvents(obj, datatemplate, true)),
                                              DispatcherPriority.Loaded);
           
        }


    

        public static DataTemplate GetHorizontalScrollingPreviewTemplate(DependencyObject obj)
        {
            return (DataTemplate) obj.GetValue(HorizontalScrollingPreviewTemplateProperty);
        }

        public static void SetHorizontalScrollingPreviewTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(HorizontalScrollingPreviewTemplateProperty, value);
        }

        /// <summary>
        ///     Allows for specifying a ContentTemplate for a ToolTip that will appear next to the 
        ///     horizontal ScrollBar while dragging the thumb.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollingPreviewTemplateProperty =
            DependencyProperty.RegisterAttached("HorizontalScrollingPreviewTemplate", typeof (DataTemplate),
                                                typeof (ScrollingPreviewService),
                                                new FrameworkPropertyMetadata(null,
                                                                              OnHorizontalScrollingPreviewTemplateChanged));

        private static void OnHorizontalScrollingPreviewTemplateChanged(DependencyObject obj,
                                                                        DependencyPropertyChangedEventArgs e)
        {
            if ((e.OldValue == null) && (e.NewValue != null))
            {
                PostAttachToEvents(obj, (DataTemplate) e.NewValue, false);
            }
         
        }

        #region Event Handling

        private static void PostAttachToEvents(DependencyObject obj, DataTemplate dataTemplate, bool vertical)
        {
            // Most likely, the control hasn't expanded its template, wait until
            // Loaded priority is reached before looking for elements.
            obj.Dispatcher.BeginInvoke((NoParamCallback) (() => AttachToEvents(obj, dataTemplate, vertical)),
                                       DispatcherPriority.Loaded);
        }

        private delegate void NoParamCallback();

        private const double Epsilon = 0;

        private static void AttachToEvents(DependencyObject obj, DataTemplate dataTemplate, bool vertical)
        {
            DependencyObject source = obj;
            var scrollViewer = FindElementOfType<ScrollViewer>(obj as FrameworkElement);
            if (scrollViewer != null)
            {
                string scrollBarPartName = vertical ? "PART_VerticalScrollBar" : "PART_HorizontalScrollBar";
                var scrollBar = FindName<ScrollBar>(scrollBarPartName, scrollViewer);
                if (scrollBar != null)
                {
                    var track = FindName<Track>("PART_Track", scrollBar);
                    if (track != null)
                    {
                        Thumb thumb = track.Thumb;
                        if (thumb != null)
                        {
                            // At this point, all of the control parts have been found.

                            // Attach to DragStarted to open the tooltip
                            thumb.DragStarted += delegate
                                                     {
                                                         var parentGrid = FindControls.FindParent<ExtendedGridControl.ExtendedDataGrid>(source);
                                                         if(parentGrid!=null)
                                                            parentGrid.IsVerticalScrolling = true;

                                                         if(dataTemplate==null)
                                                             return;
                                                         ScrollingPreviewData data;
                                                         if (_previewToolTip == null)
                                                         {
                                                             // Create the ToolTip if this is the first time it's been used.
                                                             _previewToolTip = new ToolTip();

                                                             data = new ScrollingPreviewData();
                                                             _previewToolTip.Content = data;
                                                         }
                                                         else
                                                         {
                                                             data = _previewToolTip.Content as ScrollingPreviewData;
                                                         }

                                                         // Update the content in the ToolTip
                                                         if (data != null)
                                                         {
                                                             data.UpdateScrollingValues(scrollBar);
                                                             if (source is ScrollViewer)
                                                             {
                                                                 parentGrid = FindControls.FindParent<ExtendedGridControl.ExtendedDataGrid>(source);
                                                                 if (parentGrid != null)
                                                                 {
                                                                     data.UpdateItem(parentGrid, vertical);
                                                                 }
                                                             }
                                                             else
                                                             {
                                                                 data.UpdateItem(source as ItemsControl, vertical);
                                                             }

                                                            
                                                         }

                                                         // Set the Placement and the PlacementTarget
                                                         _previewToolTip.PlacementTarget = thumb;
                                                         _previewToolTip.Placement = vertical
                                                                                         ? PlacementMode.Left
                                                                                         : PlacementMode.Top;

                                                         _previewToolTip.VerticalOffset = 0.0;
                                                         _previewToolTip.HorizontalOffset = 0.0;

                                                         _previewToolTip.ContentTemplate = dataTemplate;
                                                         _previewToolTip.IsOpen = true;
                                                     };

                            // Attach to DragDelta to update the ToolTip's position
                            thumb.DragDelta += delegate
                                                   {
                                                       if (dataTemplate == null)
                                                           return;
                                                       if ((_previewToolTip != null) &&
                                                           // Check that we're within the range of the ScrollBar
                                                           (scrollBar.Value > scrollBar.Minimum) &&
                                                           (scrollBar.Value < scrollBar.Maximum))
                                                       {
                                                           // This is a little trick to cause the ToolTip to update its position next to the Thumb
                                                           if (vertical)
                                                           {
                                                             
                                                               _previewToolTip.VerticalOffset =
                                                                   Math.Abs(_previewToolTip.VerticalOffset - 0.0) < Epsilon ? 0.001 : 0.0;
                                                           }
                                                           else
                                                           {
                                                               _previewToolTip.HorizontalOffset =
                                                                   Math.Abs(_previewToolTip.HorizontalOffset - 0.0) < Epsilon ? 0.001 : 0.0;
                                                           }
                                                       }
                                                   };

                            // Attach to DragCompleted to close the ToolTip
                            thumb.DragCompleted += delegate
                                                       {
                                                           var parentGrid = FindControls.FindParent<ExtendedGridControl.ExtendedDataGrid>(source);
                                                           if (parentGrid != null)
                                                               parentGrid.IsVerticalScrolling = false;
                                                           if (dataTemplate == null)
                                                               return;
                                                           if (_previewToolTip != null)
                                                           {
                                                               _previewToolTip.IsOpen = false;
                                                           }
                                                       };

                            // Attach to the Scroll event to update the ToolTip content
                            scrollBar.Scroll += delegate
                                                    {
                                                        if (dataTemplate == null)
                                                            return;
                                                        if (_previewToolTip != null)
                                                        {
                                                            // The ScrollBar's value isn't updated quite yet, so
                                                            // wait until Input priority
                                                            scrollBar.Dispatcher.BeginInvoke((NoParamCallback) delegate
                                                                                                                   {
                                                                                                                       var
                                                                                                                           data
                                                                                                                               =
                                                                                                                               (
                                                                                                                               ScrollingPreviewData
                                                                                                                               )
                                                                                                                               _previewToolTip
                                                                                                                                   .
                                                                                                                                   Content;
                                                                                                                       data
                                                                                                                           .
                                                                                                                           UpdateScrollingValues
                                                                                                                           (scrollBar);
                                                                                                                       data
                                                                                                                           .
                                                                                                                           UpdateItem
                                                                                                                           (source
                                                                                                                            as
                                                                                                                            ItemsControl,
                                                                                                                            vertical);
                                                                                                                   },
                                                                                             DispatcherPriority.Input);
                                                        }
                                                    };

                            return;
                        }
                    }
                }

                // At this point, something wasn't found. If the computed visibility is not visible,
                // then add a handler to wait for it to become visible.
                if ((vertical
                         ? scrollViewer.ComputedVerticalScrollBarVisibility
                         : scrollViewer.ComputedHorizontalScrollBarVisibility) != Visibility.Visible)
                {
                    DependencyPropertyDescriptor propertyDescriptor =
                        DependencyPropertyDescriptor.FromProperty(
                            vertical
                                ? ScrollViewer.ComputedVerticalScrollBarVisibilityProperty
                                : ScrollViewer.ComputedHorizontalScrollBarVisibilityProperty, typeof (ScrollViewer));
                    if (propertyDescriptor != null)
                    {
                        EventHandler handler = delegate
                                                   {
                                                       if (dataTemplate == null)
                                                           return;
                                                       if ((vertical
                                                                ? scrollViewer.ComputedVerticalScrollBarVisibility
                                                                : scrollViewer.ComputedHorizontalScrollBarVisibility) ==
                                                           Visibility.Visible)
                                                       {
                                                           EventHandler storedHandler =
                                                               GetWaitForVisibleScrollBar(source);
                                                           propertyDescriptor.RemoveValueChanged(scrollViewer,
                                                                                                 storedHandler);
                                                           PostAttachToEvents(obj, dataTemplate, vertical);
                                                       }
                                                   };
                        SetWaitForVisibleScrollBar(source, handler);
                        propertyDescriptor.AddValueChanged(scrollViewer, handler);
                    }
                }
            }
        }

        private static EventHandler GetWaitForVisibleScrollBar(DependencyObject obj)
        {
            return (EventHandler) obj.GetValue(WaitForVisibleScrollBarProperty);
        }

        private static void SetWaitForVisibleScrollBar(DependencyObject obj, EventHandler value)
        {
            obj.SetValue(WaitForVisibleScrollBarProperty, value);
        }

        /// <summary>
        ///     Storage for the property change handler if waiting for a ScrollBar to appear
        ///     for the first time.
        /// </summary>
        private static readonly DependencyProperty WaitForVisibleScrollBarProperty =
            DependencyProperty.RegisterAttached("WaitForVisibleScrollBar", typeof (EventHandler),
                                                typeof (ScrollingPreviewService), new UIPropertyMetadata(null));

        // Keep one instance of a ToolTip and re-use it
        [ThreadStatic] private static ToolTip _previewToolTip;

        #endregion

        #region Element Search Helpers

        /// <summary>
        ///     Returns the template element of the given name within the Control.
        /// </summary>
        private static T FindName<T>(string name, Control control) where T : FrameworkElement
        {
            ControlTemplate template = control.Template;
            if (template != null)
            {
                return template.FindName(name, control) as T;
            }

            return null;
        }

        /// <summary>
        ///     Searches the subtree of an element (including that element) 
        ///     for an element of a particluar type.
        /// </summary>
        private static T FindElementOfType<T>(FrameworkElement element) where T : FrameworkElement
        {
            var correctlyTyped = element as T;
            if (correctlyTyped != null)
            {
                return correctlyTyped;
            }

            if (element != null)
            {
                int numChildren = VisualTreeHelper.GetChildrenCount(element);
                for (int i = 0; i < numChildren; i++)
                {
                    var child = FindElementOfType<T>(VisualTreeHelper.GetChild(element, i) as FrameworkElement);
                    if (child != null)
                    {
                        return child;
                    }
                }

                // Popups continue in another window, jump to that tree
                var popup = element as Popup;
                if (popup != null)
                {
                    return FindElementOfType<T>(popup.Child as FrameworkElement);
                }
            }

            return null;
        }

        #endregion
    }
}
