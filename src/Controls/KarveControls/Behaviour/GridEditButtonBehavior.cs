using KarveDataServices.DataTransferObject;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KarveControls.Behaviour
{
    public class GridEditButtonBehavior: Behavior<Button>
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
          new UIPropertyMetadata(null, OnSourceViewChanged));


        public static readonly DependencyProperty openGridProperty = DependencyProperty.Register("OpenGrid", typeof(bool), typeof(GridEditButtonBehavior));

        /// <summary>
        /// Set or Get the source view changed.
        /// </summary>
        /// <param name="d">Dependency Object</param>
        /// <param name="e">Event changed</param>
        private static void OnSourceViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridEditButtonBehavior buttonGrid = d as GridEditButtonBehavior;
            if (buttonGrid!=null)
            {
                buttonGrid.OnSourceChanged(buttonGrid, e);
            }
        }
        /// <summary>
        ///  OnSourceChanged.
        /// </summary>
        /// <param name="bt">GridEditButtonBehavior</param>
        /// <param name="e">Event parameter.</param>
        public void OnSourceChanged(GridEditButtonBehavior bt, DependencyPropertyChangedEventArgs e)
        {
            BaseDto dto = e.NewValue as BaseDto;

        }
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
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_Click;   
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        { 
            ICommand command = Command;
            if (!_shallShow)
            {
                if (command != null)
                {
                    var v = Param;
                    
                    command.Execute(v);
                }
                _shallShow = true;
            }
            else
            {
                _shallShow = false;
            }
        }

        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }



    }
}
