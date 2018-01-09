using System;
using KarveCommon.Command;
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveCommon.Services
{
    public class CareKeeper : ICareKeeperService
    {
        private CommandHistory _history;
        private DataPayLoad _payLoad;

        private enum State
            {
             Init, Scheduling, Executing
        };

        private State _currentState;
        private bool _scheduledPayLoad;
        //private IDictionary<string, DataPayLoad> dictionary = new Dictionary<string, DataPayLoad>();
        // object path
        public CareKeeper()
        {
            _history = CommandHistory.GetInstance();
            _scheduledPayLoad = false;
            _currentState = State.Init;
            
        }
        public DataPayLoad Do(CommandWrapper w)
        {
           _currentState = State.Executing;
            w.Parameters = _payLoad;
            _history.DoCommand(w);
            _scheduledPayLoad = false;
            _currentState = State.Init;
            return _payLoad;
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
            if (_currentState != State.Executing)
            {
                _payLoad = payload;
                _scheduledPayLoad = true;
                _currentState = State.Executing;
            }
        }
    }
}
