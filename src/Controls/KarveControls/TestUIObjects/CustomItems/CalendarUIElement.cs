using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media;
namespace TestUIComponents.CustomItems
{
    public class KarveCalendarUIElement : UIElement
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(KarveCalendarUIElement));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(KarveCalendarUIElement));

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(KarveCalendarUIElement));

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Blue, 2.0), new Rect(X, Y, 100.0, 20.0));

            base.OnRender(drawingContext);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new KarveCalendarAutomationPeer(this);
        }
    }
}
