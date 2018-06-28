using Syncfusion.Windows.Controls.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  Behaviour for navigate to the right tab will 
    /// </summary>
    public class SfTreeNavigatorBehavior : KarveBehaviorBase<SfTreeNavigator>
    {

        public static readonly DependencyProperty selectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(SfTreeNavigatorBehavior),
            new UIPropertyMetadata(null));
        protected override void OnSetup()
        {
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }
        protected override void OnCleanup()
        {
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }
        private void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = e;
            var s = sender;
        }

    }
}
