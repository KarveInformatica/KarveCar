using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPFDemo
{
    public class CarouselControl : Canvas
    {
        public CarouselControl()
        {
            _timer.Tick += TimerTick;
            _timer.Interval = TimeSpan.FromMilliseconds(10);
        }

        public DateTime _previousTime;
        public DateTime _currentTime;

        public void ReInitialize()
        {
            Init();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Init();
        }

        public delegate void OnElementSelectedHandler(object sender);

        public event OnElementSelectedHandler OnElementSelected;

        public void SelectElement(FrameworkElement element)
        {
            if (element != null)
            {
                _previousTime = DateTime.Now;

                RotateToElement(element);

                if (OnElementSelected != null)
                    OnElementSelected(element);
            }
        }

        private const double DEFAULT_ROTATION_SPEED = 200;
        private const double MINIMUM_ROTATION_SPEED = 1;
        private const double MAXIMUM_ROTATION_SPEED = 1000;
        private double _rotationSpeed = DEFAULT_ROTATION_SPEED;

        public double RotationSpeed
        {
            get { return _rotationSpeed; }
            set { _rotationSpeed = Math.Min(Math.Max(value, MINIMUM_ROTATION_SPEED), MAXIMUM_ROTATION_SPEED); }
        }

        private const double DEFAULT_LOOKDOWN_OFFSET = 0;
        private const double MINIMUM_LOOKDOWN_OFFSET = -100;
        private const double MAXIMUM_LOOKDOWN_OFFSET = 100;
        private double _lookdownOffset = DEFAULT_LOOKDOWN_OFFSET;

        public double LookDownOffset
        {
            get { return _lookdownOffset; }
            set { _lookdownOffset = Math.Min(Math.Max(value, MINIMUM_LOOKDOWN_OFFSET), MAXIMUM_LOOKDOWN_OFFSET); }
        }

        private const double DEFAULT_FADE = 0.5;
        private const double MINIMUM_FADE = 0;
        private const double MAXIMUM_FADE = 1;
        private double _fade = DEFAULT_FADE;

        public double Fade
        {
            get { return _fade; }
            set { _fade = Math.Min(Math.Max(value, MINIMUM_FADE), MAXIMUM_FADE); }
        }

        private const double DEFAULT_SCALE = 0.5;
        private const double MINIMUM_SCALE = 0;
        private const double MAXIMUM_SCALE = 1;
        private double _scale = DEFAULT_SCALE;

        public double Scale
        {
            get { return _scale; }
            set { _scale = Math.Min(Math.Max(value, MINIMUM_SCALE), MAXIMUM_SCALE); }
        }

        private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectElement(sender as FrameworkElement);
        }

        private void RotateToElement(FrameworkElement element)
        {
            if (element != _currentlySelected)
            {
                _currentlySelected = element;
                int targetIndex = Children.IndexOf(element);

                double degreesToRotate = GetDegreesNeededToPlaceElementInFront(_currentRotation, targetIndex,
                                                                               TotalNumberOfElements);
                _targetRotation = ClampDegrees(_currentRotation - degreesToRotate);

                StartRotation(degreesToRotate);
            }
        }

        internal static double GetDegreesNeededToPlaceElementInFront(double currentRotation, int targetIndex,
                                                                     int totalNumberOfElements)
        {
            double rawDegrees = -(180.0 - (currentRotation + 360.0*(targetIndex/(double) totalNumberOfElements)));

            if (rawDegrees > 180)
                return -(360 - rawDegrees);

            return rawDegrees;
        }

        private double RotationAmount
        {
            get { return (_currentTime - _previousTime).TotalSeconds*_rotationSpeed; }
        }


        private const double INTERNAL_SCALE_COEFFICIENT = 0.6;

        private void Init()
        {
            _previousTime = _currentTime = DateTime.Now;

            X_SCALE = CenterX*INTERNAL_SCALE_COEFFICIENT;
            Y_SCALE = CenterY*INTERNAL_SCALE_COEFFICIENT;

            foreach (FrameworkElement element in Children)
            {
                element.MouseLeftButtonDown += element_MouseLeftButtonDown;
                element.Cursor = Cursors.Hand;
            }

            SelectElement(GetChild(0));

            SetElementPositions();
        }


        private FrameworkElement _currentlySelected;

        public FrameworkElement CurrentlySelected
        {
            get { return _currentlySelected; }
        }

        protected double CenterX
        {
            get { return Width/2.0; }
        }

        protected double CenterY
        {
            get { return Height/2.0; }
        }

        protected double X_SCALE;
        protected double Y_SCALE;

        protected DispatcherTimer _timer = new DispatcherTimer();
        private double _rotationToGo;

        private int TotalNumberOfElements
        {
            get { return Children.Count; }
        }

        protected double _currentRotation;

        protected double _targetRotation;


        protected virtual void TimerTick(object sender, EventArgs e)
        {
            _currentTime = DateTime.Now;

            if ((_rotationToGo < RotationAmount) && (_rotationToGo > -RotationAmount))
            {
                _rotationToGo = 0;

                if (_currentRotation != _targetRotation)
                {
                    _currentRotation = _targetRotation;
                }
                else
                {
                    _timer.Stop();
                    return;
                }
            }
            else if (_rotationToGo < 0)
            {
                _rotationToGo += RotationAmount;
                _currentRotation = ClampDegrees(_currentRotation + RotationAmount);
            }
            else
            {
                _rotationToGo -= RotationAmount;
                _currentRotation = ClampDegrees(_currentRotation - RotationAmount);
            }

            SetElementPositions();

            _previousTime = _currentTime;
        }

        protected double ClampDegrees(double rawDegrees)
        {
            if (rawDegrees > 360)
                return rawDegrees - 360;

            if (rawDegrees < 0)
                return rawDegrees + 360;

            return rawDegrees;
        }

        public void SetElementPositions()
        {
            for (int index = 0; index < TotalNumberOfElements; index++)
            {
                FrameworkElement element = GetChild(index);

                double elementWidthCenter = GetElementCenter(element.Width, element.ActualWidth);
                double elementHeightCenter = GetElementCenter(element.Height, element.ActualHeight);

                double degrees = 360*(index/(double) TotalNumberOfElements) + _currentRotation;

                double x = -X_SCALE*Math.Sin(ConvertToRads(degrees)) -
                           (double.IsNaN(Y_SCALE) ? 0.0 : Y_SCALE/100.0)*
                           (Math.Cos(ConvertToRads(degrees))*LookDownOffset);
                SetLeft(element, x + CenterX - elementWidthCenter);

                double y = Y_SCALE*Math.Sin(ConvertToRads(degrees)) -
                           (double.IsNaN(X_SCALE) ? 0.0 : X_SCALE/100.0)*
                           (Math.Cos(ConvertToRads(degrees))*LookDownOffset);
                SetTop(element, y + CenterY - elementHeightCenter);

                var scale = element.RenderTransform as ScaleTransform;
                if (scale == null)
                {
                    scale = new ScaleTransform();
                    element.RenderTransform = scale;
                }

                scale.CenterX = elementWidthCenter;
                scale.CenterY = elementHeightCenter;
                scale.ScaleX = scale.ScaleY = GetScaledSize(degrees);
                SetZIndex(element, GetZValue(degrees));

                SetOpacity(element, degrees);
            }
        }

        private FrameworkElement GetChild(int index)
        {
            if (Children.Count == 0)
                return null;

            var element = Children[index] as FrameworkElement;

            if (element == null)
                throw new NotSupportedException("Carousel only supports children that are Framework elements");

            return element;
        }

        internal static double GetElementCenter(double elementDimension, double elementActualDimension)
        {
            return double.IsNaN(elementDimension) ? elementActualDimension/2.0 : elementDimension/2.0;
        }


        private void SetOpacity(FrameworkElement element, double degrees)
        {
            element.Opacity = (1.0 - Fade) + Fade*GetCoefficient(degrees);
        }

        private int GetZValue(double degrees)
        {
            return (int) (360*GetCoefficient(degrees));
        }

        private double GetScaledSize(double degrees)
        {
            return (1.0 - Scale) + Scale*GetCoefficient(degrees);
        }

        private double GetCoefficient(double degrees)
        {
            return 1.0 - Math.Cos(ConvertToRads(degrees))/2 - 0.5;
        }

        private double ConvertToRads(double degrees)
        {
            return degrees*Math.PI/180.0;
        }

        private void StartRotation(double numberOfDegrees)
        {
            _rotationToGo = numberOfDegrees;
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
        }
    }
}
