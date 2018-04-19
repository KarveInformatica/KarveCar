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
    /// <summary>
    ///  This is the carekeeper service. Its resposability 
    ///  is to schedule and redo the payload that are coming
    ///  from the forms.
    /// </summary>
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
        /// <summary>
        ///  Insert a command in the history
        /// </summary>
        /// <param name="w">CommandWrapper that incapusulate the command</param>
        /// <returns>The descheduled payload, already executed</returns>
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
        /// <summary>
        ///  Undo the last command
        /// </summary>
        public void Undo()
        {
            _history.Undo();
        }
        /// <summary>
        ///  Redo the last command
        /// </summary>
        public void Redo()
        {
            _history.Redo();
        }
        /// <summary>
        ///  Get the queue of the payload
        /// </summary>
        /// <returns>Returns a queue of the saved payloads</returns>
        public Queue<DataPayLoad> GetScheduledPayload()
        {
            return _payLoad;
        }
        /// <summary>
        ///  Get the last scheduled payload type.
        /// </summary>
        /// <returns>Returns the type of the payload</returns>
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
        /// <summary>
        ///  Enqueue a single payload
        /// </summary>
        /// <param name="payLoad">Payload to enqueue</param>
        /// <returns>True o false in case of payload</returns>
        public bool EnqueueSingle(DataPayLoad payLoad)
        {
            var type = (payLoad.PayloadType == DataPayLoad.Type.Update) || (payLoad.PayloadType ==  DataPayLoad.Type.Insert) || (payLoad.PayloadType ==  DataPayLoad.Type.Delete);
            
            return type;
        }
        /// <summary>
        ///  Schedule a payload.
        /// </summary>
        /// <param name="payload">Payload to be scheduled</param>
        public void Schedule(DataPayLoad payload)
        {
            if ((payload != null) && (payload.DataObject!=null))
            {
                if (!_payLoad.Contains(payload))
                {
                    _payLoad.Enqueue(payload);
                }
               _scheduledPayLoad = _payLoad.Count() > 0;
            }
            Contract.Ensures(_payLoad!=null);
        }
        /// <summary>
        ///  Return the number of scheudled payload.
        /// </summary>
        /// <returns>Number of the scheduled payload.</returns>
        public int ScheduledPayloadCount()
        {
            return _payLoad.Count();
        }

        public void DeleteItems(Uri objectPath)
        {
            var currentList = _payLoad.ToList();
            currentList.RemoveAll(x => x.ObjectPath == objectPath);
            _payLoad.Clear();
            foreach (var i in currentList)
            {
                _payLoad.Enqueue(i);
            }
        }
    }
    }
