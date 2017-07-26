using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Command;

namespace KarveCommon.Services
{
    public class CareKeeper: ICareKeeperService
    {
        private CommandHistory history;

        public CareKeeper()
        {
            history = CommandHistory.GetInstance();
        }
        public void Do(CommandWrapper w)
        {
            history.DoCommand(w);
        }

        public void Undo()
        {
            history.Undo();
        }

        public void Redo()
        {
            history.Redo();
        }
    }
}
