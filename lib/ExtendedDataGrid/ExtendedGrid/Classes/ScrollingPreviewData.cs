using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ExtendedGrid.Classes
{
    /// <summary>
    ///     Provides data that should be useful to templates displaying
    ///     a preview.
    /// </summary>
    public class ScrollingPreviewData : INotifyPropertyChanged
    {
        /// <summary>
        ///     The ScrollBar's offset.
        /// </summary>
        public double Offset
        {
            get { return _offset; }
            internal set
            {
                
                _offset = value;
                OnPropertyChanged("Offset");
            }
        }

        /// <summary>
        ///     The size of the current viewport.
        /// </summary>
        public double Viewport
        {
            get { return _viewport; }
            internal set
            {
                _viewport = value;
                OnPropertyChanged("Viewport");
            }
        }

        /// <summary>
        ///     The entire scrollable range.
        /// </summary>
        public double Extent
        {
            get { return _extent; }
            internal set
            {
                _extent = value;
                OnPropertyChanged("Extent");
            }
        }

        /// <summary>
        ///     The first visible item in the viewport.
        /// </summary>
        public object FirstItem
        {
            get { return _firstItem; }
            private set
            {
                _firstItem = value;
                OnPropertyChanged("FirstItem");
            }
        }

        /// <summary>
        ///     The last visible item in the viewport.
        /// </summary>
        public object LastItem
        {
            get { return _lastItem; }
            private set
            {
                _lastItem = value;
                OnPropertyChanged("LastItem");
            }
        }

        /// <summary>
        ///     Updates Offset, Viewport, and Extent.
        /// </summary>
        internal void UpdateScrollingValues(ScrollBar scrollBar)
        {
            Offset = scrollBar.Value;
            Viewport = scrollBar.ViewportSize;
            Extent = scrollBar.Maximum - scrollBar.Minimum;
            var parentGrid = FindControls.FindParent<ExtendedGridControl.ExtendedDataGrid>(scrollBar);
            if (parentGrid != null)
            {
                UpdateItem(parentGrid, true);
            }
        }

        /// <summary>
        ///     Updates FirstItem and LastItem based on the
        ///     Offset and Viewport properties.
        /// </summary>
        /// <param name="itemsControl">The ItemsControl that contains the data items.</param>
        /// <param name="vertical">vertical </param>
        internal void UpdateItem(ItemsControl itemsControl, bool vertical)
        {
            if (itemsControl != null)
            {
                int numItems = itemsControl.Items.Count;
                if (numItems > 0)
                {
                    if (VirtualizingStackPanel.GetIsVirtualizing(itemsControl))
                    {
                        // Items scrolling (value == index)
                        var firstIndex = (int) _offset;
                        int lastIndex = (int) _offset + (int) _viewport - 1;

                        if ((firstIndex >= 0) && (firstIndex < numItems))
                        {
                            FirstItem = itemsControl.Items[firstIndex];
                        }
                        else
                        {
                            FirstItem = null;
                        }

                        if ((lastIndex >= 0) && (lastIndex < numItems))
                        {
                            LastItem = itemsControl.Items[lastIndex];
                        }
                        else
                        {
                            LastItem = null;
                        }
                    }
                    else
                    {
                        // Pixel scrolling (no virtualization)

                        // This will do a linear search through all of the items.
                        // It will assume that the first item encountered that is within view is
                        // the first visible item and the last item encountered that is
                        // within view is the last visible item.
                        // Improvements could be made to this algorithm depending on the
                        // number of items in the collection and the their order relative
                        // to each other on-screen.

                        ScrollContentPresenter scp = null;
                        bool foundFirstItem = false;
                        int bestLastItemIndex = -1;
                        object firstVisibleItem = null;
                        object lastVisibleItem = null;

                        for (int i = 0; i < numItems; i++)
                        {
                            var child = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as UIElement;
                            if (child != null)
                            {
                                if (scp == null)
                                {
                                    scp = FindParent<ScrollContentPresenter>(child);
                                    if (scp == null)
                                    {
                                        // Not in a ScrollViewer that we understand
                                        return;
                                    }
                                }

                                // Transform the origin of the child element to see if it is within view
                                GeneralTransform t = child.TransformToAncestor(scp);
                                Point p =
                                    t.Transform(foundFirstItem
                                                    ? new Point(child.RenderSize.Width, child.RenderSize.Height)
                                                    : new Point());

                                if (!foundFirstItem && ((vertical ? p.Y : p.X) >= 0.0))
                                {
                                    // Found the first visible item
                                    firstVisibleItem = itemsControl.Items[i];
                                    bestLastItemIndex = i;
                                    foundFirstItem = true;
                                }
                                else if (foundFirstItem && ((vertical ? p.Y : p.X) < scp.ActualHeight))
                                {
                                    // Found a candidate for the last visible item
                                    bestLastItemIndex = i;
                                }
                            }
                        }

                        if (bestLastItemIndex >= 0)
                        {
                            lastVisibleItem = itemsControl.Items[bestLastItemIndex];
                        }

                        // Update the item properties
                        FirstItem = firstVisibleItem;
                        LastItem = lastVisibleItem;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the parent of the specified type.
        /// </summary>
        private static T FindParent<T>(Visual v) where T : Visual
        {
            v = VisualTreeHelper.GetParent(v) as Visual;
            while (v != null)
            {
                var correctlyTyped = v as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                v = VisualTreeHelper.GetParent(v) as Visual;
            }

            return null;
        }

        private double _offset;
        private double _viewport;
        private double _extent;
        private object _firstItem;
        private object _lastItem;

        #region INotifyPropertyChanged Members

        /// <summary>
        ///     Notifies listeners of changes to properties on this object.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Raises the PropertyChanged event.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
