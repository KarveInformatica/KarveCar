using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;
using System.Windows.Input;

namespace KarveControls.Behaviour
{
    public class GridKeyboardBehavior: KarveBehaviorBase<SfDataGrid>
    {
        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty commandProperty = DependencyProperty.Register("OpenCommand", typeof(ICommand), typeof(GridKeyboardBehavior),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits));
        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public ICommand OpenCommand
        {
            get => (ICommand)GetValue(commandProperty);
            set => SetValue(commandProperty, value);
        }
        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty deleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(GridKeyboardBehavior),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(deleteCommandProperty);
            set => SetValue(deleteCommandProperty, value);
        }
        protected override void OnSetup()
        {
            this.AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }
        private void AssociatedObject_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

           /* if (e.Key == Key.F4)
            {
                if (OpenCommand != null)
                {
                    if (OpenCommand.CanExecute(null))
                    {
                        foreach (var item in AssociatedObject.SelectedItems)
                        {
                            OpenCommand.Execute(item);
                        }
                    }
                }
            }
            */
            if (e.Key == Key.Delete)
            {
                if (DeleteCommand != null)
                {
                    if (DeleteCommand.CanExecute(null))
                    {
                       DeleteCommand.Execute(null);
                    }
                }
            }
            if (e.Key == Key.F2)
            {
                if (AssociatedObject.SelectedItem is BaseDto dto)
                {
                    dto.IsSelected = true;
                }
            }
        }

        /// <summary>
        /// Cleanup the behavior.
        /// </summary>
        protected override void OnCleanup() {
            this.AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
    }
}
