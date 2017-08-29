using System;
using System.Collections.Generic;
using KarveCommon.Services;

namespace KarveCommon.Services
{
    public class EventManager : IEventManager
    {
        IList<IEventObserver> _observers = new List<IEventObserver>();
        IDictionary<string, IList<IEventObserver>> _subsystemObserver = new Dictionary<string, IList<IEventObserver>>();
        IList<IEventObserver> _toolBar = new List<IEventObserver>();

        private void notifyObserver(DataPayLoad payload, IList<IEventObserver> eoList)
        {
            foreach (IEventObserver eo in eoList)
            {
                eo.incomingPayload(payload);
            }
        }
        public void notifyObserver(DataPayLoad payload)
        {
            notifyObserver(payload, _observers);
        }
        public void notifyObserverSubsystem(string v, DataPayLoad dataPayload)
        {
            if (_subsystemObserver.ContainsKey(v))
            {
                IList<IEventObserver> value = null;
                if (_subsystemObserver.TryGetValue(v, out value))
                {
                    notifyObserver(dataPayload, value);  
                }
            }
        }

        public void notifyObserverToolBar(DataPayLoad payload)
        {
            notifyObserver(payload, _toolBar);
        }

        public void registerObserver(IEventObserver obs)
        {
            _observers.Add(obs);
        }

        public void registerObserverSubsystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                IList<IEventObserver> value =null;
                if (_subsystemObserver.TryGetValue(id, out value))
                {
                    value.Add(obs);
                    _subsystemObserver[id] = value;
                }
            }
            else
            {
                IList<IEventObserver> value = new List<IEventObserver>();
                value.Add(obs);
                _subsystemObserver[id] = value;
             }

        }

        public void registerObserverToolBar(IEventObserver obs)
        {
            _toolBar.Add(obs);
        }
    }
}