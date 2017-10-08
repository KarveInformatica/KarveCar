using System;
using KarveCommon.Command;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    public class CareKeeper: ICareKeeperService
    {
        private CommandHistory _history;
        private DataPayLoad _payLoad;
        //private IDictionary<string, DataPayLoad> dictionary = new Dictionary<string, DataPayLoad>();
        // object path
        public CareKeeper()
        {
            _history = CommandHistory.GetInstance();
        }
        public void Do(CommandWrapper w)
        {
            w.Parameters = _payLoad;
            _history.DoCommand(w);
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Schedule(DataPayLoad payload)
        {
            //string name = payload.ObjectPath+"#"+payload.PayloadType.ToString();
            _payLoad = payload;
            /*
             * if (dictionary.ContainsKey(name))
            {
                dictionary.Remove(name);
                dictionary.Add(name, payload);
            }
            else
            {
                dictionary.Add(name, payload);
            }
            */
        }
    }
}
