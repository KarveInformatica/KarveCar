using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MultiEventCommand.CustomControls
{
    class ReflectionControl : Decorator
    {
        private readonly VisualBrush _reflection;
        private readonly LinearGradientBrush _opacityMask;

        public ReflectionControl()
        {
            // Set defaults for this control
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;

            // Create brushes were going to use
            _opacityMask = new LinearGradientBrush {StartPoint = new Point(0, 0), EndPoint = new Point(0, 1)};
            _opacityMask.GradientStops.Add(new GradientStop(Colors.Black, 0));
            _opacityMask.GradientStops.Add(new GradientStop(Colors.Black, 0.5));
            _opacityMask.GradientStops.Add(new GradientStop(Colors.Transparent, 0.8));
            _opacityMask.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
            _reflection = new VisualBrush
                              {Stretch = Stretch.None, TileMode = TileMode.None, Transform = new ScaleTransform(1, -1)};
        }

        protected override Size MeasureOverride(Size constraint)
        {
            // We need twice the space that our content needs
            if (Child == null)
            {
                return new Size(0, 0);
            }
            Child.Measure(constraint);
            return new Size(Child.DesiredSize.Width, Child.DesiredSize.Height * 2);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            // always put out content at the upper half of the control
            if (Child == null)
            {
                return new Size(0, 0);
            }
            Child.Arrange(new Rect(0, 0, arrangeBounds.Width, arrangeBounds.Height / 2));
            return arrangeBounds;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // draw everything except the reflection
            base.OnRender(drawingContext);

            // set opacity
            drawingContext.PushOpacityMask(_opacityMask);
            drawingContext.PushOpacity(0.3);

            // set reflection parameters based on content size
            _reflection.Visual = Child;
            ((ScaleTransform)_reflection.Transform).CenterY = 3 * ActualHeight / 4;
            ((ScaleTransform)_reflection.Transform).CenterX = ActualWidth / 2;

            // draw the reflection
            drawingContext.DrawRectangle(
                _reflection, null,
                new Rect(0, ActualHeight / 2, ActualWidth, ActualHeight / 2));

            // cleanup
            drawingContext.Pop();
            drawingContext.Pop();
        }
    }
}