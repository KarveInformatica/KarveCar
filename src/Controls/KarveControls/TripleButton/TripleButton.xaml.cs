using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KarveControls.KarveTripleButton
{
    /// <summary>
    /// Interaction logic for TripleButton.xaml
    /// </summary>
  
    public partial class TripleButton : UserControl
    {
        /// <summary>
        ///  This expose the change action dependency property.
        /// </summary>
        public static DependencyProperty ResetCommandDependencyProperty
            = DependencyProperty.Register(
                "ResetCommand",
                typeof(ICommand),
                typeof(TripleButton));
        /// <summary>
        ///  This expose the delete dependency property.
        /// </summary>
        public static DependencyProperty DeleteCommandDependencyProperty
            = DependencyProperty.Register(
                "DeleteCommand",
                typeof(ICommand),
                typeof(TripleButton));

        /// <summary>
        ///  This expose the reset comman dependency property.
        /// </summary>
        public static DependencyProperty SaveCommandDependencyProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(TripleButton));


        public static DependencyProperty SaveVisibilityProperty
         = DependencyProperty.Register(
             "SaveVisible",
             typeof(bool),
             typeof(TripleButton), new PropertyMetadata(true));

        public bool SaveVisible
        {
            set
            {
                SetValue(SaveVisibilityProperty, value);
            }
            get
            {
                return (bool)GetValue(SaveVisibilityProperty);
            }
        }
        public static DependencyProperty DeleteVisibilityProperty
         = DependencyProperty.Register(
             "DeleteVisible",
             typeof(bool),
             typeof(TripleButton), new PropertyMetadata(true));
        public bool DeleteVisible
        {
            set
            {
                SetValue(DeleteVisibilityProperty, value);
            }
            get
            {
                return (bool)GetValue(DeleteVisibilityProperty);
            }
        }


        public static DependencyProperty ResetVisibilityProperty
         = DependencyProperty.Register(
            "ResetVisible",
              typeof(bool),
              typeof(TripleButton), new PropertyMetadata(true));
        public bool ResetVisible
        {
            set
            {
                SetValue(ResetVisibilityProperty, value);
            }
            get
            {
                return (bool)GetValue(ResetVisibilityProperty);
            }
        }

        /// <summary>
        /// Localization.
        /// </summary>
        public static DependencyProperty LocalizationDependencyProperty = DependencyProperty.Register("Locale",
            typeof(List<string>),
            typeof(TripleButton));

        /// <summary>
        /// Localization dependency property.
        /// </summary>
        public List<string> Localization
        {
            set
            {
                SetValue(LocalizationDependencyProperty, value);
                // ok here we can put the dependency property.
                List<string> currentLocale = value as List<string>;
                if ((currentLocale !=  null) && (currentLocale.Count == 3))
                {
                    SaveText.Text = currentLocale[0] as string;
                    ResetText.Text = currentLocale[1] as string;
                    DeleteText.Text = currentLocale[2] as string;
                }
            }
            get
            {
                return (List<string>)GetValue(LocalizationDependencyProperty);
            }
        }
        
        /// <summary>
        ///  Reset command to be executed
        /// </summary>
        public ICommand ResetCommand
        {
            set
            {
                SetValue(SaveCommandDependencyProperty, value);
            }
            get
            {
               return (ICommand)GetValue(SaveCommandDependencyProperty);
            }
        }
        /// <summary>
        ///  Delete command.
        /// </summary>
        public ICommand DeleteCommand
        {
            set
            {
                SetValue(DeleteCommandDependencyProperty, value);
            }
            get
            {
               return (ICommand)GetValue(DeleteCommandDependencyProperty);
            }
        }
        /// <summary>
        ///  Save command.
        /// </summary>
        public ICommand SaveCommand
        {
            set
            {
                SetValue(SaveCommandDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(SaveCommandDependencyProperty);
            }
        }
        
        /// <summary>
        ///  Triple button support.
        /// </summary>
        public TripleButton()
        {
            InitializeComponent();
            TripleCommandLayout.DataContext = this;
        }
    }
}
