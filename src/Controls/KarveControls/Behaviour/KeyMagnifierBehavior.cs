using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace KarveControls.Behaviour
{
    // KeyuMagnifier behaviour
    public class KeyMagnifierBehavior : KarveBehaviorBase<SfDataGrid>
    {
        public static DependencyProperty RelatedButtonProperty
           = DependencyProperty.Register(
               "RelatedButton",
               typeof(Button),
               typeof(KeyMagnifierBehavior));
        public static DependencyProperty MappingElementProperty
               = DependencyProperty.Register(
       "MappingElement",
       typeof(string),
       typeof(KeyMagnifierBehavior));

       
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(KeyMagnifierBehavior));

        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public KeyMagnifierBehavior()
        {
        }
        /// <summary>
        /// Set ot Get the mapping element property.
        /// </summary>
        public string MappingElement
        {
            set
            {
                SetValue(MappingElementProperty, value);
            }
            get
            {
                return (string)GetValue(MappingElementProperty);

            }
        }


        public Button RelatedButton
        {
            set
            {
                SetValue(RelatedButtonProperty, value);
            }
            get
            {
                return (Button)GetValue(RelatedButtonProperty);

            }
        }
        protected override void OnSetup()
        {
            this.AssociatedObject.PreviewKeyDown += KeyDown;
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            var myKey = e.Key;
            if (myKey == Key.F4)
            {
               if (AssociatedObject.CurrentColumn.MappingName.Equals(MappingElement))
                {
                        /*
                         *  In wpf doesnt exist a perfomClick
                         */
                       if (Command!=null)
                        {
                            Command.Execute(this.AssociatedObject.CurrentItem);
                        }
                    
                }
            }
            
        }

        protected override void OnCleanup()
        {
            this.AssociatedObject.PreviewKeyDown -= KeyDown;
        }


    }
}
