using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterModule.Views
{
    /// <summary>
    /// SummaryEx. Extension for the cumulative summary.
    /// </summary>
    class SummaryEx: DependencyObject
    {
        /// <summary>
        ///  Dependency property that give a list of bool corrensponding to an array of radioboxes
        /// </summary>
        public static readonly DependencyProperty CheckedArrayValuesProperty = 
            DependencyProperty.RegisterAttached("CheckedArray", typeof(List<bool>), typeof(SummaryEx), new PropertyMetadata(new List<bool>()));
        /// <summary>
        ///  Dependency property that gives us a data array.
        /// </summary>
        public static readonly DependencyProperty DateArrayValuesProperty =
            DependencyProperty.RegisterAttached("DateArray", typeof(List<DateTime>), typeof(SummaryEx), new PropertyMetadata(new List<DateTime>()));
        /// <summary>
        /// This gives us a property to be attaced a couple of dates.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetCheckedArray(DependencyObject d)
        {
            return (string)d.GetValue(CheckedArrayValuesProperty);
        }
        /// <summary>
        /// This allows us to set a date array.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetCheckedArray(DependencyObject d, string value)
        {
            d.SetValue(CheckedArrayValuesProperty, value);
        }
        /// This gives us a property to be attaced a couple of dates.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetDateArray(DependencyObject d)
        {
            return (string)d.GetValue(DateArrayValuesProperty);
        }
        /// <summary>
        /// This allows us to set a date array.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetDateArray(DependencyObject d, string value)
        {
            d.SetValue(DateArrayValuesProperty, value);
        }
    }
}
