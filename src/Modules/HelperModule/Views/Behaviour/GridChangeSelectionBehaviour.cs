using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid;

namespace HelperModule.Views.Behaviour
{
    /// <summary>
    ///  This is a GridChangedSelectionBehavior that allow us to manage selection in a grid.
    ///  Behaviors are a way of supplementing the functionality, or behavior, of XAML elements. 
    /// A behavior is a chunk of code you write that can be used in XAML by attaching it 
    /// to some element through attached properties. 
    /// The behavior can use the exposed API of the element to which it is attached to add functionality 
    /// to that element or other elements in the visual tree of the view. 
    /// In this way, they are the XAML equivalent of C# extension methods. 
    /// Extension methods allow you to define additional methods for some class in C# without 
    /// modifying the class definition itself, and they work against the exposed API of the class. 
    /// Behaviors allow you to add functionality to an element by writing that functionality in the behavior class 
    /// and attaching it to the element as if it was part of the element itself.
    /// </summary>
    public class GridChangeSelectionBehaviour : Behavior<SfDataGrid>
    {
        public static readonly DependencyProperty ChangedSelectionCommandDependencyProperty =

            DependencyProperty.Register("ChangedSelectionCommand", typeof(ICommand),
                typeof(GridChangeSelectionBehaviour), new PropertyMetadata(null));

        public ICommand ChangedSelectionCommand
        {
            get { return (ICommand)GetValue(ChangedSelectionCommandDependencyProperty); }
            set { SetValue(ChangedSelectionCommandDependencyProperty, value); }
        }


        protected override void OnAttached()
        {
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            base.OnDetaching();
        }

        private void AssociatedObject_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            var value = this.AssociatedObject.SelectedItem;
            if (ChangedSelectionCommand != null)
            {
                ChangedSelectionCommand.Execute(value);
            }
        }
    }

}