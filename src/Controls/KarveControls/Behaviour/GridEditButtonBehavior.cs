﻿using KarveDataServices.ViewObjects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveCommon.Generic;


namespace KarveControls.Behaviour
{
    /// <inheritdoc />
    /// <summary>
    /// GridEditButtonBehavior is a behaviour that allows to trigger a window.
    /// </summary>
    public class GridEditButtonBehavior : KarveBehaviorBase<Button>
    {
        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty commandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(GridEditButtonBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(commandProperty);
            set => SetValue(commandProperty, value);
        }
        /// <summary>
        ///  This is a param.
        /// </summary>
        public static readonly DependencyProperty paramProperty = DependencyProperty.Register(
            "Param",
            typeof(object),
            typeof(GridEditButtonBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
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
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits));

       
        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public BaseViewObject SourceView
        {
            get
            {
                return (BaseViewObject)GetValue(sourceViewProperty);
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
            this.AssociatedObject.Click += AssociatedObject_Click;
            this.AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            if (key == Key.F4)
            {
                Button currentButton = sender as Button;
                ICommand command = Command;
              
                if (currentButton == null)
                {
                    return;
                }
                var v = Param ?? currentButton.DataContext;
                ExecuteCommand(currentButton, command, v);
            }
        }

        protected virtual void ExecuteCommand(Button currentButton,ICommand command, object param)
        {
            var v = Param ?? currentButton.DataContext;
            command.Execute(v);
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            ICommand command = Command;

            if (command == null)
            {
                return;
            }

            if (currentButton == null)
            {
                return;
            }
            var v = Param ?? currentButton.DataContext;
            ExecuteCommand(currentButton, command, v);

        }

        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.Click -= AssociatedObject_Click;
            this.AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }



    }
}
