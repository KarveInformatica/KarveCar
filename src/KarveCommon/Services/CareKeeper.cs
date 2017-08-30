using System;
using KarveCommon.Command;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    public class CareKeeper: ICareKeeperService
    {
        private CommandHistory history;
        private IDictionary<string, DataPayLoad> dictionary = new Dictionary<string, DataPayLoad>();
        // object path
        public CareKeeper()
        {
            history = CommandHistory.GetInstance();
        }
        public void Do(CommandWrapper w)
        {
            w.Parameters = dictionary;
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

        public void Schedule(DataPayLoad payload)
        {
            string name = payload.ObjectPath+"#"+payload.PayloadType.ToString(); 
            if (dictionary.ContainsKey(name))
            {
                dictionary.Remove(name);
                dictionary.Add(name, payload);
            }
            else
            {
                dictionary.Add(name, payload);
            }
        }
    }
}
