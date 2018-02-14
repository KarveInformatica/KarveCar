using System;
using System.Windows.Data;

namespace KarveControls.Calendar
{
	public class HighlightDateConverter : IMultiValueConverter
	{

		#region IMultiValueConverter Members

		/// <summary>
		/// Gets a tool tip for a date passed in
		/// </summary>
		/// <param name="values">The array of values that the source bindings in the System.Windows.Data.MultiBinding produces.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A string representing the tool tip for the date passed in.</returns>
		/// <remarks>
		/// The 'values' array parameter has the following elements:
		/// 
		/// • values[0] = Binding #1: The date to be looked up. This should be set up as a pathless binding; 
		///   the Calendar control will provide the date.
		/// 
		/// • values[1] = Binding #2: A binding reference to the KarveCalendar control that is invoking this converter.
		/// </remarks>
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Exit if values not set
			if ((values[0] == null) || (values[1] == null)) return null;

			// Get values passed in
			var targetDate = (DateTime)values[0];
			var parent = (KarveCalendar) values[1];
			
			// Exit if highlighting turned off
			if (parent.ShowDateHighlighting == false) return null;

			// Exit if no HighlightedDateText array
			if (parent.HighlightedDateText == null) return null;

			/* The WPF calendar always displays six rows of dates, and it fills out those rows 
			 * with dates from the preceding and following month. These 'gray' date numbers (29,
			 * 30, 31, and so on, and 1, 2, 3, and so on) duplicate date numbers in the current 
			 * month, so we ignore them. The tool tips for these gray dates will appear in their 
			 * own display months. */

			// Exit if target date not in the current display month
			if (!targetDate.IsSameMonthAs(parent.DisplayDate)) return null;

			// Get highlight text for date passed in
			string highlightText = null;
			var day = targetDate.Day;

			/* The HighlightedDateText array is indexed from zero, while the calendar is indexed from
			 * one. So, we have to adjust the index between the array and the calendar. */

			// Get array index
			var n = day - 1;

			var dateIsHighlighted = !String.IsNullOrEmpty(parent.HighlightedDateText[n]);
			if (dateIsHighlighted) highlightText = parent.HighlightedDateText[n];

			// Set return value
			return highlightText;
		}

		/// <summary>
		/// Not used.
		/// </summary>
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return new object[0];
		}

		#endregion
	}
}