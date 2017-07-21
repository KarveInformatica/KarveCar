using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExtendedGrid.Classes
{
    public class CustomDataGridRowsPresenter : DataGridRowsPresenter
    {
        /// <summary>
        /// Content arrangement.
        /// </summary>
        /// <param name="arrangeSize">Arrange size</param>
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            if (Owner.FrozenRowCount == 0)
            {
                return base.ArrangeOverride(arrangeSize);
            }
            var rcChild = new Rect(arrangeSize);

            int frozenRowCount = 0;
            double nextFrozenRowStart = 0.0; //indicates the start position for next frozen row
            double nextNonFrozenRowStart = 0.0; //indicates the start position for next non-frozen row
            double dataGridVerticalScrollStartY = 0.0; //indicates the start position of the vertical scroll bar.

            //
            // determine the vertical offset, row panel offset and other coordinates used for arrange of children
            //
            if (Owner != null)
            {
                double physicalOffset;
                var originPoint = new Point(0, 0);
                IScrollInfo scrollInfo = this;
                {
                    double verticalOffset = scrollInfo.VerticalOffset;
                    physicalOffset = -1.0*ComputePhysicalFromLogicalOffset(verticalOffset, false);
                    rcChild.X = -1.0*scrollInfo.HorizontalOffset;
                }

                double sbOffset = VerticalScrollBar.TransformToAncestor(ParentPresenter).Transform(originPoint).Y;
                double rowsPanelOffset = TransformToAncestor(ParentPresenter).Transform(originPoint).Y; //indicates the offset of rows panel from the start of viewport 
                nextFrozenRowStart = 0.0;
                double viewportStartY = sbOffset - rowsPanelOffset;
                    //indicates the start of viewport with respect to coordinate system of row panel
                nextNonFrozenRowStart -= physicalOffset - viewportStartY;
                if (Owner.FrozenRowCount != null) frozenRowCount = (int) Owner.FrozenRowCount;

                //Debug.WriteLine(string.Format(
                //    "verticalOffset: {0}, physicalOffset: {1}, sbOffset: {2}, viewportStartY: {3}, nextNonFrozeRowStart: {4}",
                //    verticalOffset,
                //    physicalOffset,
                //    sbOffset,
                //    viewportStartY,
                //    nextNonFrozenRowStart));
            }

            //
            // Arrange and Position Children.
            // 
            var children = GetRealizedChildren;
            for (int i = 0; i < children.Count; ++i)
            {
                // we are looping through the actual containers; the visual children of this panel.
                var container = (UIElement) children[i];
                var childSize = container.DesiredSize;
                //TODO: need to handle virtualization
                
                //    container = ParentPresenter.ItemContainerGenerator.ContainerFromIndex(i) as UIElement;
                //    if (container != null)
                //    {
                //        childSize = container.DesiredSize;
                //    }
                //    else
                //    {
                //        //TODO: handle sizing for virtualization
                //    }
                //}

                rcChild.Height = childSize.Height;
                rcChild.Width = Math.Max(arrangeSize.Width, childSize.Width);

                if (i < frozenRowCount)
                {
                    rcChild.Y = nextFrozenRowStart;
                    nextFrozenRowStart += childSize.Height;
                    dataGridVerticalScrollStartY += childSize.Height;
                }
                else
                {
                    if (DoubleUtil.LessThan(nextNonFrozenRowStart, nextFrozenRowStart))
                    {
                        IScrollInfo scrollInfo = this;
                        var verticalOffset = scrollInfo.VerticalOffset;
                        if (DoubleUtil.LessThan(nextNonFrozenRowStart + childSize.Height, nextFrozenRowStart))
                        {
                            nextNonFrozenRowStart += childSize.Height;
                        }
                        else
                        {
                            double rowChoppedHeight = nextFrozenRowStart - nextNonFrozenRowStart;
                            if (DoubleUtil.AreClose(rowChoppedHeight, 0.0))
                            {
                                nextNonFrozenRowStart = nextFrozenRowStart + childSize.Height;
                            }
                            else
                            {
                                double clipHeight = childSize.Height - rowChoppedHeight;
                                nextNonFrozenRowStart = nextFrozenRowStart + clipHeight;
                            }
                        }

                        rcChild.Y = nextFrozenRowStart;
                    }
                    else
                    {
                        rcChild.Y = nextNonFrozenRowStart;
                        nextNonFrozenRowStart += childSize.Height;
                    }
                }

                container.Arrange(rcChild);
            }

            if (Owner != null)
            {
                Owner.NonFrozenRowsViewportVerticalOffset = dataGridVerticalScrollStartY;
            }

            return arrangeSize;
        }

        /// <summary>
        /// override of ViewportOffsetChanged method which forwards the call to datagrid on vertical scroll
        /// </summary>
        /// <param name="oldViewportOffset"></param>
        /// <param name="newViewportOffset"></param>
        protected override void OnViewportOffsetChanged(Vector oldViewportOffset, Vector newViewportOffset)
        {
            base.OnViewportOffsetChanged(oldViewportOffset, newViewportOffset);

            if (!DoubleUtil.AreClose(oldViewportOffset.Y, newViewportOffset.Y))
            {
                Base.CustomDg dataGrid = Owner;
                if (dataGrid != null)
                {
                    dataGrid.OnVerticalScroll();
                }
            }
        }

        #region Helpers

        private double ComputePhysicalFromLogicalOffset(double logicalOffset, bool fHorizontal)
        {
            double physicalOffset = 0.0;

            IList children = GetRealizedChildren;

            const double epsilon = 0;
            if(Math.Abs(logicalOffset - 0) < epsilon|| (logicalOffset > 0 && logicalOffset < children.Count))
            {
               // Debug.Assert(Math.Abs(logicalOffset - 0) < epsilon || (logicalOffset > 0 && logicalOffset < children.Count));
            }
           

            for (int i = 0; i < logicalOffset; i++)
            {
                var child = (UIElement) children[i];
                physicalOffset -= (fHorizontal)
                                      ? child.DesiredSize.Width
                                      : child.DesiredSize.Height;
            }

            return physicalOffset;
        }

        private ItemsControl ParentPresenter
        {
            get
            {
                var itemsPresenter = TemplatedParent as FrameworkElement;
                if (itemsPresenter != null)
                {
                    return itemsPresenter.TemplatedParent as ItemsControl;
                }

                return null;
            }
        }

        private IList GetRealizedChildren
        {
            get
            {
                return (IList) typeof (VirtualizingStackPanel).InvokeMember("RealizedChildren",
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.Instance |
                                                                            BindingFlags.GetProperty,
                                                                            null, this, null);
            }
        }

        private ScrollBar VerticalScrollBar
        {
            get
            {
                if (_verticalScrollBar == null)
                {
                    _verticalScrollBar = (ScrollBar) Helper.FindPartByName(ParentPresenter, "PART_VerticalScrollBar");
                    _verticalScrollBar.UpdateLayout();
                }
                return _verticalScrollBar;
            }
        }

        private Base.CustomDg Owner
        {
            get { return _owner ?? (_owner = ItemsControl.GetItemsOwner(this) as Base.CustomDg); }
        }

        #endregion Helpers

        #region Data

        private Base.CustomDg _owner;
        private ScrollBar _verticalScrollBar;

        #endregion Data
    }
}
