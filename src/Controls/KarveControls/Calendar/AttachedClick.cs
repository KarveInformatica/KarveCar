using System;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using KarveControls.Generic;

namespace KarveControls
{
    public class SelectedDayEventArgs: KarveRoutedEventsArgs
    {
        public int Day { set; get; }
        public int Month { set; get; }
        public bool IsSelected { get; set; }
    }
    public static class SelectedDay
    {



        public static readonly RoutedEvent DaySelectEvent =
       EventManager.RegisterRoutedEvent(
           "DaySelect",
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(SelectedDay));

        public static void AddDaySelectHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(SelectedDay.DaySelectEvent, handler);
            }
        }
        public static void RemoveDaySelectHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(SelectedDay.DaySelectEvent, handler);
            }
        }
        
        public static readonly DependencyProperty IsDaySelectedProperty =
    DependencyProperty.RegisterAttached(
    "IsDaySelected", typeof(Boolean),
    typeof(SelectedDay), new FrameworkPropertyMetadata(false));

        public static void SetIsDaySelected(UIElement element, Boolean value)
        {
            if (element == null)
            {
                return;
            }
            element.SetValue(IsDaySelectedProperty, value);
        }
        public static Boolean GetIsDaySelected(UIElement element)
        {
            if (element == null)
            {
                return false;
            }
            var value = (Boolean) element.GetValue(IsDaySelectedProperty);
            return (Boolean)value;
        }


        public static readonly DependencyProperty DayIndexProperty =
DependencyProperty.RegisterAttached(
"DayIndex", typeof(int),
typeof(SelectedDay), new FrameworkPropertyMetadata(1));

        public static void SetDayIndex(UIElement element, int value)
        {
            if (element != null)
            {
                element.SetValue(DayIndexProperty, value);

            }
        }
        public static int GetDayIndex(UIElement element)
        {
            if (element == null)
            {
                return -1;
            }
            return (int)element.GetValue(DayIndexProperty);
        }

    }
}