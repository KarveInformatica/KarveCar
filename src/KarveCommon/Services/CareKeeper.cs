using System;
using KarveCommon.Command;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveCommon.Services
{
    public class CareKeeper : ICareKeeperService
    {
        private CommandHistory _history;
        private Queue<DataPayLoad> _payLoad; 

        private bool _scheduledPayLoad;
        
        public CareKeeper()
        {
            _history = CommandHistory.GetInstance();
            _scheduledPayLoad = false;
            _payLoad = new Queue<DataPayLoad>();
            
        }
        public DataPayLoad Do(CommandWrapper w)
        {
            var currentPayload = new DataPayLoad();
            if (_payLoad.Count > 0)
            {
                currentPayload = _payLoad.Dequeue();
                w.Parameters = currentPayload;
                _history.DoCommand(w);
                _scheduledPayLoad = _payLoad.Count > 0;
            }
            return currentPayload;
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Redo()
        {
            _history.Redo();
        }
        public Queue<DataPayLoad> GetScheduledPayload()
        {
            return _payLoad;
        }

        public DataPayLoad.Type GetScheduledPayloadType()
        {
            var front = _payLoad.FirstOrDefault();
            var type = DataPayLoad.Type.Any;
            if (front != null)
            {
                type = front.PayloadType;
            }
            if (_scheduledPayLoad)
            {
                return type;   
            }
            return DataPayLoad.Type.Any;
            
        }
        public bool EnqueueSingle(DataPayLoad payLoad)
        {
            var type = (payLoad.PayloadType == DataPayLoad.Type.Update) || (payLoad.PayloadType ==  DataPayLoad.Type.Insert) || (payLoad.PayloadType ==  DataPayLoad.Type.Delete);
            
            return type;
        }
        public void Schedule(DataPayLoad payload)
        {
            if ((payload != null) && (payload.DataObject!=null))
            {
                if (EnqueueSingle(payload))
                {
                    _payLoad.Clear();
                }
                _payLoad.Enqueue(payload);
                 _scheduledPayLoad = true;
            }
            Contract.Ensures(_payLoad!=null);
        }
    }
    }
