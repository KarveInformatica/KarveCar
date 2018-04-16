using KarveDataServices.DataTransferObject;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace KarveControls.Behaviour
{
    public class GridEditButtonBehavior: KarveBehaviorBase<Button>
    {
        private bool _shallShow = false;
        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty commandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(GridEditButtonBehavior),
            new UIPropertyMetadata(null));

        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(commandProperty);
            }
            set
            {
                SetValue(commandProperty, value);
            }
        }
        /// <summary>
        ///  This is a param.
        /// </summary>
        public static readonly DependencyProperty paramProperty = DependencyProperty.Register("Param", typeof(object), typeof(GridEditButtonBehavior),
           new UIPropertyMetadata(null));
        /// <summary>
        /// Set or Get the Parameters property.
        /// </summary>
        public object Param
        {
            get
            {
                return GetValue(paramProperty);
            }
            set
            {
                SetValue(paramProperty, value);
            }
        }

        public static readonly DependencyProperty sourceViewProperty = DependencyProperty.Register("SourceView", typeof(object), typeof(GridEditButtonBehavior),
          new UIPropertyMetadata(null));


        public static readonly DependencyProperty openGridProperty = DependencyProperty.Register("OpenGrid", typeof(bool), typeof(GridEditButtonBehavior));

       
        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public BaseDto SourceView
        {
            get
            {
                return (BaseDto)GetValue(sourceViewProperty);
            }
            set
            {
                SetValue(sourceViewProperty, value);
            }
        }
    

        /// <summary>
        ///  OnAttached property. Attach the property to an item.
        /// </summary>
        protected override void OnSetup()
        { 
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_Click;   
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            ICommand command = Command;
           
                if (command != null)
                {
                    var v = Param;
                    if (v == null)
                    {
                        v = currentButton.DataContext;
                    }
                    
                    
                    command.Execute(v);
                }
        }

        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.MouseDoubleClick -= AssociatedObject_Click;
        }



    }
}
