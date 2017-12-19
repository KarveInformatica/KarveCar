using System;
using KarveCommon.Command;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    public class CareKeeper: ICareKeeperService
    {
        private CommandHistory _history;
        private DataPayLoad _payLoad;

        private bool _scheduledPayLoad;
        //private IDictionary<string, DataPayLoad> dictionary = new Dictionary<string, DataPayLoad>();
        // object path
        public CareKeeper()
        {
            _history = CommandHistory.GetInstance();
            _scheduledPayLoad = false;
        }
        public void Do(CommandWrapper w)
        {
            w.Parameters = _payLoad;
            _history.DoCommand(w);
            _scheduledPayLoad = false;

        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Redo()
        {
            _history.Redo();
        }
        public DataPayLoad GetScheduledPayload()
        {
            return _payLoad;
        }

        public DataPayLoad.Type GetScheduledPayloadType()
        {
            if (_scheduledPayLoad)
            {
                return _payLoad.PayloadType;   
            }
            return DataPayLoad.Type.Any;
            
        }
        public void Schedule(DataPayLoad payload)
        {
            _payLoad = payload;
            _scheduledPayLoad = true;
        }
    }
}
