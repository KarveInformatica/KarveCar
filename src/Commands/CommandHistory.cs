using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Commands
{
    public class CommandHistory
    {


        /*
         
          void CommandHistory::AddHistory(Command* c)
        {
            if (_history.size() > MAX_UNDO_COMMAND * 2)
                ClearList(&_history);
            _history.push_back(c);
        }
        void CommandHistory::Repeat()
        {
            command_iterator it;
            CommandList tmpList;
            ClearList(&_redoList);
            ClearList(&_undoList);
            std::copy(_history.begin(), _history.end() - 1, back_inserter(tmpList));
            _history.clear();
            for (it = tmpList.begin(); it != tmpList.end(); ++it)
            {
                DoCommand(*it);
            }
        }
        void CommandHistory::DoCommand(Command* c)
        {
            ClearList(&_redoList);
            if (c->Execute())
            {
                AddUndo(c);
                //AddHistory(c);	
            }
        }
        bool CommandHistory::isDirty() const
        {
            return (_cleanCount != 0);
        }
        Command* CommandHistory::getLastRedoCommand() const
        {
            return _redoList.back();
        }
        Command* CommandHistory::getLastUndoCommand() const
        {
            return _undoList.back();
        }
        bool CommandHistory::CanUndo() const
        {
            return (_undoList.size()>0);
        }
        bool CommandHistory::CanRedo() const
        {
            return (_redoList.size()>0);
        }
        void CommandHistory::Undo()
        {
            bool state = false;

            if (CanUndo())
            {
                _cleanCount--;
                Command* c = _undoList.back();
                _undoList.pop_back();
                if ((c) && (c->Unexecute()))
                {
                    AddRedo(c);
                    //AddHistory(c);
                }
                else
                    secure::safe_delete<Command>(c);

            }
        }

        void CommandHistory::Redo()
        {
            if (CanRedo())
            {
                _cleanCount++;
                Command* c = _redoList.back();
                _redoList.pop_back();
                if (c->Execute())
                {
                    AddUndo(c);
                    //AddHistory(c);
                }
                else
                    secure::safe_delete<Command>(c);
            }

        }
// cleanup
        void CommandHistory::Clear()
        {
            if (instance != 0)
            {
                delete instance;
            }
        }
        void CommandHistory::EraseList(CommandList* pList)
        {
            pList->erase(pList->begin(), pList->end());
        }
        void CommandHistory::ClearList(CommandList* pList)
        {
            command_iterator it;
            for (it = pList->begin(); it != pList->end(); it++)
            {
                secure::safe_delete<Command>(*it);
            }
            pList->erase(pList->begin(), pList->end());
        }
// cleanup me
        void CommandHistory::setClean()
        {
            _cleanCount = 0;
        }
        void CommandHistory::ClearRedoList()
        {
            ClearList(&_redoList);
        }
        void CommandHistory::ClearUndoList()
        {
            ClearList(&_undoList);
        }

        CommandHistory::~CommandHistory(void)
        {	

            setClean();

            ClearList(&_history);

            ClearRedoList();

            ClearUndoList();
        }
// implementations
        void CommandHistory::AddUndo(Command* pCommand)
        {
            if (_undoList.size() >= MAX_UNDO_COMMAND)
            {
                delete _undoList.front();
                _undoList.pop_front();
            }
            _undoList.push_back(pCommand);
            if (_cleanCount < 0 && _redoList.size() > 0)
                _cleanCount = (int)_undoList.size() + (int)_redoList.size() + 1;
            else
                _cleanCount++;
        }
        void CommandHistory::AddRedo(Command* pCommand)
        {
            _redoList.push_back(pCommand);
        }
        private static CommandHistory _instance = null;
        private int _cleanCount = 0;
        public CommandHistory GetInstance()
        {
            if (_instance == null)
                _instance = new CommandHistory();
            return _instance;
        }
        void CommandHistory.AddHistory(Ab* c)
        {
            if (_history.size() > MAX_UNDO_COMMAND * 2)
                ClearList(&_history);
            _history.push_back(c);
        }
         */

    }

}
