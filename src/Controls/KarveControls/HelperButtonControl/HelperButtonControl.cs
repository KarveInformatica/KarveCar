using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace KarveControls
{
    public class HelperButtonControl : Control
    {

        /// <summary>
        ///  HelperButtonControl.
        /// </summary>
        public HelperButtonControl ():base()
        {
        }

        static HelperButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HelperButtonControl), new FrameworkPropertyMetadata(typeof(HelperButtonControl)));
            //TabStripPlacementProperty.AddOwner(typeof(TabControl), new FrameworkPropertyMetadata(Dock.Top, new PropertyChangedCallback(OnTabStripPlacementChanged)));
        }

        public static readonly DependencyProperty SaveCommandDependencyProperty =
            DependencyProperty.RegisterAttached(
                "SaveCommand",
                typeof(ICommand),
                typeof(HelperButtonControl));

        public ICommand SaveCommand
        {
            get
            {
                return (ICommand) GetValue(SaveCommandDependencyProperty);
            }
            set
            {
                SetValue(SaveCommandDependencyProperty, value);

            }
        }

        

        public ICommand SaveCommandParam
        {
            get
            {
                return (ICommand)GetValue(SaveCommandParamDependencyProperty);
            }
            set
            {
                SetValue(SaveCommandParamDependencyProperty, value);

            }
        }

        public static readonly DependencyProperty SaveCommandParamDependencyProperty =
            DependencyProperty.RegisterAttached(
                "SaveCommandParam",
                typeof(object),
                typeof(HelperButtonControl));


        public static readonly DependencyProperty ExitCommandDependencyProperty =
     DependencyProperty.RegisterAttached(
         "ExitCommand",
         typeof(ICommand),
         typeof(HelperButtonControl));

        public ICommand ExitCommand
        {
            get
            {
                return (ICommand)GetValue(ExitCommandDependencyProperty);
            }
            set
            {
                SetValue(ExitCommandDependencyProperty, value);

            }
        }

        public static readonly DependencyProperty ExitCommandParamDependencyProperty =
    DependencyProperty.RegisterAttached(
        "ExitCommandParam",
        typeof(object),
        typeof(HelperButtonControl));

        public object ExitCommandParam
        {
            get
            {
                return GetValue(ExitCommandParamDependencyProperty);
            }
            set
            {
                SetValue(ExitCommandParamDependencyProperty, value);

            }
        }

        public static readonly DependencyProperty HelpCommandDependencyProperty =
        DependencyProperty.RegisterAttached(
       "HelpCommand",
        typeof(ICommand),
        typeof(HelperButtonControl));

        public ICommand HelpCommand
        {
            get
            {
                return (ICommand)GetValue(HelpCommandDependencyProperty);
            }
            set
            {
                SetValue(HelpCommandDependencyProperty, value);
            }
        }


    }
}
