using System;

namespace KarveControls.Calendar
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Determines whether a subject date is the same as a date passed in.
		/// </summary>
		/// <param name="subjectDate"> The subject date.</param>
		/// <param name="dateToCompare">The date passed in.</param>
		/// <returns>True if the two DateTime objects represent the same date, even if their time components differ; false otherwise.</returns>
		public static bool IsSameDateAs(this DateTime subjectDate, DateTime dateToCompare)
		{
			var dayIsSame = subjectDate.Day == dateToCompare.Day;
			var monthIsSame = subjectDate.Month == dateToCompare.Month;
			var yearIsSame = subjectDate.Year == dateToCompare.Year;
			return dayIsSame && monthIsSame && yearIsSame;
		}

		/// <summary>
		/// Determines whether a subject date is in the same month as a date passed in.
		/// </summary>
		/// <param name="subjectDate"> The subject date.</param>
		/// <param name="dateToCompare">The date passed in.</param>
		/// <returns>True if the two DateTime objects are in the same month; false otherwise.</returns>
		public static bool IsSameMonthAs(this DateTime subjectDate, DateTime dateToCompare)
		{
			var monthIsSame = subjectDate.Month == dateToCompare.Month;
			var yearIsSame = subjectDate.Year == dateToCompare.Year;
			return monthIsSame && yearIsSame;
		}
	}
}