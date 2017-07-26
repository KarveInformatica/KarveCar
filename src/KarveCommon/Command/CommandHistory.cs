/**
 * Copyright 2017 KarveInformatica S.L.
 * CommandHistory module.
 * author Giorgio Zoppi <giorgio.zoppi@karveinformatica.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Command;


namespace KarveCommon.Command
{
    /// <summary>
    ///  CommandWrapper. It wraps the command for placing in the parameters.
    /// </summary>
    public class CommandWrapper
    {
       // Command
        private AbstractCommand _command;
        // Parameters of the command.
        private object _parameters;

        public CommandWrapper(AbstractCommand cmd, object param)
        {
            this.Parameters = param;
            this.Command = cmd;
        }

        public object Parameters { get { return _parameters; } set { _parameters = value; } }
        public AbstractCommand Command { get { return _command; } set { _command = value; } }
        
    }
    /// <summary>
    ///  CommandHistory. It take trace of each command fired in the application and it allows the redo/undo.
    ///  Singleton Pattern.
    /// </summary>
    public class CommandHistory
    {
        // List of the redo command
        private IList<CommandWrapper> redoList;
        // List of the undo command
        private IList<CommandWrapper> undoList;

        private IList<CommandWrapper> historyList;

        // single instance of the command list.
        private static CommandHistory _instance;

        // This is useful to enable or disable the Undo. In case is different from zero there are some command in the lists.
        private int _cleanUpCount;

        /// <summary>
        ///  Constructor of the CommandHistory
        ///  It shall be private because it is a singleton.
        /// </summary>
        private CommandHistory()
        {
            redoList = new List<CommandWrapper>();
            undoList = new List<CommandWrapper>();
            historyList = new List<CommandWrapper>();
            _cleanUpCount = 0;
        }
       /// <summary>
       ///  Singleton accessory method.
       /// </summary>
       /// <returns> The current command history.</returns>
        public static CommandHistory GetInstance()
        {
            if (_instance == null)
            {
                _instance= new CommandHistory();
            }
            return _instance;
        }
        /// <summary>
        /// This clean up the class.
        /// </summary>
        public void Clear()
        {
            redoList.Clear();
            undoList.Clear();
            _instance = null;
        }
        /// <summary>
        ///  Repeat all the commands except the last one.
        /// </summary>
        public void Repeat()
        {
            IList<CommandWrapper> tmpList = new List<CommandWrapper>();
            redoList.Clear();
            undoList.Clear();
            foreach (var cmd in historyList)
            {
                tmpList.Add(cmd);
            }
            
            tmpList.RemoveAt(tmpList.Count - 1);
            foreach (var cmd in tmpList)
            {
                DoCommand(cmd);
            }
        }
        /// <summary>
        /// Check if a command can be executed, a
        /// </summary>
        /// <param name="commandWrapper"></param>
        private void DoCommand(CommandWrapper commandWrapper)
        {
            ICommand command = commandWrapper.Command;
            object param = commandWrapper.Parameters;
            redoList.Clear();
            if (command.CanExecute(param))
            {
                command.Execute(param);
                AddUndo(commandWrapper);
                historyList.Add(commandWrapper);
            }
        }
        /// <summary>
        /// This returns if the code is dirty or not.
        /// </summary>
        /// <returns></returns>
        public bool IsDirty()
        {
            return (_cleanUpCount != 0);
        }
       
        public CommandWrapper GetLastRedoCommand()
        {
            return redoList[redoList.Count - 1];
        }

        public CommandWrapper GetLastUndoCommand()
        {
            return undoList[undoList.Count - 1];
        }

        public bool CanUndo()
        {
            return (undoList.Count > 0);
        }

        public bool CanRedo()
        {
            return (redoList.Count > 0);
        }

        public void Undo()
        {
            if (CanUndo())
            {
                _cleanUpCount--;
                CommandWrapper tmpCommandWrapper = GetTailAndRemove(undoList);
                if (tmpCommandWrapper.Command.UnExecute())
                {
                    AddRedo(tmpCommandWrapper);
                }
            }
        }

        public void Redo()
        {
            if (CanRedo())
            {
                _cleanUpCount++;
                CommandWrapper tmpCommandWrapper = GetTailAndRemove(redoList);

                if (tmpCommandWrapper.Command.CanExecute(tmpCommandWrapper.Parameters))
                {
                    AddUndo(tmpCommandWrapper);
                }
            }
        }

        private void AddUndo(CommandWrapper commandWrapper)
        {
             undoList.Add(commandWrapper);
            _cleanUpCount = ((_cleanUpCount < 0) && (redoList.Count > 0)) ? undoList.Count + redoList.Count + 1 : _cleanUpCount++;
        }

        private void AddRedo(CommandWrapper tmpCommandWrapper)
        {
            redoList.Add(tmpCommandWrapper);
        }
        private CommandWrapper GetTailAndRemove(IList<CommandWrapper> commandWrapperList)
        {
            CommandWrapper tmpCommandWrapper = commandWrapperList[commandWrapperList.Count - 1];
            commandWrapperList.RemoveAt(commandWrapperList.Count - 1);
            return tmpCommandWrapper;
        }
    }
        
}
