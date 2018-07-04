using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.ComponentModel;

namespace KarveControls
{

    [TemplatePart(Name = "PART_MaskedTextBox", Type = typeof(KarveControls.MaskedTextBox))]
    [TemplatePart(Name = "PART_TimeSelected", Type = typeof(ListBox))]
    [TemplatePart(Name = "PART_PopUp", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_SpinUp", Type = typeof(Button))]
    [TemplatePart(Name = "PART_SpinDown", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DropDown", Type = typeof(Button))]

    public class DataTimePicker: Control, INotifyPropertyChanged

    {

        
        public event PropertyChangedEventHandler PropertyChanged =  delegate { };

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public double SpinHeight
        {
            get { return (double)GetValue(SpinHeightProperty); }
            set { SetValue(SpinHeightProperty, value); }
        }

        public static readonly DependencyProperty SpinHeightProperty =
            DependencyProperty.Register(
                "SpinHeight",
                typeof(double),
                typeof(DataTimePicker));



        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(double),
                typeof(DataTimePicker), new FrameworkPropertyMetadata());


        public static readonly DependencyProperty DropDownHeightProperty =
            DependencyProperty.Register(
                "DropDownHeight",
                typeof(double),
                typeof(DataTimePicker));

        public double DropDownHeight
        {
            get { return (double)GetValue(DropDownHeightProperty); }
            set { SetValue(DropDownHeightProperty, value); }
        }
        
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(TimeSpan),
                typeof(DataTimePicker), new PropertyMetadata(new TimeSpan(8,0,0), OnChangedTime));

        private static void OnChangedTime(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            if (e.NewValue is TimeSpan span)
            {
                if (d is DataTimePicker picker)
                {
                    picker.SetTextValue(span);
                }
            }
        }

        private void SetTextValue(TimeSpan span)
        {
            if (span == null)
            {
                return;
            }
            if ((span.Hours > -1) && (span.Hours < 24) && (span.Minutes > -1) && (span.Minutes< 60))
            {
                var textValue = ConvertText(span.Hours) + ":" + ConvertText(span.Minutes);
                TextTime = textValue;

                var brush = new SolidColorBrush(Colors.White);
                _PART_MaskedTextBox = GetTemplateChild("PART_MaskedTextBox") as MaskedTextBox;
                if (_PART_MaskedTextBox != null)
                {
                    _PART_MaskedTextBox.Background = brush;
                }

            }
            else
            {
                var brush = new SolidColorBrush(Colors.Yellow);
                _PART_MaskedTextBox = GetTemplateChild("PART_MaskedTextBox") as MaskedTextBox;
                if (_PART_MaskedTextBox != null)
                {
                    _PART_MaskedTextBox.Background = brush;
                }
            }
     
        }

        public bool NullBox
        {
            get
            {
                return _nullBox;
            }
            set
            {
                _nullBox = value;
                OnPropertyChanged("NullBox");
            }
        }
        public TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        
        public string TextTime {
            set
            {
                _textTime = value;
                OnPropertyChanged("TextTime");
            }
            get
            {
                return _textTime;
            }
        }

        private TimeSpan _currentTime;
        private readonly List<TimeSpan> _dailyTime = new List<TimeSpan>()
        {
            new TimeSpan(7, 0, 0),
            new TimeSpan(8, 0, 0),
            new TimeSpan(8, 30, 0),
            new TimeSpan(9, 0, 0),
            new TimeSpan(10, 0, 0),
            new TimeSpan(11, 0, 0),
            new TimeSpan(12, 0, 0),
            new TimeSpan(13, 0, 0),
            new TimeSpan(14, 0, 0),
            new TimeSpan(15, 0, 0),
            new TimeSpan(16, 0, 0),
            new TimeSpan(17, 0, 0),
            new TimeSpan(18, 0, 0),
            new TimeSpan(19, 0, 0),
            new TimeSpan(20, 0, 0),
            new TimeSpan(21, 0, 0),
            new TimeSpan(22, 0, 0),
            new TimeSpan(23, 0, 0),
            new TimeSpan(0, 0, 0),
            new TimeSpan(1, 0, 0),
            new TimeSpan(2, 0, 0),
            new TimeSpan(3, 0, 0),
            new TimeSpan(4, 0, 0),
            new TimeSpan(5, 0, 0),
            new TimeSpan(6, 0, 0)
        };
        private TimeSpan _currentSelection;
        private bool isEscaped;
        private MaskedTextBox _PART_MaskedTextBox;
        private ListBox _PART_TimeSelected;
        private Popup _PART_PopUp;
        private Button _PART_SpinUp;
        private Button _PART_SpinDown;
        private string _textTime = "00:00";
        private Button _PART_DropDown;
        private bool _nullBox;

        public DataTimePicker(): base()
        {
        }
        static DataTimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTimePicker), new FrameworkPropertyMetadata(typeof(DataTimePicker)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var brush = new SolidColorBrush(Colors.White);
            _PART_SpinUp = GetTemplateChild("PART_SpinUp") as Button;
            if (_PART_SpinUp != null)
            {
                _PART_SpinUp.Click += _PART_SpinUp_Click;
            }

            _PART_SpinDown = GetTemplateChild("PART_SpinDown") as Button;
            if (_PART_SpinDown != null)
            {

                _PART_SpinDown.Click += _PART_SpinDown_Click;
            }

            _PART_DropDown = GetTemplateChild("PART_DropDown") as Button;
            if (_PART_DropDown != null)
            {
                _PART_DropDown.Click += Button_DropDown;

            }
            _PART_MaskedTextBox = GetTemplateChild("PART_MaskedTextBox") as MaskedTextBox;
            if (_PART_MaskedTextBox != null)
            {
                _PART_MaskedTextBox.TextChanged += MaskedTextBox_TextChanged;
                _PART_MaskedTextBox.Background = brush;
            }
            _PART_TimeSelected = GetTemplateChild("PART_TimeSelected") as ListBox;
            if (_PART_TimeSelected != null)
            {
                _PART_TimeSelected.ItemsSource = _dailyTime;
                _PART_TimeSelected.SelectionChanged += PART_TimeSelected_SelectionChanged;
            }
            _PART_PopUp = GetTemplateChild("PART_PopUp") as Popup;
            if (_PART_PopUp != null)
            {
                _PART_PopUp.PreviewKeyDown += PART_PopUp_PreviewKeyDown;
                _PART_PopUp.PlacementTarget = _PART_MaskedTextBox;
            }
        }

        private void _PART_SpinDown_Click(object sender, RoutedEventArgs e)
        {
            var text = _PART_MaskedTextBox.Text;

            var numbers = text.Split(':');

            var min = 0;
            var hour = 8;

            Parse(numbers, out hour, out min);
            min--;
            if ((min < 0) || (min > 59))
            {
                min = 0;
            }

            if ((hour < 0) || (hour > 24))
            {
                hour = 0;
            }
            var newText = ConvertText(hour) + ':' + ConvertText(min);
            _PART_MaskedTextBox.Text = newText;
            _currentSelection = new TimeSpan(hour, min, 0);
            if (Command != null)
            {
               
                Command.Execute(_currentSelection);
            }
        }

        private void _PART_SpinUp_Click(object sender, RoutedEventArgs e)
        {
            var text = _PART_MaskedTextBox.Text;
            var numbers = text.Split(':');
            var min = 0;
            var hour = 8;

            Parse(numbers, out hour, out min);
            min++;
            if ((min < 0) || (min > 59))
            {
                min = 0;
            }

            if ((hour < 0) || (hour > 24))
            {
                hour = 0;
            }
            _currentSelection = new TimeSpan(hour, min, 0);
            if (Command != null)
            {

                Command.Execute(_currentSelection);
            }

            var newText = ConvertText(hour) + ':' + ConvertText(min);
            _PART_MaskedTextBox.Text = newText;
        }

        private void PART_TimeSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox box)
            {
                _currentSelection = (TimeSpan)box.SelectedItem;
            }
            if (_PART_PopUp.IsOpen)
            {
                _PART_PopUp.IsOpen = false;
                if (!isEscaped)
                {
                    _currentSelection = (TimeSpan)_PART_TimeSelected.SelectedItem;
                    _PART_MaskedTextBox.Text = ConvertText(_currentSelection.Hours) + ":" + ConvertText(_currentSelection.Minutes);
                    if (Command != null)
                    {
                        Command.Execute(_currentSelection);
                    }
                }
            }
        }

        private void PART_PopUp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                isEscaped = true;
                _PART_PopUp.IsOpen = false;
            }
            if (e.Key == Key.Enter)
            {
                if (_PART_TimeSelected.SelectedItem is TimeSpan span)
                {
                    _currentTime = span;
                    _PART_MaskedTextBox.Text = ConvertText(span.Hours) + ":" + ConvertText(span.Minutes);
                }
                _PART_PopUp.IsOpen = false;
            }
        }

        private string ConvertText(int minutes)
        {
            var outString = string.Empty;
            if (minutes < 10)
            {
                outString = "0" + minutes.ToString();
            }
            else
            {
                outString = minutes.ToString();
            }
            return outString;
        }

      

        private void Parse(string[] numbers, out int hour, out int min)
        {
            hour = 8;
            min = 0;
            if (!int.TryParse(numbers[1], out min))
            {
                min = 0;
            }
            if (!int.TryParse(numbers[0], out hour))
            {
                hour = 8;
            }
        }
        private void Button_DropDown(object sender, RoutedEventArgs e)
        {
            _PART_PopUp.IsOpen = true;

        }

        private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is MaskedTextBox box)
            {
                var currentText = box.Text;
                TimeSpan span = new TimeSpan();
                //this.T(currentTex);
                if (TimeSpan.TryParse(currentText, out span))
                {

                    _currentSelection = span;
                    var brush = new SolidColorBrush(Colors.White);
                    box.Background = brush;
                }
                else
                {
                    var brush = new SolidColorBrush(Colors.Yellow);
                    box.Background = brush;
                }

            }
        }
    }

}