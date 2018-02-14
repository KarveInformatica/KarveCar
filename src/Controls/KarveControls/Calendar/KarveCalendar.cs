using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.Windows.Forms.Tools.Navigation;

namespace KarveControls.Calendar
{
     /// <summary>
     /// Custom calendar control that supports date highlighting.
     /// </summary>
	public class KarveCalendar : System.Windows.Controls.Calendar
     {
          #region Dependency Properties

          // The background brush used for the date highlight.
          public static DependencyProperty DateHighlightBrushProperty = DependencyProperty.Register
               (
                    "DateHighlightBrush",
                    typeof (Brush),
                    typeof (KarveCalendar),
                    new PropertyMetadata(new SolidColorBrush(Colors.Red))
               );

		// The list of dates to be highlighted.
		public static DependencyProperty HighlightedDateTextProperty = DependencyProperty.Register
			(
				"HighlightedDateText",
				typeof (String[]),
				typeof (KarveCalendar),
				new PropertyMetadata()
			);

        // Month of the calendar.
        public static DependencyProperty CurrentMonthTextProperty = DependencyProperty.Register
            (
                "Month",
                typeof(String),
                typeof(KarveCalendar),
                new PropertyMetadata()
            );


        // The observable collection with dates to be highlighted
        public static DependencyProperty ImportantDatesProperty = DependencyProperty.Register
         (
             "ImportantDates",
             typeof(List<DateTime>),
             typeof(KarveCalendar),
             new PropertyMetadata(new List<DateTime>(), OnDisplayDateConvert)
         );

         private static void OnDisplayDateConvert(DependencyObject d, DependencyPropertyChangedEventArgs e)
         {
             List<DateTime> value = d.GetValue(ImportantDatesProperty) as List<DateTime>;
             if (value != null)
             {
                 int cnt = value.Count;
                String[] valueStrings = new string[cnt];
                 int pos = 0;
                 foreach (var s in value)
                 {
                     valueStrings[pos++] = Convert.ToString(s, CultureInfo.InvariantCulture);
                 }
                 d.SetValue(HighlightedDateTextProperty, valueStrings);
             }
         }

         // Whether highlights should be shown.
        public static DependencyProperty ShowDateHighlightingProperty = DependencyProperty.Register
               (
                    "ShowDateHighlighting",
                    typeof (bool),
                    typeof (KarveCalendar),
                    new PropertyMetadata(true)
               );

          // Whether tool tips should be shown with highlights.
          public static DependencyProperty ShowHighlightedDateTextProperty = DependencyProperty.Register
               (
                    "ShowHighlightedDateText",
                    typeof (bool),
                    typeof (KarveCalendar),
                    new PropertyMetadata(true)
               );

          #endregion

          #region Constructors

          /// <summary>
          /// Static constructor.
          /// </summary>
          static KarveCalendar()
          {
               DefaultStyleKeyProperty.OverrideMetadata(typeof (KarveCalendar),
                    new FrameworkPropertyMetadata(typeof (KarveCalendar)));
          }

		/// <summary>
		/// Instance constructor.
		/// </summary>
     	public KarveCalendar()
     	{
			/* We initialize the HighlightedDateText property to an array of 31 strings,
			 * since 31 is the maximum number of days in any month. */

			// Initialize HighlightedDateText property
     		this.HighlightedDateText = new string[31];
     	}

          #endregion

          #region CLR Properties

          /// <summary>
          /// The background brush used for the date highlight.
          /// </summary>
		[Browsable(true)]
		[Category("Highlighting")]
		public Brush DateHighlightBrush
		{
			get { return (Brush) GetValue(DateHighlightBrushProperty); }
			set { SetValue(DateHighlightBrushProperty, value); }
		}

        /// <summary>
        /// The background brush used for the date highlight.
        /// </summary>
        [Browsable(true)]
        [Category("Highlighting")]
        public string Month
        {
            get { return (string)GetValue(CurrentMonthTextProperty); }
            set { SetValue(CurrentMonthTextProperty, value); }
        }

        [Browsable(false)]
         public List<DateTime> ImportantDates
         {
             get { return (List<DateTime>)GetValue(ImportantDatesProperty); }
             set { SetValue(ImportantDatesProperty, value); }
         }

        /// <summary>
        /// The tool tips for highlighted dates.
        /// </summary>
        [Browsable(true)]
          [Category("Highlighting")]
		public String[] HighlightedDateText
          {
			get { return (String[])GetValue(HighlightedDateTextProperty); }
			set { SetValue(HighlightedDateTextProperty, value); }
          }

          /// <summary>
          /// Whether highlights should be shown.
          /// </summary>
          [Browsable(true)]
          [Category("Highlighting")]
          public bool ShowDateHighlighting
          {
               get { return (bool) GetValue(ShowDateHighlightingProperty); }
               set { SetValue(ShowDateHighlightingProperty, value); }
          }

          /// <summary>
          /// Whether tool tips should be shown with highlights.
          /// </summary>
          [Browsable(true)]
          [Category("Highlighting")]
          public bool ShowHighlightedDateText
          {
               get { return (bool) GetValue(ShowHighlightedDateTextProperty); }
               set { SetValue(ShowHighlightedDateTextProperty, value); }
          }

          #endregion

     	#region Public Methods

		/// <summary>
		/// Refreshes the calendar highlighting
		/// </summary>
		public void Refresh()
		{
			var realDisplayDate = this.DisplayDate;
			this.DisplayDate = DateTime.MinValue;
			this.DisplayDate = realDisplayDate;
           
		}

     	#endregion
     }
}