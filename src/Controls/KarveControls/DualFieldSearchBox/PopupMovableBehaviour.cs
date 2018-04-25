using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace KarveControls
{

    public class PopupMovableBehaviour
    {

        private const int MaxSize = 1000;
        private  const int MinSize = 50;
        #region IsMoveEnabled DP
        public static Boolean GetIsMoveEnabledProperty(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(IsMoveEnabledPropertyProperty);
        }

        public static void SetIsMoveEnabledProperty(DependencyObject obj,
            Boolean value)
        {
            obj.SetValue(IsMoveEnabledPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for 
        //IsMoveEnabledProperty. 
        public static readonly DependencyProperty IsMoveEnabledPropertyProperty =
            DependencyProperty.RegisterAttached("IsMoveEnabledProperty",
                typeof(Boolean), typeof(PopupMovableBehaviour),
                new UIPropertyMetadata(false, OnIsMoveStatedChanged));

        
        private static void OnIsMoveStatedChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Thumb thumb = (Thumb)sender;

            if (thumb == null) return;

            thumb.DragStarted -= Thumb_DragStarted;
            thumb.DragDelta -= Thumb_DragDelta;
            thumb.DragCompleted -= Thumb_DragCompleted;

            if (e.NewValue != null && e.NewValue.GetType() == typeof(Boolean))
            {
                thumb.DragStarted += Thumb_DragStarted;
                thumb.DragDelta += Thumb_DragDelta;
                thumb.DragCompleted += Thumb_DragCompleted;
            }

        }
        #endregion

        #region Private Methods
        private static void Thumb_DragCompleted(object sender,
            DragCompletedEventArgs e)
        {
            Thumb thumb = (Thumb)sender;
            thumb.Cursor = null;
        }

        private static void Thumb_DragDelta(object sender,
            DragDeltaEventArgs e)
        {
            Thumb thumb = (Thumb)sender;
            Popup popup = thumb?.Tag as Popup;

            
            if (popup == null)
            {
                return;
            }

            popup.HorizontalOffset += e.HorizontalChange;
            popup.VerticalOffset += e.VerticalChange;

            if (thumb.Cursor == Cursors.SizeWE || thumb.Cursor == Cursors.SizeNWSE)
            {
                    popup.Width = Math.Min(MaxSize,
                        Math.Max(popup.Width + e.HorizontalChange,
                            MinSize));
            }

            if (thumb.Cursor == Cursors.SizeNS
                || thumb.Cursor == Cursors.SizeNWSE)
            {
                popup.Height = Math.Min(MaxSize,
                    Math.Max(popup.Height + e.VerticalChange,
                        MinSize));
            }
       
        }

        private static void Thumb_DragStarted(object sender,
            DragStartedEventArgs e)
        {
            var thumb = (Thumb)sender;
            thumb.Cursor = Cursors.Hand;
        }
        #endregion

    }

}
