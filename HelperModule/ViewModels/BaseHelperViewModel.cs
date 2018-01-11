using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  This base helper view model.
    /// </summary>
    public abstract class BaseHelperViewModel : BindableBase
    {
        /// <summary>
        ///  This command exit the interface
        /// </summary>
        public ICommand ExitCommand { set; get; }

        public ICommand ResetCommand { set; get; }

        public ICommand DeleteCommand { set; get; }
        /// <summary>
        /// This help command
        /// </summary>
        public ICommand HelpCommand { set; get; }
        /// <summary>
        /// This save command
        /// </summary>
        public ICommand SaveCommand { set; get; }
        /// <summary>
        ///  Save Command Param.
        /// </summary>
        public object SaveCommandParam { set; get; }
        /// <summary>
        ///  Method on exit depends on the current view model, region so this is abstract
        /// </summary>
        /// <param name="value">Value on exit command</param>
        public virtual void OnExitCommand(object value) { };
       
        /// On help command. This shows the help of the command.
        /// </summary>
        /// <param name="value"></param>
        public virtual void OnHelpCommand() {} 
        /// <summary>
        ///  This is a on save command.
        /// </summary>
        /// <param name="value">Parameters in the save</param>
        public virtual void OnSaveCommand(object value ) {}
        /// <summary>
        ///  BaseHelperViewModel. 
        /// </summary>
        public BaseHelperViewModel()
        {
            ExitCommand = new DelegateCommand<object>(OnExitCommand);
            HelpCommand = new DelegateCommand(OnHelpCommand);
            SaveCommand = new DelegateCommand<object>(OnSaveCommand);
        }
        
    }
}
